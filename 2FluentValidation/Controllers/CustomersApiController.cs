﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2FluentValidation.Models;
using FluentValidation;
using AutoMapper;
using _2FluentValidation.Models.DTOs;

namespace _2FluentValidation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IValidator<Customer> _customerValidator;
        private readonly IMapper _mapper;
        public CustomersApiController(AppDbContext context, IValidator<Customer> customerValidator, IMapper mapper)
        {
            _context = context;
            _customerValidator = customerValidator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MappingOrnek()
        {
            Customer customer = new Customer { Id = 2, Name = "test", Email = "test@gmail.com", Age = 23, CreditCard = new CreditCard { Number = "1234567891234567", ValidDate = DateTime.Now } };

            return Ok(_mapper.Map<CustomerDto>(customer));
        }
        // GET: api/CustomersApi
        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            return _mapper.Map<List<CustomerDto>>(customers);
        }

        // GET: api/CustomersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/CustomersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var result = _customerValidator.Validate(customer);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(x => new { Property = x.PropertyName, Error = x.ErrorMessage }));
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/CustomersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
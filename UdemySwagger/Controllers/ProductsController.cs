using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemySwagger.Models;

namespace UdemySwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SwaggerDbContext _context;

        public ProductsController(SwaggerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Bu endpoint tüm ürünleri liste olarak geri döner.
        /// </summary>
        /// <remarks>
        /// Örnek endpoint : https://localhost:7042/api/Products
        /// </remarks>
        /// <returns>
        /// </returns>
        /// <response code="404">Ürün veri tabanında bulunamadı</response>
        /// <response code="200">Verilen idye sahip ürün var</response>
        [Produces(MediaTypeNames.Application.Json)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Bu endpoint verilen id'ye sahip ürünü döner
        /// </summary>
        /// <param name="id">ürünün id'si</param>
        /// <returns></returns>
        [Produces(MediaTypeNames.Application.Json)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        /// <summary>
        /// Bu endpoint ürün ekler
        /// </summary>
        /// <remarks>
        /// Örnek: {"name":"string","price":0,"date":"2024-03-10","category":"kırtasiye"}
        /// </remarks>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}

﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3RateLimit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new { Id = 1, Name = "Kalem", Price = 20 });
        }
        [HttpPost]
        public IActionResult SaveProduct()
        {
            return Ok(new { Status = 200 });
        } 
        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return Ok();
        }
        [HttpGet("{name}")]
        public IActionResult GetProduct(string name)
        {
            return Ok(name);
        }
    }
}

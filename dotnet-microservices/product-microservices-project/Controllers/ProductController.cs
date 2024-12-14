using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using product_microservices_project.Interfaces;
using product_microservices_project.Models;

namespace product_microservices_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            var product = _productRepository.GetProductById(id);
            if(product == null)
                return NotFound("Id not found");
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _productRepository.InsertProduct(product);
            return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);
        }

        [HttpPut]
        public IActionResult Update([FromBody]Product product)
        {
            _productRepository.UpdateProduct(product);
            return Ok("Product updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            _productRepository.DeleteProduct(id);
            return NoContent();
        }
    }
}
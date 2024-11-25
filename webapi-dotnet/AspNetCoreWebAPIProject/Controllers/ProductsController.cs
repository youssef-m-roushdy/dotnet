using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPIProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebAPIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpPost]
        public IActionResult AddNewProduct(string productName, double price)
        {
            var newProduct = new Product
            {
                ProductName = productName,
                Price = price
            };
            try
            {
                _context.Products.Add(newProduct);
                _context.SaveChanges();
                return CreatedAtAction(nameof(AddNewProduct), new { id = newProduct.ProductId }, newProduct);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if(product == null)
                return BadRequest("Cannot find/Invalid Id");
            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(int id, string productName, double price)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if(product == null)
                return BadRequest("Cannot find/Invalid Id");
            product.ProductName = productName;
            product.Price = price;
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if(product == null)
                return BadRequest("Cannot find/Invalid Id");
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebAPIProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product() {ProductId = 1, ProductName = "Product One", Price = 15000},
            new Product() {ProductId = 2, ProductName = "Product Two", Price = 17000},
            new Product() {ProductId = 3, ProductName = "Product Three", Price = 20000},
            new Product() {ProductId = 4, ProductName = "Product Four", Price = 22500},
            new Product() {ProductId = 5, ProductName = "Product Five", Price = 40000},
            new Product() {ProductId = 6, ProductName = "Product Six", Price = 27000},
            new Product() {ProductId = 7, ProductName = "Product Seven", Price = 30000},
            new Product() {ProductId = 8, ProductName = "Product Eight", Price = 35000},
            new Product() {ProductId = 9, ProductName = "Product Nine", Price = 57000},
            new Product() {ProductId = 10, ProductName = "Product Ten", Price = 60000}
        };
        [HttpGet]
        public IActionResult GetAllProductsInList()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddNewProductToList(string productName, double price)
        {
            int id = products.Count + 1;
            Product newProduct =  new Product() {ProductId = id, ProductName = productName, Price = price};
            products.Add(newProduct);
            var createdUri = Url.Action("GetProductById", new { id = newProduct.ProductId });
            return Created(createdUri, newProduct);
        }
    }
}
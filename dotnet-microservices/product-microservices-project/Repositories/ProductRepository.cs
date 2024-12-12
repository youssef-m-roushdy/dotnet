using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using product_microservices_project.Data;
using product_microservices_project.Interfaces;
using product_microservices_project.Models;

namespace product_microservices_project.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }
        public void DeleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if(product == null)
                return;
            _context.Products.Remove(product);
            Save();
        }

        public Product GetProductById(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if(product == null)
                return null;
            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Products.Where(_ => true).ToList();
            return products;
        }

        public void InsertProduct(Product product)
        {
            _context.Products.Add(product);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if(productToUpdate != null)
                return;
            _context.Products.Update(product);
            Save();
        }
    }
}
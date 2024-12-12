using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using product_microservices_project.Models;

namespace product_microservices_project.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int productId);
        void InsertProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product);
        void Save();
    }
}
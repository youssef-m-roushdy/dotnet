using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Protos;
using Microsoft.AspNetCore.Authorization;

namespace GrpcService.Services
{
    [Authorize]
    public class ProductService : ProductProtoService.ProductProtoServiceBase
    {
        private readonly List<Product> _products = [];

        public ProductService()
        {
            _products.AddRange(new[]
            {
                new Product { Id = 1, Name = "Laptop", Description = "A gaming laptop", Price = 1200.0 },
                new Product { Id = 2, Name = "Phone", Description = "A smartphone", Price = 800.0 }
            });
        }
        public override Task<Product> GetProduct(GetProductRequest request, ServerCallContext context)
        {
            var product = _products.FirstOrDefault(x => x.Id == request.Id);
            if (product == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Can't find this product"));

            return Task.FromResult(product);
        }

        public override Task<ProductListResponse> ListProduct(Empty request, ServerCallContext context)
        {
            var response = new ProductListResponse();
            response.Products.AddRange(_products);
            if (response.Products.Count == 0)
                throw new RpcException(new Status(StatusCode.NotFound, "Can't find any products"));

            return Task.FromResult(response);
        }

        public override Task<Product> CreateProduct(CreateProductRequest request, ServerCallContext context)
        {
            var response = new Product
            {
                Id = _products.Count + 1,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            _products.Add(response);
            return Task.FromResult(response);
        }

        public override Task<Product> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
        {
            var product = _products.FirstOrDefault(x => x.Id == request.Id);
            if (product == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Can't find this product"));

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            return Task.FromResult(product);
        }

        public override Task<Empty> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
        {
            var product = _products.FirstOrDefault(x => x.Id == request.Id);
            if (product == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Can't find this product"));

            _products.Remove(product);

            return Task.FromResult(new Empty());
        }
    }
}
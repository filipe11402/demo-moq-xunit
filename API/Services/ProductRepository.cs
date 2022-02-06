using API.Context;
using API.Models;
using API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Product AddProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productId)
        {
            return this._dbContext.Products.FirstOrDefault(token => token.Id == productId);
        }

        public IEnumerable<Product> ListProducts()
        {
            return this._dbContext.Products.AsQueryable();
        }

        public Product UpdateProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}

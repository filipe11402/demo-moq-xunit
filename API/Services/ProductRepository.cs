using API.Context;
using API.Models;
using API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void DeleteProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(string productId)
        {
            throw new NotImplementedException();
        }
    }
}

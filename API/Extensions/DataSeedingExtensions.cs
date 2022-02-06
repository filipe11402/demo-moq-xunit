using API.Context;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace API.Extensions
{
    public static class DataSeedingExtensions
    {
        public static void SeedInitialProductsData(this IServiceCollection services) 
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("ProductsDb").Options;

            using var dbContext = new ApplicationDbContext(dbContextOptions);

            dbContext.Products.AddRange(new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Catnip",
                    Price = 10
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Toilet Paper",
                    Price = 7
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Meat",
                    Price = 20
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Water",
                    Price = 5
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Gas Bottle",
                    Price = 28
                }
            });

            dbContext.SaveChanges();

            //APPLY LOGIC HERE TO SEED INITIAL DATA
            //USE USING.DBCONTEXT...
        }
    }
}

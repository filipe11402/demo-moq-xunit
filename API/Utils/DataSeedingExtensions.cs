using API.Context;
using API.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace API.Utils
{
    public class DbContextUtils : IDisposable
    {
        private readonly SqliteConnection _connection;

        private DbContextOptions _dbContextOptions;

        public DbContextUtils()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                   .UseSqlite(_connection)
                                   .Options;

            using var dbContext = new ApplicationDbContext(_dbContextOptions);

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
        }

        public ApplicationDbContext CreateContext() { return new ApplicationDbContext(_dbContextOptions); }

        public void Dispose() => _connection.Dispose();
    }
}

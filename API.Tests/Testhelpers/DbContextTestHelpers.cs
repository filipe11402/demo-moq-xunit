using API.Context;
using API.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace API.Utils
{
    public class DbContextTestHelpers : IDisposable
    {
        private readonly SqliteConnection _connection;

        private DbContextOptions _dbContextOptions;

        public DbContextTestHelpers()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                   .UseSqlite(_connection)
                                   .Options;
        }

        public ApplicationDbContext CreateContext() { return new ApplicationDbContext(_dbContextOptions); }

        public void Dispose() => _connection.Dispose();

        public IEnumerable<Product> ProductListToTest => new List<Product>()
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
            };
    }
}

using API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

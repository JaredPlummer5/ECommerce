using System;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;
namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ECommerceDbContext(DbContextOptions options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           //modelBuilder.Entity<Category>().HasOne<Product>(c => c.Category).WithMany(c => c.Products).HasForeignKey(c => c.CategoryId);
        }



    }
}


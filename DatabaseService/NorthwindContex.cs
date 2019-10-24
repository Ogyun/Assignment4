using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService
{
    public class NorthwindContex : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "host=localhost;db=northwind;uid=postgres;pwd=cardreader95");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(m => m.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(m => m.Name).HasColumnName("categoryname");

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(m => m.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(m => m.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(m => m.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(m => m.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(m => m.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(m => m.UnitsInStock).HasColumnName("unitsinstock");

        }

    }
}

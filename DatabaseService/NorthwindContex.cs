using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService
{
    public class NorthwindContex : DbContext
    {
        public DbSet<Category> Categories { get; set; }

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
        }

    }
}

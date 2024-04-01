using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Models;

namespace Trendyol.Services
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Products?> Products { get; set; }
        public DbSet<WareHouse> WareHouse { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<SuperAdmin> SuperAdmin { get; set; }
        public DbSet<ProductsForOrder> ProductsForOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(builder.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Users)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

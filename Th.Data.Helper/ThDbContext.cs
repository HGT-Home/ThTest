using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Th.Models;

namespace Th.Data.Helper
{
    public class ThDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<ProductRate> ProductRates { get; set; }

        public DbSet<ProductTranslation> ProductTranslation { get; set; }

        public DbSet<ProductStatus> ProductStatuses { get; set; }

        public DbSet<ProductStatusTranslation> ProductStatusTranslations { get; set; }

        public DbSet<Company> Companies { get; set; }

        public ThDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(new LoggerFactory()
                .AddDebug());
            base.OnConfiguring(optionsBuilder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class MyDbContext : DbContext
    {

    public MyDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));
            }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder optionsBuilder)
            {
                optionsBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Beverages" },
                new Category { CategoryId = 2, CategoryName = "Condiments" },
                new Category { CategoryId = 3, CategoryName = "Confections" },
                new Category { CategoryId = 4, CategoryName = "Dairy Products" },
                new Category { CategoryId = 5, CategoryName = "Grains/Cereals" },
                new Category { CategoryId = 6, CategoryName = "Meat/Poultry" },
                new Category { CategoryId = 7, CategoryName = "Produce" },
                new Category { CategoryId = 8, CategoryName = "Seafood" }
                );

            optionsBuilder.Entity<Product>().HasData(
               new Product { ProductId = 1, ProductName = "Ruler", CategoryId = 1, UnitPrice = 10, UnitsInStock = 10 },
                 new Product { ProductId = 2, ProductName = "Book", CategoryId = 1, UnitPrice = 13, UnitsInStock = 10 },
                new Product { ProductId = 3, ProductName = "Notebook", CategoryId = 2, UnitPrice = 12, UnitsInStock = 10 },
                  new Product { ProductId = 4, ProductName = "Pen", CategoryId = 3, UnitPrice = 5, UnitsInStock = 10 },
                    new Product { ProductId = 5, ProductName = "Pencil", CategoryId = 8, UnitPrice = 7, UnitsInStock = 10 }
               );
        }
        }
}

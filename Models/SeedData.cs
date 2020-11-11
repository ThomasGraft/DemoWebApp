using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Models
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            // Apply all pending migrations for the context to the database
            context.Database.Migrate();

            // If database is empty
            if (context.Products.Count() == 0 && context.Suppliers.Count() == 0 && context.Categories.Count() == 0)
            {
                Supplier s1 = new Supplier { Name = "Splash Dudes", City = "San Jose" };
                Supplier s2 = new Supplier { Name = "Soccer Town", City = "Chicago" };
                Supplier s3 = new Supplier { Name = "Chess Co", City = "New York" };

                Category c1 = new Category { Name = "Watersports" };
                Category c2 = new Category { Name = "Soccer" };
                Category c3 = new Category { Name = "Chess" };

                // Seed database with entities
                context.Products.AddRange(
                    new Product { Name = "Kayak", Price = 275, Supplier = s1, Category = c1 },
                    new Product { Name = "Lifejacket", Price = 48.95m, Supplier = s1, Category = c1 },
                    new Product { Name = "Soccer Ball", Price = 19.50m, Supplier = s2, Category = c2 },
                    new Product { Name = "Corner Flags", Price = 34.95m, Supplier = s2, Category = c2 },
                    new Product { Name = "Stadium", Price = 79500, Supplier = s2, Category = c2 },
                    new Product { Name = "Thinking Cap", Price = 16, Supplier = s3, Category = c3 },
                    new Product { Name = "Unsteady Chair", Price = 29.95m, Supplier = s3, Category = c3 },
                    new Product { Name = "Human Chess Board", Price = 75, Supplier = s3, Category = c3 },
                    new Product { Name = "Bling-Bling King", Price = 1200, Supplier = s3, Category = c3 });

                context.SaveChanges();
            }
        }
    }
}

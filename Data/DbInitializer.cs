using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bangazon.Models;

namespace BangazonWeb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BangazonContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonContext>>()))
            {
              // Look for any products.
              if (context.Product.Any())
              {
                  return;   // DB has been seeded
              }

              var customers = new Customer[]
              {
                  new Customer { 
                      FirstName = "Carson",
                      LastName = "Alexander",
                      StreetAddress = "100 Infinity Way"
                  },
                  new Customer { 
                      FirstName = "Steve",
                      LastName = "Brownlee",
                      StreetAddress = "92 Main Street"
                  },
                  new Customer { 
                      FirstName = "Tractor",
                      LastName = "Ryan",
                      StreetAddress = "1666 Catalina Blvd"
                  }
              };

              foreach (Customer c in customers)
              {
                  context.Customer.Add(c);
              }
              context.SaveChanges();

              var productTypes = new ProductType[]
              {
                  new ProductType { 
                      Label = "Electronics"
                  },
                  new ProductType { 
                      Label = "Appliances"
                  },
                  new ProductType { 
                      Label = "Housewares"
                  },
              };

              foreach (ProductType i in productTypes)
              {
                  context.ProductType.Add(i);
              }
              context.SaveChanges();


              var products = new Product[]
              {
                  new Product { 
                      Description = "Colorful throw pillows to liven up your home",
                      ProductTypeId = productTypes.Single(s => s.Label == "Housewares").ProductTypeId,
                      Title = "Throw Pillow",
                      Price = 7.49,
                      CustomerId = customers.Single(s => s.FirstName == "Tractor").CustomerId
                  },
                  new Product { 
                      Description = "A 2012 iPod Shuffle. Headphones are included. 16G capacity.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "iPod Shuffle",
                      Price = 18.00,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                  new Product { 
                      Description = "Stainless steel refrigerator. Three years old. Minor scratches.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Appliances").ProductTypeId,
                      Title = "Samsung refrigerator",
                      Price = 500.00,
                      CustomerId = customers.Single(s => s.FirstName == "Carson").CustomerId
                  }
              };

              foreach (Product i in products)
              {
                  context.Product.Add(i);
              }
              context.SaveChanges();
          }
       }
    }
}
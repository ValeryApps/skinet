using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
   public class StoreContextSeed
   {
      public static async Task SeedAsync(StoreContext context, ILoggerFactory logger)
      {
         try
         {


            if (!context.ProductBrands.Any())
            {
               var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
               var brands = JsonConvert.DeserializeObject<List<ProductBrand>>(brandData);
               foreach (var item in brands)
               {
                  context.ProductBrands.Add(item);
               }
               await context.SaveChangesAsync();
            }
            if (!context.ProductTypes.Any())
            {
               var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
               var types = JsonConvert.DeserializeObject<List<ProductType>>(typeData);
               foreach (var item in types)
               {
                  context.ProductTypes.Add(item);
               }
               await context.SaveChangesAsync();
            }
            if (!context.Products.Any())
            {
               var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
               var products = JsonConvert.DeserializeObject<List<Product>>(productData);
               foreach (var item in products)
               {
                  context.Products.Add(item);
               }
               await context.SaveChangesAsync();
            }

         }
         catch (System.Exception ex)
         {
            var log = logger.CreateLogger<StoreContextSeed>();
            log.LogError(ex.Message);
         }
      }

   }
}
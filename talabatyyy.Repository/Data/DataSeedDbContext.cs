using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using talabatyyyy.Core.Entities;

namespace talabatyyy.Repository.Data
{
    public static class DataSeedDbContext 
    {
        public static async Task SeedAsync (ApplicationDbContext context)
        {
            #region ProductBrands
            if (!context.ProductBrands.Any())
            {
                var brandspath = File.ReadAllText("../talabatyyy.Repository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandspath);
                if (brands?.Count>0 )
                {
                    foreach (var brand in brands)
                    {
                        await context.ProductBrands.AddAsync(brand);
                        await context.SaveChangesAsync();
                    }
                }
              
            }
            #endregion

            #region ProductTypes

            if (!context.ProductTypes.Any())
            {
                var productTypeFile = File.ReadAllText("../talabatyyy.Repository/Data/DataSeed/types.json");
                var productTypesList = JsonSerializer.Deserialize<List<ProductType>>(productTypeFile);
                if (productTypesList?.Count > 0)
                {
                    foreach (var type in productTypesList)
                    {
                        await context.ProductTypes.AddAsync(type);
                        await context.SaveChangesAsync();
                    }
                }
            }
            #endregion


            #region Products

            if (!context.Products.Any())
            {
                var productsFile = File.ReadAllText("../talabatyyy.Repository/Data/DataSeed/products.json");
                var productsList = JsonSerializer.Deserialize<List<Product>>(productsFile);
                if (productsList?.Count > 0)
                {
                    foreach (var product in productsList)
                    {
                        await context.Products.AddAsync(product);
                        await context.SaveChangesAsync();
                    }
                }
            }
            #endregion
        }
    }
}

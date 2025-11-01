using ECommerce.Domain.Contracts.Seeds;
using ECommerce.Domain.Model.ProductModels;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Seeds
{
    public class DataSeeding : IDataSeeding
    {
        private readonly StoreDbContext context;

        public DataSeeding(StoreDbContext context)
        {
            this.context = context;
        }
        public async Task DataSeedAsync()
        {
            var PendingMigrations = await context.Database.GetPendingMigrationsAsync();
            if (PendingMigrations.Any())
            {
                context.Database.Migrate();
            }

            if (!context.ProductBrands.Any())
            {
                var ProductBrandsData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerce.Persistence\Data\brands.json");
                var ProductBrands = JsonSerializer.Deserialize<List<ProductBrand>>(ProductBrandsData);

                if (ProductBrands != null && ProductBrands.Any())
                {
                    context.ProductBrands.AddRange(ProductBrands);
                }

            }

            if (!context.ProductTypes.Any())
            {
                var ProductTypesData = await File.ReadAllTextAsync(@"..\Infrastructure\ECommerce.Persistence\Data\types.json");
                var ProductTypes = JsonSerializer.Deserialize<List<ProductType>>(ProductTypesData);
                if (ProductTypes != null && ProductTypes.Any())
                {
                    context.ProductTypes.AddRange(ProductTypes);

                }

            }

            if (!context.Products.Any())
            {
                var ProductsData =await File.ReadAllTextAsync(@"..\Infrastructure\ECommerce.Persistence\Data\products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (Products != null && Products.Any()) { context.Products.AddRange(Products); }
            }

            context.SaveChanges();
        }
    }
}

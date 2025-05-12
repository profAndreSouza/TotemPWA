using System.Text.Json;
using TotemPWA.Models;

namespace TotemPWA.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            if (context.Categories.Any())
                return;

            var json = await File.ReadAllTextAsync("Data/SeedData.json");

            var rootCategories = JsonSerializer.Deserialize<List<CategorySeed>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (rootCategories != null)
            {
                foreach (var categorySeed in rootCategories)
                {
                    await CreateCategoryRecursiveAsync(context, categorySeed, parentId: null);
                }

                await context.SaveChangesAsync();
            }
        }

        private static async Task CreateCategoryRecursiveAsync(ApplicationDbContext context, CategorySeed seed, int? parentId)
        {
            var category = new Category
            {
                Name = seed.Name,
                ParentCategoryId = parentId
            };

            context.Categories.Add(category);
            await context.SaveChangesAsync(); // necessário para obter o Id da categoria

            // Cria os produtos da categoria
            foreach (var productSeed in seed.Products ?? new List<ProductSeed>())
            {
                var product = new Product
                {
                    Name = productSeed.Name,
                    Price = productSeed.Price,
                    CategoryId = category.Id
                };

                context.Products.Add(product);
                await context.SaveChangesAsync(); // necessário para obter o Id do produto

                foreach (var variationSeed in productSeed.Variations ?? new List<VariationSeed>())
                {
                    var variation = new Variation
                    {
                        Description = variationSeed.Description,
                        AdditionalPrice = variationSeed.AdditionalPrice,
                        ProductId = product.Id
                    };

                    context.Variations.Add(variation);
                }
            }

            // Recursivamente cria subcategorias
            foreach (var subcategorySeed in seed.Subcategories ?? new List<CategorySeed>())
            {
                await CreateCategoryRecursiveAsync(context, subcategorySeed, category.Id);
            }
        }
    }
}

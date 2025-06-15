# Outras Técnicas Diversas

## O que são *Slugs*

### Definição:

Um **slug** é uma versão "amigável para URLs" de uma string, geralmente utilizada para criar URLs limpas, legíveis e otimizadas para SEO. Em geral, os slugs:

* Usam **letras minúsculas**
* **Substituem espaços por hífens (-)**
* **Removem caracteres especiais**

### Exemplo prático:

Se você tem uma categoria chamada:

```
"Refrigerantes & Bebidas"
```

O slug correspondente seria:

```
"refrigerantes-bebidas"
```

Se você quiser acessar os produtos dessa categoria via URL, uma rota como:

```
/categoria/refrigerantes-bebidas
```

é muito mais legível e profissional do que:

```
/categoria/5
```

### Como é usado em sistemas:

* Para identificar recursos por nome (em vez de ID)
* Para melhorar o SEO
* Para criar links permanentes (permalinks)

---

### Exemplo Model `Category.cs`

```csharp
using System.Text.RegularExpressions;

public class Category
{
    public int Id { get; set; }

    private string _name;

    public required string Name
    {
        get => _name;
        set
        {
            _name = value;
            Slug = GenerateSlug(value);
        }
    }

    public string Slug { get; set; }

    private string GenerateSlug(string text)
    {
        text = text.ToLowerInvariant().Trim();                         // Converte para minúsculas e remove espaços no início/fim
        text = Regex.Replace(text, @"[^a-z0-9\s-]", "");               // Remove caracteres especiais
        text = Regex.Replace(text, @"\s+", "-");                       // Substitui espaços por hífens
        text = Regex.Replace(text, @"-+", "-");                        // Remove múltiplos hífens consecutivos
        return text;
    }
}
```

```csharp
var category = new Category { Name = "Refrigerantes & Bebidas" };
Console.WriteLine(category.Slug); // Saída: "refrigerantes-bebidas"
```


## O que são *Seeders*

### Definição:

**Seeders** são scripts ou métodos usados para **popular automaticamente o banco de dados com dados iniciais**. Eles são úteis para:

* Testes
* Demonstrações
* Configuração inicial de ambientes

---

## Seeder `DbInitializer.cs`

```csharp
using System.Text.Json;                   // Importa o namespace para manipulação de JSON
using TotemPWA.Models;                    // Importa os modelos usados no banco

namespace TotemPWA.Data
{
    // Define uma classe estática para inicializar o banco de dados com dados
    public static class DbInitializer
    {
        // Método público e assíncrono que inicializa o banco com dados
        public static async Task InitializeAsync(AppDbContext context)
        {
            // Verifica se já existem categorias no banco. Se sim, sai do método (evita duplicação).
            if (context.Categories.Any())
                return;

            // Lê o conteúdo do arquivo JSON com os dados iniciais
            var json = await File.ReadAllTextAsync("Data/SeedData.json");

            // Desserializa o JSON em uma lista de CategorySeed, ignorando diferenciação entre maiúsculas e minúsculas nos nomes das propriedades
            var rootCategories = JsonSerializer.Deserialize<List<CategorySeed>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Se houver categorias no JSON...
            if (rootCategories != null)
            {
                // Para cada categoria raiz, chama método recursivo para inserir ela e seus filhos
                foreach (var categorySeed in rootCategories)
                {
                    await CreateCategoryRecursiveAsync(context, categorySeed, parentId: null);
                }

                // Salva todas as alterações feitas no banco de dados
                await context.SaveChangesAsync();
            }
        }

        // Método recursivo que insere uma categoria e seus produtos, variações e subcategorias
        private static async Task CreateCategoryRecursiveAsync(AppDbContext context, CategorySeed seed, int? parentId)
        {
            // Cria uma nova categoria com base no dado do seed
            var category = new Category
            {
                Name = seed.Name,
                ParentCategoryId = parentId // Define a categoria pai (caso exista)
            };

            context.Categories.Add(category);         // Adiciona a categoria ao contexto
            await context.SaveChangesAsync();         // Salva para gerar o ID da categoria (necessário para usar como FK)

            // Cria os produtos da categoria
            foreach (var productSeed in seed.Products ?? new List<ProductSeed>())
            {
                var product = new Product
                {
                    Name = productSeed.Name,
                    Price = productSeed.Price,
                    CategoryId = category.Id  // Define qual categoria esse produto pertence
                };

                context.Products.Add(product);       // Adiciona o produto ao contexto
                await context.SaveChangesAsync();    // Salva para obter o ID do produto

                // Adiciona as variações do produto
                foreach (var variationSeed in productSeed.Variations ?? new List<VariationSeed>())
                {
                    var variation = new Variation
                    {
                        Description = variationSeed.Description,
                        AdditionalPrice = variationSeed.AdditionalPrice,
                        ProductId = product.Id      // Associa a variação ao produto
                    };

                    context.Variations.Add(variation); // Adiciona a variação ao contexto
                }
            }

            // Cria subcategorias de forma recursiva (caso existam)
            foreach (var subcategorySeed in seed.Subcategories ?? new List<CategorySeed>())
            {
                await CreateCategoryRecursiveAsync(context, subcategorySeed, category.Id);
            }
        }
    }
}
```

---

### Resumo:

* **Slug**: string legível usada em URLs, como `"csharp-burger"` ao invés de `"C# Burger"`.
* **Seeder**: rotina para popular automaticamente o banco de dados com dados iniciais.
* O método `InitializeAsync` carrega dados de um arquivo JSON e usa o método recursivo `CreateCategoryRecursiveAsync` para inserir categorias, produtos e variações no banco de dados de forma organizada.
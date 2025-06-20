# Conceitos de OOP na Prática com ASP.NET Core MVC

## 1. **Encapsulamento**

Encapsulamento é a prática de esconder os detalhes internos de uma classe, expondo apenas o necessário.

### Vantagens:

* Protege o estado interno do objeto.
* Controla o acesso e garante validação.
* Reduz efeitos colaterais externos.

### Exemplo prático:

```csharp
public class Produto
{
    private decimal _preco;

    public decimal Preco
    {
        get => _preco;
        set
        {
            if (value >= 0)
                _preco = value;
        }
    }
}
```

Aplicado também no `Controller`, onde o campo `_context` encapsula o acesso ao banco de dados.

---

## 2. **Acoplamento**

Refere-se ao grau de dependência entre classes.

### Tipos:

* **Forte (tight coupling):** classes altamente dependentes — difícil de manter e testar.
* **Fraco (loose coupling):** menor dependência — facilita a manutenção, reuso e testes.

### Exemplo com acoplamento forte:

```csharp
public class PedidoService
{
    private ProdutoRepository _repo = new ProdutoRepository();
}
```

### Exemplo com acoplamento fraco (ideal):

```csharp
public class PedidoService
{
    private readonly IProdutoRepository _repo;

    public PedidoService(IProdutoRepository repo)
    {
        _repo = repo;
    }
}
```

O uso de **interfaces** reduz o acoplamento e favorece testes com mocks.

---

## 3. **Injeção de Dependência (DI)**

É a técnica de fornecer dependências externas para uma classe — normalmente via construtor.

### ASP.NET Core:

O framework gerencia isso automaticamente via container de serviços.

```csharp
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
}
```

Reduz acoplamento, melhora testes unitários e segue o princípio da **Inversão de Controle (IoC)**.

---

## 4. **Abstração**

Permite representar conceitos complexos de forma simplificada.

### Exemplo:

Controllers utilizam abstrações:

* `ILogger` (sem saber como ele grava logs).
* `DbContext` (sem saber como o banco armazena dados).

---

## 5. **Herança**

Permite que uma classe herde comportamentos de outra.

```csharp
public class CategoryController : ControllerBase
```

`CategoryController` herda de `ControllerBase`, ganhando métodos como `Ok()`, `BadRequest()`, etc.

---

## 6. **Polimorfismo**

Permite que métodos tenham comportamentos diferentes dependendo do contexto.

### Exemplo:

```csharp
return Ok(produto);
return NotFound();
```

`Ok()` e `NotFound()` são métodos herdados que retornam diferentes tipos de resposta HTTP.

---

## **Resumo: Vantagens Combinadas da OOP com ASP.NET Core**

| Conceito                   | Aplicação prática                                  |
| -------------------------- | -------------------------------------------------- |
| **Encapsulamento**         | Protege dados no banco, regras nos models          |
| **Abstração**              | Usa interfaces, logger e DbContext sem detalhes    |
| **Herança**                | Controllers herdam de ControllerBase ou Controller |
| **Polimorfismo**           | Métodos como `Ok()`, `BadRequest()` etc.           |
| **Acoplamento Fraco**      | Controllers não conhecem detalhes das dependências |
| **Injeção de Dependência** | Permite testes e modularização                     |

---

# Controllers em ASP.NET Core MVC

## O que são Controllers?

**Controllers** são componentes centrais no padrão **MVC (Model-View-Controller)**. Eles atuam como **intermediários** entre a **lógica de negócio (Models)** e a **interface do usuário (Views)**.

> Em resumo, o controller **recebe a requisição**, **processa os dados** (geralmente usando Models), e **retorna uma resposta** (normalmente uma View ou JSON).

---

### Estrutura MVC

* **Model**: representa os dados e regras de negócio.
* **View**: a interface visual (HTML, Razor).
* **Controller**: coordena tudo — recebe input, processa e retorna resposta.

---

## Aspectos de Orientação a Objetos no Controller

* A classe `HomeController` herda da classe base `Controller` → exemplo de **herança**.
* Usa **injeção de dependência** para receber o `ApplicationDbContext` e o `ILogger` → promove **baixo acoplamento** e **encapsulamento**.
* Os métodos públicos (`Index`, `Menu`, `Error`) são ações chamadas pelas rotas → comportamento da classe.

---

## Controller: `HomeController`

```csharp
// Importa funcionalidades básicas do sistema
using System.Diagnostics;
// Importa recursos do ASP.NET MVC, incluindo Controller e IActionResult
using Microsoft.AspNetCore.Mvc;
// Importa suporte para consultas assíncronas com Entity Framework Core
using Microsoft.EntityFrameworkCore;
// Importa contexto de banco de dados da aplicação
using TotemPWA.Data;
// Importa os modelos usados no sistema
using TotemPWA.Models;

// Define o namespace do controller
namespace TotemPWA.Controllers;

// Declara a classe HomeController, que herda da base Controller (MVC)
public class HomeController : Controller
{
    // Campo para logging de eventos e erros
    private readonly ILogger<HomeController> _logger;

    // Campo para acesso ao banco de dados via Entity Framework
    private readonly ApplicationDbContext _context;

    // Construtor com injeção de dependências para o logger e o contexto do banco
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    // Ação padrão que retorna a view inicial da aplicação
    public IActionResult Index()
    {
        return View();
    }

    // Define rota personalizada com parâmetros opcionais: /Menu/{categoryId}/{subcategoryId}
    [HttpGet("Menu/{categoryId:int?}/{subcategoryId:int?}")]
    public async Task<IActionResult> Menu(int? categoryId, int? subcategoryId)
    {
        // Busca categorias raiz (sem categoria pai)
        var rootCategoriesRaw = await _context.Categories
            .Where(c => c.ParentCategoryId == null)
            .ToListAsync();

        // Se não houver categoryId fornecido, usa o primeiro como ativo
        var activeCategoryId = categoryId ?? rootCategoriesRaw.FirstOrDefault()?.Id;

        // Mapeia as categorias raiz para um formato com indicação de qual está ativa
        var rootCategories = rootCategoriesRaw
            .Select(c => new
            {
                id = c.Id,
                name = c.Name,
                active = c.Id == activeCategoryId
            })
            .ToList();

        // Busca subcategorias da categoria ativa
        var subcategoriesRaw = await _context.Categories
            .Where(c => c.ParentCategoryId == activeCategoryId)
            .ToListAsync();

        // Determina subcategoria ativa, se existir
        var activeSubcategoryId = subcategoriesRaw.Any(c => c.Id == subcategoryId)
            ? subcategoryId
            : subcategoriesRaw.FirstOrDefault()?.Id;

        // Mapeia subcategorias com marcação de qual está ativa
        var subcategories = subcategoriesRaw
            .Select(c => new
            {
                id = c.Id,
                name = c.Name,
                active = c.Id == activeSubcategoryId
            })
            .ToList();

        // Busca produtos da subcategoria ativa
        var products = await _context.Products
            .Where(p => p.CategoryId == activeSubcategoryId)
            .Select(p => new
            {
                id = p.Id,
                name = p.Name,
                price = p.Price
            })
            .ToListAsync();

        // Envia dados para a View via ViewBag (dinâmico)
        ViewBag.Category = categoryId;
        ViewBag.Categories = rootCategories;
        ViewBag.SubCategories = subcategories;
        ViewBag.Products = products;

        // Retorna a view associada ao método Menu
        return View();
    }

    // Ação para tratamento de erros com configuração para não cachear a resposta
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // Cria uma instância do modelo de erro com o ID da requisição atual
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
```

---

## Observações

* O padrão `MVC` facilita a separação de responsabilidades: lógica no Controller, dados no Model, interface na View.
* A injeção de dependência torna o código mais testável e desacoplado.
* `ViewBag` é uma forma dinâmica de passar dados da controller para a view (não tipada).
* O uso de `async/await` permite que o sistema responda a múltiplas requisições de forma eficiente (programação assíncrona).
* A rota `[HttpGet("Menu/{categoryId:int?}/{subcategoryId:int?}")]` facilita URLs amigáveis.

---

## `CategoryController`

```csharp
using Microsoft.AspNetCore.Mvc; // Usado para anotações e classes do ASP.NET Core MVC.
using Microsoft.EntityFrameworkCore; // Fornece métodos para manipular o banco via Entity Framework.
using TotemPWA.Data; // Namespace onde está o contexto do banco de dados.
using TotemPWA.Models; // Importa os modelos (Category, Product, Variation) usados neste controller.


namespace TotemPWA.Controllers // Define o namespace da aplicação.
{
    [ApiController] // Indica que este controller trata requisições de API (valida inputs automaticamente).
    [Route("api/[controller]")] // Define a rota base como "api/Category".
    public class CategoryController : ControllerBase // Herda de ControllerBase (polimorfismo).
    {
        private readonly ApplicationDbContext _context; // Campo privado para acessar o banco de dados (encapsulamento).


        public CategoryController(ApplicationDbContext context) // Construtor com injeção de dependência.
        {
            _context = context;
        }


        [HttpGet] // GET: api/Category
        public async Task<ActionResult<IEnumerable<Category>>> GetAll() // Retorna todas as categorias raiz com subcategorias, produtos e variações.
        {
            return await _context.Categories
                .Where(c => c.ParentCategoryId == null) // Apenas categorias sem pai.
                .Include(c => c.Subcategories) // Inclui subcategorias.
                    .ThenInclude(sc => sc.Products) // Inclui produtos das subcategorias.
                        .ThenInclude(p => p.Variations) // Inclui variações dos produtos.
                .Include(c => c.Products) // Inclui produtos diretamente ligados à categoria.
                    .ThenInclude(p => p.Variations) // Inclui variações desses produtos.
                .ToListAsync(); // Executa a query.
        }


        [HttpGet("{id}")] // GET: api/Category/5
        public async Task<ActionResult<Category>> Get(int id) // Retorna categoria específica com subcategorias.
        {
            var category = await _context.Categories
                .Include(c => c.Subcategories)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound(); // Se não encontrar, retorna 404.
            return category;
        }


        [HttpPost] // POST: api/Category
        public async Task<ActionResult<Category>> Create(Category category) // Cria nova categoria.
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category); // Retorna 201 com local do novo recurso.
        }


        [HttpPut("{id}")] // PUT: api/Category/5
        public async Task<IActionResult> Update(int id, Category category) // Atualiza categoria existente.
        {
            if (id != category.Id) return BadRequest(); // Validação da consistência de IDs.

            _context.Entry(category).State = EntityState.Modified; // Marca como modificado.
            await _context.SaveChangesAsync();
            return NoContent(); // Retorna 204 (sem conteúdo).
        }


        [HttpDelete("{id}")] // DELETE: api/Category/5
        public async Task<IActionResult> Delete(int id) // Remove categoria.
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
```

---

## `ProductController`

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;


namespace TotemPWA.Controllers
{
    [ApiController] // Este controller é uma API REST.
    [Route("api/[controller]")] // Rota base: api/Product
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Campo injetado via construtor.


        public ProductController(ApplicationDbContext context) // Injeção de dependência (encapsulamento + inversão de controle).
        {
            _context = context;
        }


        [HttpGet] // GET: api/Product
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() // Retorna todos os produtos.
        {
            return await _context.Products
                .Include(p => p.Variations) // Inclui variações de cada produto.
                .Include(p => p.Category) // Inclui a categoria do produto.
                .ToListAsync();
        }


        [HttpGet("{id}")] // GET: api/Product/5
        public async Task<ActionResult<Product>> Get(int id) // Retorna um produto específico.
        {
            var product = await _context.Products
                .Include(p => p.Variations)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();
            return product;
        }


        [HttpPost] // POST: api/Product
        public async Task<ActionResult<Product>> Create(Product product) // Cria um novo produto.
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }


        [HttpPut("{id}")] // PUT: api/Product/5
        public async Task<IActionResult> Update(int id, Product product) // Atualiza produto existente.
        {
            if (id != product.Id) return BadRequest();

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")] // DELETE: api/Product/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products
                .Include(p => p.Variations) // Inclui as variações para excluir também.
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            _context.Variations.RemoveRange(product.Variations); // Remove variações primeiro.
            _context.Products.Remove(product); // Depois remove o produto.
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPost("{productId}/Variation")] // POST: api/Product/{productId}/Variation
        public async Task<ActionResult<Variation>> AddVariation(int productId, Variation variation) // Adiciona variação a um produto.
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return NotFound();

            variation.ProductId = productId;
            _context.Variations.Add(variation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = productId }, variation);
        }
    }
}
```


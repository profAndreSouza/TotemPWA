using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.ViewModels;



namespace TotemPWA.Controllers.Totem
{
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;


        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Menu/{categorySlug?}/{subcategorySlug?}")]
        public async Task<IActionResult> Menu(string? categorySlug, string? subcategorySlug)
        {
            // 1. Buscar categorias raiz
            var rootCategoriesRaw = await _context.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToListAsync();

            // 2. Slug da categoria ativa (primeira se não especificado)
            var activeCategorySlug = categorySlug ?? rootCategoriesRaw.FirstOrDefault()?.Slug;

            // 3. Montar categorias raiz para o ViewModel
            var rootCategories = rootCategoriesRaw
                .Select(c => new CategoryItemViewModel
                {
                    Name = c.Name,
                    Slug = c.Slug,
                    Icon = c.Icon,
                    Active = c.Slug == activeCategorySlug
                })
                .ToList();

            // 4. Buscar ID da categoria ativa
            var activeCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Slug == activeCategorySlug && c.ParentCategoryId == null);

            if (activeCategory == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            // 5. Buscar subcategorias com base na categoria ativa
            var subcategoriesRaw = await _context.Categories
                .Where(c => c.ParentCategoryId == activeCategory.Id)
                .ToListAsync();

            // 6. Slug da subcategoria ativa
            var activeSubcategorySlug = subcategoriesRaw.Any(c => c.Slug == subcategorySlug)
                ? subcategorySlug
                : subcategoriesRaw.FirstOrDefault()?.Slug;

            // 7. Montar subcategorias para o ViewModel
            var subcategories = subcategoriesRaw
                .Select(c => new CategoryItemViewModel
                {
                    Name = c.Name,
                    Slug = c.Slug,
                    Icon = c.Icon,
                    Active = c.Slug == activeSubcategorySlug
                })
                .ToList();

            // 8. Buscar produtos da subcategoria ativa
            var activeSubcategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Slug == activeSubcategorySlug && c.ParentCategoryId == activeCategory.Id);

            var products = activeSubcategory != null
                ? await _context.Products
                    .Where(p => p.CategoryId == activeSubcategory.Id)
                    .Select(p => new ProductItemViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Image = p.Image
                    })
                    .ToListAsync()
                : new List<ProductItemViewModel>();

            // 9. Criar ViewModel final
            var viewModel = new MenuViewModel
            {
                SelectedCategorySlug = activeCategorySlug,
                SelectedSubcategorySlug = activeSubcategorySlug,
                RootCategories = rootCategories,
                Subcategories = subcategories,
                Products = products
            };

            return View(viewModel);
        }


    }

}

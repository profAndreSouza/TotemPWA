using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;


    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("Menu/{categoryId:int?}/{subcategoryId:int?}")]
    // [HttpGet]
    public async Task<IActionResult> Menu(int? categoryId, int? subcategoryId)
    {
        var rootCategoriesRaw = await _context.Categories
            .Where(c => c.ParentCategoryId == null)
            .ToListAsync();

        var activeCategoryId = categoryId ?? rootCategoriesRaw.FirstOrDefault()?.Id;

        var rootCategories = rootCategoriesRaw
            .Select(c => new
            {
                id = c.Id,
                name = c.Name,
                icon = c.Icon,
                active = c.Id == activeCategoryId
            })
            .ToList();

        var subcategoriesRaw = await _context.Categories
            .Where(c => c.ParentCategoryId == activeCategoryId)
            .ToListAsync();

        var activeSubcategoryId = subcategoriesRaw.Any(c => c.Id == subcategoryId)
            ? subcategoryId
            : subcategoriesRaw.FirstOrDefault()?.Id;

        var subcategories = subcategoriesRaw
            .Select(c => new
            {
                id = c.Id,
                name = c.Name,
                icon = c.Icon,
                active = c.Id == activeSubcategoryId
            })
            .ToList();

        var products = await _context.Products
            .Where(p => p.CategoryId == activeSubcategoryId)
            .Select(p => new
            {
                id = p.Id,
                name = p.Name,
                price = p.Price
            })
            .ToListAsync();

        ViewBag.Category = categoryId;
        ViewBag.Categories = rootCategories;
        ViewBag.SubCategories = subcategories;
        ViewBag.Products = products;

        return View();
        // return Ok(new {
        //     rootCategories,
        //     subcategories,
        //     products
        // });
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

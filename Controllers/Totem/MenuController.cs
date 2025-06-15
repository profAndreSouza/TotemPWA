using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Totem
{
    [ApiController]
    [Route("api/totem/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context) => _context = context;

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories
                .Include(c => c.Products)
                .ToList();

            return Ok(categories);
        }

        [HttpGet("products/{slug}")]
        public IActionResult GetProducts(string slug)
        {
            var category = _context.Categories
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Slug == slug);

            return category == null ? NotFound() : Ok(category.Products);
        }
    }
    
}

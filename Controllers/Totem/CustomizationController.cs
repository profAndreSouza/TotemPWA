using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Totem
{

    [ApiController]
    [Route("api/totem/[controller]")]
    public class CustomizationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomizationController(AppDbContext context) => _context = context;

        [HttpGet("ingredients/{productId}")]
        public IActionResult GetIngredients(int productId)
        {
            var ingredients = _context.Additionals
                .Where(a => a.ProductId == productId)
                .Include(a => a.Ingredient)
                .Select(a => a.Ingredient)
                .ToList();

            return Ok(ingredients);
        }

        [HttpPost("apply")]
        public IActionResult ApplyCustomization([FromBody] Customize customize)
        {
            _context.Customizations.Add(customize);
            _context.SaveChanges();
            return Ok(customize);
        }
    }

}

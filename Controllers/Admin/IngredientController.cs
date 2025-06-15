// ProductController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Admin
{
    [ApiController]
    [Route("admin/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List() => Ok(await _context.Ingredients.ToListAsync());

        [HttpPost("create")]
        public async Task<IActionResult> Create(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return Ok(ingredient);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, Ingredient updated)
        {
            var ingr = await _context.Ingredients.FindAsync(id);
            if (ingr == null) return NotFound();

            ingr.Name = updated.Name;
            ingr.Price = updated.Price;
            ingr.Limit = updated.Limit;

            await _context.SaveChangesAsync();
            return Ok(ingr);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ingr = await _context.Ingredients.FindAsync(id);
            if (ingr == null) return NotFound();

            _context.Ingredients.Remove(ingr);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}

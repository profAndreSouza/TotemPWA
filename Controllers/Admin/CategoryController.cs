using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            var categories = _context.Categories
                .Include(c => c.Subcategories)
                .ToList();

            return Ok(categories);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpPut("edit/{id}")]
        public IActionResult Edit(int id, [FromBody] Category updated)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            category.Name = updated.Name;
            category.Icon = updated.Icon;
            category.ParentCategoryId = updated.ParentCategoryId;

            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

// ProductController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Admin
{
    
    [ApiController]
    [Route("admin/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PromotionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List() => Ok(await _context.Promotions.Include(p => p.Product).ToListAsync());

        [HttpPost("create")]
        public async Task<IActionResult> Create(Promotion promotion)
        {
            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();
            return Ok(promotion);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, Promotion updated)
        {
            var promo = await _context.Promotions.FindAsync(id);
            if (promo == null) return NotFound();

            promo.ProductId = updated.ProductId;
            promo.Percent = updated.Percent;
            promo.ValidUntil = updated.ValidUntil;

            await _context.SaveChangesAsync();
            return Ok(promo);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var promo = await _context.Promotions.FindAsync(id);
            if (promo == null) return NotFound();

            _context.Promotions.Remove(promo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}

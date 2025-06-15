// ProductController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Admin
{
    [ApiController]
    [Route("admin/[controller]")]
    public class CupomController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CupomController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List() => Ok(await _context.Cupons.ToListAsync());

        [HttpPost("generate")]
        public async Task<IActionResult> Generate(Cupom cupom)
        {
            _context.Cupons.Add(cupom);
            await _context.SaveChangesAsync();
            return Ok(cupom);
        }

        [HttpDelete("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            var cupom = await _context.Cupons.FindAsync(id);
            if (cupom == null) return NotFound();

            _context.Cupons.Remove(cupom);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}

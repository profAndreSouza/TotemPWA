// ProductController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Admin
{
    [Route("admin/[controller]")]
    public class OrderAdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderAdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List() => Ok(await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Items)
            .ThenInclude(oi => oi.Product)
            .ToListAsync());

        [HttpPut("update-status/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            order.Status = status;
            await _context.SaveChangesAsync();
            return Ok(order);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Totem
{
    [ApiController]
    [Route("api/totem/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context) => _context = context;

        [HttpPost("add")]
        public IActionResult AddItem([FromBody] OrderItem item)
        {
            _context.OrderItems.Add(item);
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateItem(int id, [FromBody] OrderItem updated)
        {
            var item = _context.OrderItems.Find(id);
            if (item == null) return NotFound();

            item.Quantity = updated.Quantity;
            item.UnitPrice = updated.UnitPrice;
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete("remove/{id}")]
        public IActionResult RemoveItem(int id)
        {
            var item = _context.OrderItems.Find(id);
            if (item == null) return NotFound();

            _context.OrderItems.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }

}

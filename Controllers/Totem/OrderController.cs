using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Totem
{
    [ApiController]
    [Route("api/totem/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context) => _context = context;

        [HttpPost("apply-cupom")]
        public IActionResult ApplyCupom(int orderId, string code)
        {
            var order = _context.Orders.Find(orderId);
            var cupom = _context.Cupons.FirstOrDefault(c => c.Code == code);
            if (order == null || cupom == null) return NotFound();

            order.CupomId = cupom.Id;
            _context.SaveChanges();
            return Ok(order);
        }

        [HttpPost("set-delivery")] 
        public IActionResult SetDeliveryType(int orderId, string type)
        {
            var order = _context.Orders.Find(orderId);
            if (order == null) return NotFound();

            order.Status = type;
            _context.SaveChanges();
            return Ok(order);
        }

        [HttpPost("finalize")]
        public IActionResult FinalizeOrder([FromBody] Order order)
        {
            order.Date = DateTime.UtcNow;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }
    }

}

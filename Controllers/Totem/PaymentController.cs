using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Totem
{
    [ApiController]
    [Route("api/totem/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PaymentController(AppDbContext context) => _context = context;

        [HttpPost("process")]
        public IActionResult ProcessPayment([FromBody] Payment payment)
        {
            payment.Status = "confirmed";
            _context.Payments.Add(payment);
            _context.SaveChanges();
            return Ok(payment);
        }
    }
}

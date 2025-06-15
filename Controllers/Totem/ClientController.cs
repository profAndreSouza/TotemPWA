using Microsoft.AspNetCore.Mvc;
using TotemPWA.Models;
using TotemPWA.Data;

namespace TotemPWA.Controllers.Totem
{
    [ApiController]
    [Route("api/totem/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Client clientData)
        {
            if (_context.Clients.Any(c => c.CPF == clientData.CPF))
                return Conflict("CPF já cadastrado.");

            _context.Clients.Add(clientData);
            _context.SaveChanges();
            return Ok(clientData);
        }
    }
}

// ProductController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Admin
{
    [ApiController]
    [Route("admin/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List() => Ok(await _context.Employees.Include(e => e.Client).ToListAsync());

        [HttpPost("register")]
        public async Task<IActionResult> Register(Client client, Employee employee)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            employee.ClientId = client.Id;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(new { client, employee });
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, Employee updated)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();

            emp.Type = updated.Type;
            emp.User = updated.User;
            emp.Password = updated.Password;

            await _context.SaveChangesAsync();
            return Ok(emp);
        }

        [HttpDelete("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Admin
{
    public class CupomController : Controller
    {
        private readonly AppDbContext _context;

        public CupomController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            var cupons = await _context.Cupons.ToListAsync();
            return View(cupons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cupom cupom)
        {
            if (!ModelState.IsValid) return View(cupom);

            _context.Cupons.Add(cupom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cupom = await _context.Cupons.FindAsync(id);
            if (cupom == null) return NotFound();

            return View(cupom);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cupom cupom)
        {
            if (id != cupom.Id) return BadRequest();
            if (!ModelState.IsValid) return View(cupom);

            try
            {
                _context.Update(cupom);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cupons.Any(c => c.Id == id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cupom = await _context.Cupons.FindAsync(id);
            if (cupom == null) return NotFound();

            return View(cupom);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cupom = await _context.Cupons.FindAsync(id);
            if (cupom == null) return NotFound();

            _context.Cupons.Remove(cupom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}

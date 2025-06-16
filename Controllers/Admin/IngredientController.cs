using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;

namespace TotemPWA.Controllers.Admin
{
    public class IngredientController : Controller
    {
        private readonly AppDbContext _context;

        public IngredientController(AppDbContext context)
        {
            _context = context;
        }

        // GET: admin/Ingredient/List
        public async Task<IActionResult> List()
        {
            var ingredients = await _context.Ingredients.ToListAsync();
            return View(ingredients);
        }

        // GET: admin/Ingredient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Ingredient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ingredient ingredient)
        {
            if (!ModelState.IsValid) return View(ingredient);

            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        // GET: admin/Ingredient/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null) return NotFound();

            return View(ingredient);
        }

        // POST: admin/Ingredient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ingredient ingredient)
        {
            if (id != ingredient.Id) return BadRequest();
            if (!ModelState.IsValid) return View(ingredient);

            try
            {
                _context.Update(ingredient);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Ingredients.Any(i => i.Id == id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(List));
        }

        // GET: admin/Ingredient/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ingredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
            if (ingredient == null) return NotFound();

            return View(ingredient);
        }

        // POST: admin/Ingredient/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null) return NotFound();

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}

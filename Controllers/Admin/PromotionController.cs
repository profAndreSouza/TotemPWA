using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;
using TotemPWA.Models;
using TotemPWA.ViewModels;

namespace TotemPWA.Controllers.Admin
{
    public class PromotionController : Controller
    {
        private readonly AppDbContext _context;

        public PromotionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List()
        {
            var promotions = await _context.Promotions.Include(p => p.Product).ToListAsync();
            return View(promotions);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new PromotionViewModel
            {
                Products = await GetProductSelectListAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PromotionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Products = await GetProductSelectListAsync();
                return View(model);
            }

            var promotion = new Promotion
            {
                ProductId = model.ProductId,
                Percent = model.Percent,
                ValidUntil = model.ValidUntil
            };

            _context.Promotions.Add(promotion);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var promo = await _context.Promotions.FindAsync(id);
            if (promo == null) return NotFound();

            var viewModel = new PromotionViewModel
            {
                Id = promo.Id,
                ProductId = promo.ProductId,
                Percent = promo.Percent,
                ValidUntil = promo.ValidUntil,
                Products = await GetProductSelectListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PromotionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Products = await GetProductSelectListAsync();
                return View(model);
            }

            var promo = await _context.Promotions.FindAsync(model.Id);
            if (promo == null) return NotFound();

            promo.ProductId = model.ProductId;
            promo.Percent = model.Percent;
            promo.ValidUntil = model.ValidUntil;

            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var promo = await _context.Promotions.Include(p => p.Product).FirstOrDefaultAsync(p => p.Id == id);
            if (promo == null) return NotFound();

            return View(promo);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promo = await _context.Promotions.FindAsync(id);
            if (promo == null) return NotFound();

            _context.Promotions.Remove(promo);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        private async Task<List<SelectListItem>> GetProductSelectListAsync()
        {
            return await _context.Products
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToListAsync();
        }
    }
}

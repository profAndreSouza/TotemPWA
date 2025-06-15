using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using TotemPWA.Models;
using TotemPWA.Data;
using TotemPWA.ViewModels;

namespace TotemPWA.Controllers.Admin
{
    [Route("Admin/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult List()
        {
            var categories = _context.Categories
                .Include(c => c.Subcategories)
                .ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CategoryViewModel
            {
                Categories = _context.Categories
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(viewModel.Category);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            viewModel.Categories = _context.Categories
                .Where(c => c.ParentCategoryId == null)
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();

            return View(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            var viewModel = new CategoryViewModel
            {
                Category = category,
                Categories = _context.Categories
                    .Where(c => c.Id != id && c.ParentCategoryId == null)
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost("{id}")]
        public IActionResult Edit(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(viewModel.Category);
                _context.SaveChanges();
                return RedirectToAction("List");
            }

            viewModel.Categories = _context.Categories
                .Where(c => c.Id != viewModel.Category.Id)
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();

            return View(viewModel);
        }


        [HttpGet("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost("{id}")]
        public IActionResult ConfirmDelete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

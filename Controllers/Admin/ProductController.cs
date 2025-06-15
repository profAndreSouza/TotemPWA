using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;
using TotemPWA.Data;
using TotemPWA.Models;
using TotemPWA.ViewModels;

namespace TotemPWA.Controllers.Admin
{
    [Route("Admin/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProductViewModel
            {
                Categories = _context.Categories
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(viewModel.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }

            Console.WriteLine("erro ao validar o modelo");
            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"Campo: {state.Key}, Erro: {error.ErrorMessage}");
                }
            }
            viewModel.Categories = _context.Categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();

            return View(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            var viewModel = new ProductViewModel
            {
                Product = product,
                Categories = _context.Categories
                    .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(viewModel.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
            }

            // Recarregar categorias se inválido
            viewModel.Categories = _context.Categories
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();

            return View(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }
    }
}

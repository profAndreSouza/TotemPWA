using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TotemPWA.Models;

namespace TotemPWA.Controllers;

public class ExampleController : Controller
{
    private readonly ILogger<ExampleController> _logger;

    public ExampleController(ILogger<ExampleController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Receive(string name)
    {
        ViewBag.nome = name;
        return View();
    }

}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session.Models;

namespace Session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(string name)
    {
        HttpContext.Session.SetString("Name", name);
        
        
        HttpContext.Session.SetInt32("Number", 22);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("dashboard/plusone")]
    public IActionResult PlusOne()
    {
        int? num = HttpContext.Session.GetInt32("Number");
        num += 1;
        HttpContext.Session.SetInt32("Number", (int)num);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("dashboard/minusone")]
    public IActionResult MinusOne()
    {
        int? num = HttpContext.Session.GetInt32("Number");
        num -= 1;
        HttpContext.Session.SetInt32("Number", (int)num);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("dashboard/timestwo")]
    public IActionResult TimesTwo()
    {
        int? num = HttpContext.Session.GetInt32("Number");
        num *= 2;
        HttpContext.Session.SetInt32("Number", (int)num);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("dashboard/plusrandom")]
    public IActionResult PlusRandom()
    {
        int? num = HttpContext.Session.GetInt32("Number");
        Random rand = new();
        int RandomNumber = rand.Next(1, 11);
        num += RandomNumber;
        HttpContext.Session.SetInt32("Number", (int)num);
        return RedirectToAction("Dashboard");
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

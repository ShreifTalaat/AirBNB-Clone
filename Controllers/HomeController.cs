using System.Diagnostics;
using AirBNB.Data;
using AirBNB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Controllers
{
    public class HomeController : Controller

    {
        ApplicationDbContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db)
        {
            db = _db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var proprities = db.Properties.Include(a => a.PropertyImages).Include(a => a.Region).ThenInclude(a => a.City).ToList();
            return View(proprities);
        }

        //public async Task<IActionResult> Logout()
        //{
        //   await HttpContext.SignOutAsync(); 
        //    return RedirectToAction("Index", "Home");
        //}

    }
}
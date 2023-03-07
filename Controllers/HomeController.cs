using System.Diagnostics;
using AirBNB.Classes;
using AirBNB.Data;
using AirBNB.Models;
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

        public IActionResult PropertyDetails(int id)
        {
            var Property = db.Properties.Include(p => p.PropertyImages).Include(p => p.Amentios)
                .Include(p => p.Reviews).Include(p => p.House_Rules).FirstOrDefault(p => p.ID == id);
            var cities = db.Cities.ToList();
            ViewBag.cities = cities;
            var PropertyRegion = db.Regions.FirstOrDefault(a => a.Id == Property.RegionId).Name;
            ViewBag.PropertyRegion = PropertyRegion;
            var PropertyLgImg = db.PropertyImages.FirstOrDefault(a => a.PropertyID == Property.ID).URL;
            ViewBag.PropertyLgImg = PropertyLgImg;
            var PropertyCatagory = db.Categories.FirstOrDefault(a => a.Id == Property.CatogeryId).Name;
            ViewBag.PropertyCatagory = PropertyCatagory;
            var PropertyUserName = db.Users.FirstOrDefault(a => a.Id == Property.UserId);
            ViewBag.PropertyUserName = PropertyUserName.First_Name;
            ViewBag.PropertyUserProfilePic = PropertyUserName.Profile_Picture;
            if (Property == null)
            {
                return NotFound();
            }
            return View(Property);
        }

    }
}
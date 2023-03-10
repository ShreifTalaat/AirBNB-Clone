using System.Diagnostics;
using AirBNB.Classes;
using AirBNB.Data;
using AirBNB.Models;
using AirBNB.ViewModels;
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

            //ViewBag.PropertyLgImg = proprities.FirstOrDefault(a=>a.).PropertyImages.First().URL;
            return View(proprities);
        }

        
        public IActionResult PropertyDetails ( int id )
            {
            //Propert
            var Property = db.Properties.Include(p => p.PropertyImages).Include(p => p.Amentios)
                .Include(p => p.Reviews).ThenInclude(r => r.User).Include(p => p.House_Rules).FirstOrDefault(p => p.ID == id);
            //Cities
            var cities = db.Cities.ToList();
            ViewBag.cities = cities;
            //Regions
            var PropertyRegion = db.Regions.FirstOrDefault(a => a.Id == Property.RegionId).Name;
            ViewBag.PropertyRegion = PropertyRegion;
            //Property Imgs
            var PropertyLgImg = db.PropertyImages.FirstOrDefault(a => a.PropertyID == Property.ID).URL;
            ViewBag.PropertyLgImg = PropertyLgImg;
            //Property Catagory
            var PropertyCatagory = db.Categories.FirstOrDefault(a => a.Id == Property.CatogeryId).Name;
            ViewBag.PropertyCatagory = PropertyCatagory;
            //Property Host
            var PropertyUserName = db.Users.FirstOrDefault(a => a.Id == Property.UserId);
            ViewBag.PropertyUserName = PropertyUserName.First_Name;
            ViewBag.PropertyUserProfilePic = PropertyUserName.Profile_Picture;
            ViewBag.PropertyUserJoinedDate = PropertyUserName.Join_Date.Year;
            ViewBag.PropertyUserEmail = PropertyUserName.Email;
            //Property Review
            //double? reviewRatings = db.Reviews.Where(r => r.PropertyId == Property.ID)?.Select(r => r.Rating).Average();

            //ViewBag.reviewRatings = reviewRatings.Value.ToString("0.00");
            int? reviewRatingsCount = db.Reviews.Where(r => r.PropertyId == Property.ID).Select(r => r.Rating).Count();

            ViewBag.reviewRatingsCount = reviewRatingsCount;
            var payment = new DetailsPaymentViewModel
                {
                property = db.Properties.Include(u => u.UnavailableDays).Include(p => p.PropertyImages).Include(p => p.Amentios)
                .Include(p => p.Reviews).ThenInclude(r => r.User).Include(p => p.House_Rules).FirstOrDefault(p => p.ID == id),
                reservation = new Reservation()
                };
            return View(payment);
            }

        }
}
using AirBNB.Data;
using AirBNB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AirBNB.Controllers
    {
    public class HostingController : Controller
        {
        ApplicationDbContext _dbcontext;

        UserManager<AplicationUser> _userManager;
        public HostingController ( ApplicationDbContext dbcontext, UserManager<AplicationUser> userManager )
            {
            _dbcontext = dbcontext;
            _userManager = userManager;
            }
        public IActionResult Listing ()
            {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _dbcontext.Users.FirstOrDefault(a => a.Id == userid);
            ViewBag.PropertyUserProfilePic = user.Profile_Picture;
            var proprities = _dbcontext.Properties.Include(a => a.PropertyImages).Include(a=>a.Region).ThenInclude(a=>a.City).Where(a => a.UserId == userid).ToList();
            return View(proprities);

            }
        public IActionResult Index ()
            {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _dbcontext.Users.FirstOrDefault(a => a.Id == userid);
            ViewBag.PropertyUserProfilePic = user.Profile_Picture;
            var reservations = _dbcontext.Reservations.Include(a => a.Property).ThenInclude(a => a.PropertyImages).Where(a => a.Property.UserId == userid).ToList();
            return View(reservations);
            }
        public IActionResult Reservations ()
            {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _dbcontext.Users.FirstOrDefault(a => a.Id == userid);
            ViewBag.PropertyUserProfilePic = user.Profile_Picture;
            var reservations = _dbcontext.Reservations.Include(a => a.Property).ThenInclude(a => a.PropertyImages).Where(a => a.UserId == userid).ToList();
           
            return View(reservations);
            }
        [HttpPost]
        public IActionResult Reservations ( int id )
            {

            var reserve = _dbcontext.Reservations.FirstOrDefault(r => r.Id == id);

            _dbcontext.Reservations.Remove(reserve);
            _dbcontext.SaveChanges();
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = _dbcontext.Reservations.Include(a => a.Property).ThenInclude(a => a.PropertyImages).Where(a => a.UserId == userid).ToList();
            return View(reservations);
            }
        }
    }

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
        public HostingController(ApplicationDbContext dbcontext, UserManager<AplicationUser> userManager)
        {
            _dbcontext = dbcontext;
            _userManager = userManager;
        }
        public IActionResult Listing()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var proprities = _dbcontext.Properties.Include(a => a.PropertyImages).Where(a => a.UserId == userid).ToList();
            return View(proprities);
            
        }
        public IActionResult Index()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var proprities = _dbcontext.Properties.Include(a => a.PropertyImages).Where(a => a.UserId == userid).ToList();
            return View(proprities);
        }
        public IActionResult Reservations()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var proprities = _dbcontext.Properties.Include(a => a.PropertyImages).Where(a => a.UserId == userid).ToList();
            return View(proprities);
        }
    }
}

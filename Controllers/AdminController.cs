using AirBNB.Data;
using AirBNB.Models;
using AirBNB.Models.UserRolesControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        ApplicationDbContext db;
        public AdminController(UserManager<AplicationUser> userManager , RoleManager<IdentityRole> roleManager, ApplicationDbContext _db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public  IActionResult USerMange()
        {
           
            var users =  _userManager.Users.Select(user=>new UserViewModel
            {
             Id=user.Id,
             FirstName=user.First_Name,
             lastName=user.Last_Name,
             Roles = _userManager.GetRolesAsync(user).Result
            
            }).ToList();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> ManageRole(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if(user == null)
            {
                return NotFound();
            }
            else
            {
                var roles = await _roleManager.Roles.ToListAsync();
                var userModel = new UserRoleModel
                {
                    UserId = user.Id,
                    UserName = user.First_Name + " " + user.Last_Name,
                    Roles = roles.Select(role => new RoleViewModel
                    {
                        RoleId = role.Id,
                        RoleName = role.Name,
                        IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                    }).ToList()

                };
                return View(userModel);

            }
        }
        [HttpPost]
        public async Task<IActionResult> ManageRole(UserRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach(var role in model.Roles)
            {
                if (userRoles.Any(r => r == role.RoleName)&& !role.IsSelected)
                {
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                {
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                }
            }
            return RedirectToAction(nameof(USerMange));
        }
        public IActionResult PropertiesList()
        {
            var proprities = db.Properties.Include(a => a.PropertyImages).Include(a => a.Region).ThenInclude(a => a.City).ToList();
            return View(proprities);
        }
        public IActionResult PropAccepted(int propId ,string state)
        {
            var property = db.Properties.FirstOrDefault(p => p.ID == propId);
            if (property == null)
            {
                return NotFound();
            }
            if (state == "1")
            {
                property.Accepted = true;
               
            }
            if (state == "0")
            {
                db.Properties.Remove(property);
            }
            db.SaveChanges();
            return RedirectToAction(nameof(PropertiesList));
        }
    }
}

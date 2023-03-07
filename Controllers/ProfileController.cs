using AirBNB.Classes;
using AirBNB.Data;
using AirBNB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AirBNB.Controllers
{
    public class ProfileController : Controller
    {
        ApplicationDbContext _dbcontext;
        
		UserManager<AplicationUser> _userManager;
		public ProfileController(ApplicationDbContext dbcontext,UserManager<AplicationUser> userManager)
        {
            _dbcontext= dbcontext;
            _userManager= userManager;
        }
        public IActionResult Index(string UserId)
        {
            string loggedid = User.Identity.Name;

            ViewBag.Loggedid = loggedid;
			AplicationUser user =_dbcontext.Users.Include(a=>a.Properties).FirstOrDefault(a=>a.Id== UserId);

            return View(user);
        }
        [HttpPost]
		public async Task<IActionResult> Index()
        {
            var user=await _userManager.GetUserAsync(User);
			if (Request.Form.Files.Count > 0)
			{
				var file = Request.Form.Files.FirstOrDefault();

				using (var datastream = new MemoryStream())
				{
					await file.CopyToAsync(datastream);
					user.Profile_Picture = resize.ResizeImage(datastream.ToArray(), 600, 600);
                    //user.Profile_Picture = datastream.ToArray();
				}
				await _userManager.UpdateAsync(user);
			}
         
		
			return View(user);
        }
        
	}
}

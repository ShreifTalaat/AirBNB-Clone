﻿using AirBNB.Classes;
using AirBNB.Data;
using AirBNB.Models;
using AirBNB.Models.Reviews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Security.Principal;


namespace AirBNB.Controllers
{

    public class profileViewModel
    {
        public AplicationUser user { get; set; } 
		public List<Property> properties { get; set; }
      
	}
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
            //AplicationUser user =_dbcontext.Users.Include(a=>a.Properties).FirstOrDefault(a=>a.Id== UserId);

            var proprities = _dbcontext.Properties.Include(a => a.PropertyImages).Include(a=>a.Catogery).Include(a => a.Reviews).Where(a=>a.UserId==UserId&&a.Accepted==true).ToList();
            var userprofile = new profileViewModel
            {
                user = _dbcontext.Users.Include(a => a.Properties).FirstOrDefault(a => a.Id == UserId),


                 properties = proprities,

			};
            return View(userprofile);
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
			string loggedid = User.Identity.Name;

			ViewBag.Loggedid = loggedid;
			AplicationUser currentuser= _dbcontext.Users.Include(a => a.Properties).FirstOrDefault(a => a.Id == user.Id);
			var proprities = _dbcontext.Properties.Include(a => a.PropertyImages).Include(a => a.Catogery).Include(a => a.Reviews).Where(a => a.UserId == user.Id && a.Accepted == true).ToList();
			var userprofile = new profileViewModel
			{
				user = currentuser,
				properties = proprities,

			};
           
              
			//return View("~/Areas/Identity/Pages/Account/Manage/Account settings.cshtml");
			return View("~/Views/Profile/Index.cshtml", userprofile);
        }
        
	}

}

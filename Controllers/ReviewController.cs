using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using AirBNB.Data;
using AirBNB.Models;
using Microsoft.EntityFrameworkCore;
using AirBNB.Models.Reviews;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AirBNB.Controllers
{
    public class reviewModel
    {
        [MaxLength(500), MinLength(1), Required]
        public string Content { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        //public int PropID { get; set; }
    }
    public class ReviewController : Controller
	{
		private readonly ApplicationDbContext _db;
		public ReviewController(ApplicationDbContext db)
		{
			_db = db;
		}
	
		public IActionResult Index(int id)
        {
			TempData["propid"] = id;
            return View(); 
		}

		[HttpPost]
		public IActionResult AddReview(reviewModel model)
		{
            var propertyId = (int)TempData["propid"];
            if (ModelState.IsValid)
			{
				var rev = new Review
				{
					Content = model.Content,
					Rating = model.Rating,
					UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    PropertyId = propertyId,
                };
				_db.Reviews.Add(rev);
				_db.SaveChanges();
				return RedirectToAction("Index", "Home");
			}
			return View("Index");
		}
	}
}

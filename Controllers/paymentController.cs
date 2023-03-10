using System.Security.Claims;
using AirBNB.Data;
using AirBNB.Models;
using AirBNB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Controllers
{
    public class paymentController : Controller
    {
        ApplicationDbContext _db;
        public paymentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(DetailsPaymentViewModel model)
        {
            var property = _db.Properties.Include(a => a.PropertyImages).FirstOrDefault(p => p.ID == model.property.ID);
            PaymentViewModel PayModel = new PaymentViewModel()
            {
                CheckIn = model.reservation.CheckIn,
                CheckOut = model.reservation.CheckOut,
                NOfGuests = model.reservation.NOfGuests,
                Price = property.Price,
                Title = property.Title,
                Description = property.Description,
                URL = property.PropertyImages.First().URL,
            };
            TempData["id"] = model.property.ID;
            TempData["checkin"] = model.reservation.CheckIn;
            TempData["checkout"] = model.reservation.CheckOut;
            TempData["NoOfGuests"] = model.reservation.NOfGuests;


            //if (TempData.ContainsKey("aa"))
            //    aa = TempData["aa"] as Reservation;
            return View(PayModel);
        }
        [HttpPost]
        public IActionResult Index(PaymentViewModel model)
        {


            var id = (int)TempData["id"];
            var checkin = (DateTime)TempData["checkin"];
            var checkout = (DateTime)TempData["checkout"];
            var noOfGusets = (int)TempData["NoOfGuests"];
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var unavalableDays = (checkout - checkin).TotalDays;
            for(int i=0; i <= unavalableDays; i++)
            {
                PropertyUnavailableDay unavalableDay = new PropertyUnavailableDay();
                unavalableDay.PropertyId = id;
                unavalableDay.UnavailableDay = checkin.AddDays(i);
                _db.PropertyUnavailableDays.Add(unavalableDay);
                _db.SaveChanges();
                     
            }
            Reservation reserve = new Reservation()
            {
                CheckIn = checkin,
                CheckOut = checkout,
                NOfGuests = noOfGusets,
                UserId = user,
                PropertyId = id

            };
            _db.Reservations.Add(reserve);
            _db.SaveChanges();
            Transaction trans = new Transaction()
            {
                Amount = model.Amount,
                ReservationId = reserve.Id
            };
            _db.Transactions.Add(trans);
            _db.SaveChanges();

            return RedirectToAction("Reservations", "Hosting");

        }
    }
}

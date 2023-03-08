using AirBNB.Models;
using AirBNB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AirBNB.Controllers
    {
    public class paymentController : Controller
        {
        [HttpPost]
        public IActionResult Index (DetailsPaymentViewModel model)
            {
            //if (TempData.ContainsKey("aa"))
            //    aa = TempData["aa"] as Reservation;
            return View();
            }
        }
    }

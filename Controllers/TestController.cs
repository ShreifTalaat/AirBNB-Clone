using Microsoft.AspNetCore.Mvc;

namespace AirBNB.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

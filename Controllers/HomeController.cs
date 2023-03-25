using System . Diagnostics;
using System . Security . Claims;
using System . Linq;
using AirBNB . Classes;
using AirBNB . Data;
using AirBNB . Models;
using AirBNB . ViewModels;
using Microsoft . AspNetCore . Mvc;
using Microsoft . EntityFrameworkCore;

namespace AirBNB . Controllers
    {
    public class HomeController : Controller

        {
        ApplicationDbContext db;
        private readonly ILogger<HomeController> _logger;
        public HomeController ( ILogger<HomeController> logger , ApplicationDbContext _db )
            {
            db = _db;
            _logger = logger;
            }
        public IActionResult Index ()
            {
            var cities = db . Cities . ToList ();
            ViewBag . cities = cities;
            var user = User . FindFirstValue ( ClaimTypes . NameIdentifier );
            if ( user != null )
                ViewBag . UserProfilePic = db . Users . FirstOrDefault ( a => a . Id == user ) . Profile_Picture;
            var proprities = db . Properties . Include ( a => a . PropertyImages ) . Include ( a => a . Region ) . ThenInclude ( a => a . City ) . ToList ();
            //ViewBag.PropertyLgImg = proprities.FirstOrDefault(a=>a.).PropertyImages.First().URL;
            return View ( proprities );
            }
        public IActionResult PropertyDetails ( int id )
            {
            //Propert
            var Property = db . Properties . Include ( p => p . PropertyImages ) . Include ( p => p . Amentios )
                . Include ( p => p . Reviews ) . ThenInclude ( r => r . User ) . Include ( p => p . House_Rules ) . FirstOrDefault ( p => p . ID == id );
            //Cities
            var cities = db . Cities . ToList ();
            ViewBag . cities = cities;
            //Regions
            var PropertyRegion = db . Regions . FirstOrDefault ( a => a . Id == Property . RegionId ) . Name;
            ViewBag . PropertyRegion = PropertyRegion;
            //Property Imgs
            var PropertyLgImg = db . PropertyImages . FirstOrDefault ( a => a . PropertyID == Property . ID ) . URL;
            ViewBag . PropertyLgImg = PropertyLgImg;
            //Property Catagory
            var PropertyCatagory = db . Categories . FirstOrDefault ( a => a . Id == Property . CatogeryId ) . Name;
            ViewBag . PropertyCatagory = PropertyCatagory;
            //Property Host
            var PropertyUserName = db . Users . FirstOrDefault ( a => a . Id == Property . UserId );
            ViewBag . PropertyUserName = PropertyUserName . First_Name;
            ViewBag . PropertyUserProfilePic = PropertyUserName . Profile_Picture;
            ViewBag . PropertyUserJoinedDate = PropertyUserName . Join_Date . Year;
            ViewBag . PropertyUserEmail = PropertyUserName . Email;
            //Property Review
            var reviewRatings = db.Reviews.Where( r => r . PropertyId == Property . ID )?.Select ( r => r . Rating ).ToList();
            var user = User . FindFirstValue ( ClaimTypes . NameIdentifier );
            if ( user != null )
                ViewBag . UserProfilePic = db . Users . FirstOrDefault ( a => a . Id == user ) . Profile_Picture;
            if ( reviewRatings.Count>0 )
                ViewBag . reviewRatings = reviewRatings.Average().ToString ( "0.00" );
            else
                ViewBag . reviewRatings = "0.00";
            int? reviewRatingsCount = db . Reviews . Where ( r => r . PropertyId == Property . ID ) . Select ( r => r . Rating ) . Count ();
            ViewBag . reviewRatingsCount = reviewRatingsCount;

            var payment = new DetailsPaymentViewModel
                {
                property = db . Properties . Include ( u => u . UnavailableDays ) . Include ( p => p . PropertyImages ) . Include ( p => p . Amentios )
                . Include ( p => p . Reviews ) . ThenInclude ( r => r . User ) . Include ( p => p . House_Rules ) . FirstOrDefault ( p => p . ID == id ) ,
                reservation = new Reservation ()
                };
            return View ( payment );
            }

        public IActionResult Search ( SearchModel searchModel )
            {
            var search = new SearchModel
                {
                CityName = searchModel . CityName ,
                Price = searchModel . Price ,
                NumberOfGuests = searchModel . NumberOfGuests
                };
            //1) Search By City Name Only
            if ( searchModel . CityName != null && searchModel . Price == null && searchModel . NumberOfGuests == null )
                {
                List<Property> CityProperties = new List<Property> ();
                var city = db . Cities . FirstOrDefault ( c => c . Name == searchModel . CityName );
                var regions = db . Regions . Where ( r => r . CityId == city . Id ) . ToList ();
                foreach ( var region in regions )
                    {
                    List<Property> properties = db . Properties . Include ( p => p . PropertyImages ) . Where ( p => p . RegionId == region . Id ) . ToList ();
                    foreach ( var prop in properties )
                        {
                        CityProperties . Add ( prop );
                        }
                    }
                return View ( CityProperties );
                }
            //2) Search By City Name & Price
            else if ( searchModel . CityName != null && searchModel . Price != null && searchModel . NumberOfGuests == null )
                {
                List<Property> CityProperties = new List<Property> ();
                var city = db . Cities . FirstOrDefault ( c => c . Name == searchModel . CityName );
                var regions = db . Regions . Where ( r => r . CityId == city . Id ) . ToList ();
                foreach ( var region in regions )
                    {
                    List<Property> properties = db . Properties . Include ( p => p . PropertyImages ) . Where ( p => p . RegionId == region . Id ) . ToList ();
                    foreach ( var prop in properties )
                        {
                        CityProperties . Add ( prop );
                        }
                    }
                var CityAndPriceProperties = CityProperties . Where ( p => p . Price <= searchModel . Price ) . ToList ();
                return View ( CityAndPriceProperties );
                }
            /////////3) Search By City Name & NumberOfGuests
            else if ( searchModel . CityName != null && searchModel . Price == null && searchModel . NumberOfGuests != null )
                {
                List<Property> CityProperties = new List<Property> ();
                var city = db . Cities . FirstOrDefault ( c => c . Name == searchModel . CityName );
                var regions = db . Regions . Where ( r => r . CityId == city . Id ) . ToList ();
                foreach ( var region in regions )
                    {
                    List<Property> properties = db . Properties . Include ( p => p . PropertyImages ) . Where ( p => p . RegionId == region . Id ) . ToList ();
                    foreach ( var prop in properties )
                        {
                        CityProperties . Add ( prop );
                        }
                    }
                var CityAndNumberOfGuestsProperties = CityProperties . Where ( p => p . Capacity == searchModel . NumberOfGuests ) . ToList ();
                return View ( CityAndNumberOfGuestsProperties );
                }
            /////////4) Search By City Name & Price & NumberOfGuests
            else if ( searchModel . CityName != null && searchModel . Price != null && searchModel . NumberOfGuests != null )
                {
                List<Property> CityProperties = new List<Property> ();
                var city = db . Cities . FirstOrDefault ( c => c . Name == searchModel . CityName );
                var regions = db . Regions . Where ( r => r . CityId == city . Id ) . ToList ();
                foreach ( var region in regions )
                    {
                    List<Property> properties = db . Properties . Include ( p => p . PropertyImages ) . Where ( p => p . RegionId == region . Id ) . ToList ();
                    foreach ( var prop in properties )
                        {
                        CityProperties . Add ( prop );
                        }
                    }
                var CityAndPriceProperties = CityProperties . Where ( p => p . Price <= searchModel . Price ) . ToList ();
                var CityAndPriceAndNOGuestsProperties = CityAndPriceProperties . Where ( p => p . Capacity == searchModel . NumberOfGuests ) . ToList ();
                return View ( CityAndPriceAndNOGuestsProperties );
                }
            /////////5) Search By Price Only
            else if ( searchModel . CityName == null && searchModel . Price != null && searchModel . NumberOfGuests == null )
                {
                List<Property> PriceProperties = new List<Property> ();
                PriceProperties = db . Properties . Include ( p => p . PropertyImages ) . Include ( a => a . Region ) . ThenInclude ( a => a . City ) . Where ( p => p . Price <= searchModel . Price ) . ToList ();
                return View ( PriceProperties );
                }
            /////////6) Search By Price & Number of Guests
            else if ( searchModel . CityName == null && searchModel . Price != null && searchModel . NumberOfGuests != null )
                {
                List<Property> PriceProperties = new List<Property> ();
                PriceProperties = db . Properties . Include ( p => p . PropertyImages ) . Include ( a => a . Region ) . ThenInclude ( a => a . City ) . Where ( p => p . Price <= searchModel . Price ) . ToList ();
                var PriceAndNumberOfGuests = PriceProperties . Where ( p => p . Capacity == searchModel . NumberOfGuests ) . ToList ();
                return View ( PriceAndNumberOfGuests );
                }
            /////////7) Search By Number of Guests Only
            else if ( searchModel . CityName == null && searchModel . Price == null && searchModel . NumberOfGuests != null )
                {
                List<Property> NumberOfGuestsProperties = new List<Property> ();
                NumberOfGuestsProperties = db . Properties . Include ( p => p . PropertyImages ) . Include ( a => a . Region ) . ThenInclude ( a => a . City ) . Where ( p => p . Capacity == searchModel . NumberOfGuests ) . ToList ();
                return View ( NumberOfGuestsProperties );
                }
            else { return View (); }
            }
        }
    }

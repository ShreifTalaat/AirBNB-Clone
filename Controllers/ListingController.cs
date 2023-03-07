using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AirBNB.Data;
using AirBNB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Controllers
{
    public class CreatePropertyViewModel
    {
        public int NumberOfBedRooms { get; set; } = 1;
       
        public int NumberOfBeds { get; set; } = 1;
     
        public int NumberOfBathRooms { get; set; } = 1;
      
        public int Capacity { get; set; } = 1;
        public string Title { get; set; }
        [Required, MaxLength(500)/*, MinLength(1)*/]
        public string Description { get; set; }
        [Required/*,MinLength(2)*/]
        public float Price { get; set; }
        public string Location { get; set; }
        public string Catogery { get; set; }
        public int MaxStay { get; set; }
        public int MinStay { get; set; } = 1;
        public string BuildingNumber { get; set; }
        public string Street { get; set; }
        public  IFormFile[] images { get; set; }
        public string[] amenteis { get; set; }

    }
    public class ListingController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ListingController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            //var properties=_db.Properties.Include(a=>a.PropertyImages).Include(b=>b.Catogery).Include(m=>m.Amentios).Include(r=>r.Region).ThenInclude(r=>r.City).ToList();
            //ViewData["images"] = _db.PropertyImages;
            //ViewData["Region"] = _db.Regions;
            //ViewData["City"] = _db.Cities;
            //ViewData["Category"] = _db.Categories;
           
            return View();
        }

        //public IActionResult Create(int catId, Property property,string location, string[] arrayofimages) {
        //    var properties = _db.Properties.Include(a => a.PropertyImages).Include(b => b.Catogery).Include(m => m.Amentios).Include(r => r.Region).ThenInclude(r => r.City);
        //    var cit = new City { Name = location.Split(',').Last().TrimEnd().TrimStart() };

        //    _db.Cities.Add(cit);
        //    var reg = new Region { Name = location.Split(',').First().TrimEnd().TrimStart(), CityId = cit.Id };
        //    _db.Regions.Add(reg);


        //    _db.Properties.Add(new Property { Capacity=property.Capacity,NumberOfBeds=property.NumberOfBeds,
        //        NumberOfBathRooms=property.NumberOfBathRooms,
        //        NumberOfBedRooms=property.NumberOfBedRooms,
        //        Title=property.Title,
        //        Description=property.Description,
        //        Price=property.Price,
        //        RegionId=reg.Id,
        //        CatogeryId=catId,
        //        UserId =User.FindFirstValue(ClaimTypes.NameIdentifier)
        //});
        //    _db.SaveChanges();
        //    return View();
        //}
        [HttpPost]
        public IActionResult Index(CreatePropertyViewModel model)
        {
            if (ModelState.IsValid) {

             
                int regionid = 0;
                string cityname = model.Location.Split(',').Last().TrimEnd().TrimStart();
                string regionname = model.Location.Split(',').First().TrimEnd().TrimStart();
                var _cityexist=_db.Cities.FirstOrDefault(a => a.Name.ToLower() == cityname.ToLower());
                var _regionexist = _db.Regions.FirstOrDefault(a => a.Name.ToLower() == regionname.ToLower());
                if (_cityexist == null)
                {
                    var cit = new City { Name = cityname };
                    _db.Cities.Add(cit);
                    _db.SaveChanges();
                    var reg = new Region { Name = regionname, CityId = cit.Id };
                    _db.Regions.Add(reg);
                    _db.SaveChanges();
                    regionid = reg.Id;
                }
                else if(_regionexist == null )
                {
                    var reg = new Region { Name = regionname, CityId = _cityexist.Id };
                    _db.Regions.Add(reg);
                    _db.SaveChanges();
                    regionid = reg.Id;
                }
                else
                {
                    regionid = _regionexist.Id;
                }   


              var prop =  new Property
            {
                Capacity = model.Capacity,
                NumberOfBeds = model.NumberOfBeds,
                NumberOfBathRooms = model.NumberOfBathRooms,
                NumberOfBedRooms = model.NumberOfBedRooms,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                RegionId= regionid,
                BuildingNumber= model.BuildingNumber,
                Street= model.Street,
                CatogeryId = _db.Categories.FirstOrDefault(m => m.Name == model.Catogery).Id,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };
                _db.Properties.Add(prop);
                _db.SaveChanges();

                foreach (var item in model.amenteis)
                {
                    var amentt=_db.Amenities.FirstOrDefault(a => a.Name == item);
                    prop.Amentios.Add(amentt);
                    _db.SaveChanges();
                }

                for(int i = 0 ; i <model.images.Length;i++)
                {
                    string filename = prop.ID.ToString() + "_" +(i+1)
                    +"." +model.images[i].FileName.Split(".").Last();
                    _db.PropertyImages.Add(new PropertyImage { URL = filename, PropertyID = prop.ID });
                    _db.SaveChanges();
                    using (var fs = System.IO.File.Create("wwwroot/Prop.Image/Prop1/" + filename))
                    {
                       model.images[i].CopyTo(fs);
                    }
                }
                
                return RedirectToAction("Index","Home");
            }
            return View("Index");
        }


    }
}

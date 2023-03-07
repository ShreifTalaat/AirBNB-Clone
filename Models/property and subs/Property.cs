using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;
using AirBNB.Models.Reviews;
using Azure.Core.GeoJson;

namespace AirBNB.Models;

public class Property
{
	public int ID { get; set; }
	[Range(1,20)]
	public int NumberOfBedRooms { get; set; } = 1;
	[Range(1, 60)]
	public int NumberOfBeds { get; set; } = 1;
	[Range(1, 20)]
	public int NumberOfBathRooms { get; set; } = 1;
	[Range(1, 60)]
	public int Capacity { get; set; } = 1;
	public bool Accepted { get; set; }=false;
	[Required,MaxLength(32)/*,MinLength(1)*/]
	public string Title { get; set; }
	[Required, MaxLength(500)/*, MinLength(1)*/]
	public string Description { get; set; }
	[Required/*,MinLength(2)*/]
	public float Price { get; set; }
	[Required]
	public int MaxStay { get; set; }
	public int MinStay { get; set; } = 1;

	public DateTime Date { get; set; } = DateTime.Now;
	public Point Cordinates { get; set; }
	public string BuildingNumber { get; set; }
	public string Street { get; set; }
	//public int PostalCode { get; set; }
	public double? Area { get; set; }
	//Region foriegnkey
	[ForeignKey("Region")]
	public int RegionId { get; set; }
	public virtual Region Region { get; set; }

	//Catogery foriegnkey
	[ForeignKey("Catogery")]
	public int CatogeryId { get; set; }
	public virtual Category Catogery { get; set; }
	//User foriegnkey
	[ForeignKey("User")]
	public string UserId { get; set; }
	public virtual AplicationUser User { get; set; }
	//House Rule Relation
	public virtual ICollection<House_Rule> House_Rules { get; set; } = new HashSet<House_Rule>();
	//Amenty Relation
	public virtual ICollection<Amenity> Amentios { get; set; } = new HashSet<Amenity>();
	//Review relation
	public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
	//image relation
	public virtual ICollection<PropertyImage> PropertyImages { get; set; }=new HashSet<PropertyImage>();

	 











}


using Azure.Core.GeoJson;
using NetTopologySuite.Geometries;


namespace AirBNB.Models;

	public class Region
	{
	public int Id { get; set;}
	public string Name { get; set;}
	public Point Cordinates { get; set; }
	public virtual ICollection<Property> Properties { get; set; }=new HashSet<Property>();
	//City Foriegnkey
	public int CityId { get; set;}
	public virtual City City { get; set; }
}


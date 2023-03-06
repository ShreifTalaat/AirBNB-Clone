using NetTopologySuite.Geometries;
using Azure.Core.GeoJson;

namespace AirBNB.Models;

public class City
{
	public int Id { get; set; }
	public string Name { get; set; }
	public Point Cordinates { get; set; }
	public virtual ICollection<Region> Regions { get; set; } = new HashSet<Region>();
}

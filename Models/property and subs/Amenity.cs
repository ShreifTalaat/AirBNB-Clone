using System.ComponentModel.DataAnnotations;

namespace AirBNB.Models;

public class Amenity
{
	public int Id { get; set; }
	public string Name { get; set; }
	//public string Description { get; set; }
	public string Icon { get; set; }
	public string Type { set; get; }
	public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();
}

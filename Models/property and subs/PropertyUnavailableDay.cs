using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirBNB.Models;

	public class PropertyUnavailableDay
	{
	[ForeignKey("Property")]
	public int PropertyId { get; set; }
	
	public DateTime? UnavailableDay { set; get; }

	public virtual Property Property { get; set; }
}


using System.ComponentModel.DataAnnotations;
using AirBNB.Models.Reviews;
using Microsoft.AspNetCore.Identity;


namespace AirBNB.Models;

public class AplicationUser : IdentityUser
{
	[Required]
	[MinLength(3),MaxLength(15)]
	public string First_Name { get; set; }
	[Required]
	[MinLength(3), MaxLength(15)]
	public string Last_Name { get; set; }
	[Required]
	public byte[] Profile_Picture { get; set; }
	public DateTime Join_Date { get; set; } = DateTime.Now;
	[Required]
	[MaxLength(20)]
	public string City { get; set; }
	[Required]
	[MaxLength(11),MinLength(11)]
	[RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "enter a valid phone number")]
	public int Phone_Number { get; set; }
    //Property relation
    public virtual ICollection<Property> Properties { get; set; }=new HashSet<Property>();
	//review relation
	public virtual ICollection<Review> Reviews { get; set; } = new HashSet<Review>();	
    //reservation relation
    public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

}


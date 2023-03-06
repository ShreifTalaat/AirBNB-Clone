using System.ComponentModel.DataAnnotations.Schema;

namespace AirBNB.Models;

public class Reservation
{
	public int Id { get; set; }
	public DateTime CheckIn { get; set; }=DateTime.Now;
	public DateTime CheckOut { get; set; } =DateTime.Now.AddDays(1);
	public DateTime Date { get; set; } = DateTime.Now;
	public int NOfGuests { get; set; } = 1;
	public bool Accepted { get; set; } = false;
    //User foriegnkey
    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual AplicationUser User { get; set; }
    //Property foriegnkey
    [ForeignKey("Property")]
	public int PropertyId { get; set; }
	public virtual Property Property { get; set; }
	public virtual Transaction Transaction { get; set; }
}

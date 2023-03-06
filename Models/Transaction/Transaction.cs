using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirBNB.Models;

public class Transaction
{
	public int Id { get; set; }
	[Required,MinLength(2)]
	public double Amount { get; set; }
	public DateTime Date { get; set; }= DateTime.Now;
	//Reservation Foriegnkey
	[ForeignKey("Reservation")]
	public int ReservationId { get; set; }
	public virtual Reservation Reservation { get; set; }
}

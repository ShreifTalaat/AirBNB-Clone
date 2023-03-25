using System.ComponentModel.DataAnnotations;

namespace AirBNB.ViewModels
{
	public class PaymentViewModel
	{
		public DateTime CheckIn { get; set; }/*=DateTime.Now;*/
		public DateTime CheckOut { get; set; } /*=DateTime.Now.AddDays(1);*/
		public int NOfGuests { get; set; } = 1;
		public float Price { get; set; }
		public string Title { get; set; }
		[Required, MaxLength(500)/*, MinLength(1)*/]
		public string Description { get; set; }
		public string URL { get; set; } = "/notvalid.jpg";
        public double Amount { get; set; }
        public int PropertyId { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreBluemixResearch.Web.Models
{
	/// <summary>
	/// A basic class for an order
	/// </summary>
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }

		public string User { get; set; }
		public string Address { get; set; }
		public string ContactPhone { get; set; }

		public int PhoneId { get; set; }
		public Phone Phone { get; set; }
	}
}

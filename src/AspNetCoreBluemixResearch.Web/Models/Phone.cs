using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreBluemixResearch.Web.Models
{
	/// <summary>
	/// A basic class for a phone
	/// </summary>
	public class Phone
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Name { get; set; }
		public string Company { get; set; }
		public int Price { get; set; }
	}
}

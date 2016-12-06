using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBluemixResearch.Web.Models
{
	/// <summary>
	/// The Entity Framework context with DbSets
	/// </summary>
	public class MobileContext : DbContext
	{
		public bool ProviderSpecified { get; private set; }

		public DbSet<Phone> Phones { get; set; }
		public DbSet<Order> Orders { get; set; }

		public MobileContext(DbContextOptions<MobileContext> options)
			: base(options)
		{
			ProviderSpecified = options.Extensions.Any();
		}
	}
}

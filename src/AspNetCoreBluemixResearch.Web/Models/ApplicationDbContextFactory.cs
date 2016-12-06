using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace AspNetCoreBluemixResearch.Web.Models
{
	public class ApplicationDbContextFactory
	{
		private readonly IConfiguration _configuration;

		public ApplicationDbContextFactory(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public MobileContext CreateApplicationDbContext()
		{
			var optionsBuilder = new DbContextOptionsBuilder<MobileContext>();

			string connectionType = _configuration["ConnectionSelected"];

			string connectionString = _configuration.GetConnectionString(connectionType);

			switch (connectionType)
			{
				case "ExternalSQLServerConnection":
				{
					optionsBuilder.UseSqlServer(connectionString);
				}
				break;
				case "SQLiteConnection":
				{
					optionsBuilder.UseSqlite(connectionString);
				}
				break;
				case "MySQLConnection":
				{
					optionsBuilder.UseMySQL(connectionString);
				}
				break;
				case "PostgreSQLConnection":
				{
					optionsBuilder.UseNpgsql(connectionString);
				}
				break;
			}

			return new MobileContext(optionsBuilder.Options);
		}
	}
}

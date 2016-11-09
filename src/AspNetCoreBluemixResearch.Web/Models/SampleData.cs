using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AspNetCoreBluemixResearch.Web.Models
{
	/// <summary>
	/// Class for initial sample application data
	/// </summary>
	public static class SampleData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = serviceProvider.GetService<MobileContext>())
			{
				context.Database.EnsureCreated();

				if (!context.Phones.Any())
				{
					context.Phones.AddRange(
						new Phone
						{
							Name = "iPhone 6S",
							Company = "Apple",
							Price = 600
						},
						new Phone
						{
							Name = "Samsung Galaxy Edge",
							Company = "Samsung",
							Price = 550
						},
						new Phone
						{
							Name = "Lumia 950",
							Company = "Microsoft",
							Price = 500
						}
						);

					context.SaveChanges();
				}
			}
		}
	}
}

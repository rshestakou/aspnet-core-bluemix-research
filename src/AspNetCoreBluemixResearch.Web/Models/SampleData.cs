using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AspNetCoreBluemixResearch.Web.Models
{
  public static class SampleData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      var context = serviceProvider.GetService<MobileContext>();

      if (!context.Phones.Any())
      {
        context.Phones.AddRange(
            new Phone
            {
              Id = 1,
              Name = "iPhone 6S",
              Company = "Apple",
              Price = 600
            },
            new Phone
            {
              Id = 2,
              Name = "Samsung Galaxy Edge",
              Company = "Samsung",
              Price = 550
            },
            new Phone
            {
              Id = 3,
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

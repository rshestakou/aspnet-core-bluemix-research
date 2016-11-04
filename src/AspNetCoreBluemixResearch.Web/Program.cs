using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreBluemixResearch.Web
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var config = new ConfigurationBuilder()
        .AddCommandLine(args)
        .Build();

      var host = new WebHostBuilder()
        .UseKestrel()
        .UseConfiguration(config)
        .UseStartup<Startup>()
        .Build();

      host.Run();
    }
  }
}

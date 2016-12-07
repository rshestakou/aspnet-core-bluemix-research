using AspNetCoreBluemixResearch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace AspNetCoreBluemixResearch.Web.Controllers
{
	public class SetupController : Controller
	{
		private readonly IConfiguration _configuration;

		public SetupController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IActionResult Index()
		{
			var viewModel = new ConnectionsViewModel
			{
				Connections = new List<SelectListItem>
				{
					new SelectListItem {Text = "SQL Server", Value = "ExternalSQLServerConnection"},
					new SelectListItem {Text = "SQLite", Value = "SQLiteConnection"},
					new SelectListItem {Text = "MySQL", Value = "MySQLConnection"},
					new SelectListItem {Text = "PostgreSQL", Value = "PostgreSQLConnection"}
				}
			};
			
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult CreateConnection(ConnectionsViewModel model)
		{
			_configuration["ConnectionSelected"] = model.ConnectionSelected;
			
			InitializeContext();

			return RedirectToAction("Index", "Home");
		}

		public void InitializeContext()
		{
			var context = HttpContext.RequestServices.GetService<MobileContext>();

			SampleData.Initialize(context);
		}
	}
}

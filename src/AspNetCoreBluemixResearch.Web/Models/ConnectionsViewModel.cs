using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspNetCoreBluemixResearch.Web.Models
{
	public class ConnectionsViewModel
	{
		public string ConnectionSelected { get; set; }
		public List<SelectListItem> Connections { get; set; }
	}
}

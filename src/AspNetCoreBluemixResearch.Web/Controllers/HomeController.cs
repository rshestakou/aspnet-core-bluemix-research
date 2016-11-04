using AspNetCoreBluemixResearch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreBluemixResearch.Web.Controllers
{
  public class HomeController : Controller
  {
    MobileContext db;

    public HomeController(MobileContext context)
    {
      db = context;
    }

    public IActionResult Index()
    {
      return View(db.Phones.ToList());
    }

    [HttpGet]
    public IActionResult Buy(int id)
    {
      ViewBag.PhoneId = id;

      return View();
    }

    [HttpPost]
    public string Buy(Order order)
    {
      db.Orders.Add(order);

      db.SaveChanges();

      return order.User + ", thank you for your purchase!";
    }
  }
}

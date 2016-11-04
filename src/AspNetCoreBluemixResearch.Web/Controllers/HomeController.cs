using AspNetCoreBluemixResearch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspNetCoreBluemixResearch.Web.Controllers
{
  public class HomeController : Controller
  {
    MobileContext db;

    public HomeController(MobileContext context)
    {
      db = context;
    }

    public async Task<IActionResult> Index()
    {
      return View(await db.Phones.ToListAsync());
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Phone phone)
    {
      db.Phones.Add(phone);

      await db.SaveChangesAsync();

      return RedirectToAction("Index");
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

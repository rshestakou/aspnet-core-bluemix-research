using AspNetCoreBluemixResearch.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspNetCoreBluemixResearch.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly MobileContext db;

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

		public async Task<IActionResult> Details(int? id)
		{
			if (id != null)
			{
				Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);

				if (phone != null)
				{
					return View(phone);
				}
			}

			return NotFound();
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id != null)
			{
				Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);

				if (phone != null)
				{
					return View(phone);
				}
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Phone phone)
		{
			db.Phones.Update(phone);

			await db.SaveChangesAsync();

			return RedirectToAction("Index");
		}
		
		[HttpGet]
		[ActionName("Delete")]
		public async Task<IActionResult> ConfirmDelete(int? id)
		{
			if (id != null)
			{
				Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);

				if (phone != null)
				{
					return View(phone);
				}
			}

			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id != null)
			{
				var phone = new Phone { Id = id.Value };

				db.Entry(phone).State = EntityState.Deleted;

				await db.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return NotFound();
		}
	}
}

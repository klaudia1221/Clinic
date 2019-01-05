using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
	public class SkierowaniaController : Controller
	{
		public SkierowaniaController(KlinikaEntities db)
		{
			this.db = db;
			ViewBag.Title = Title;
		}

		public ActionResult Index(string message)
		{
			var referral = db.Skierowanie;

			ViewBag.ErrorMessage = message;

			return View(referral.ToList());
		}

		public ActionResult Nowy()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Nowy(
			[Bind(Include = "PacjentID, DoktorID, Informacja")]
			Skierowanie referral)
		{
			try
			{
				if (ModelState.IsValid)
				{
					db.Skierowanie.Add(referral);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch (DbUpdateException ex)
			{
				var errorMessage = $"Nie udało się dodać skierowania - {ex.InnerException.InnerException.Message}";

				ViewBag.ErrorMessage = errorMessage;
			}

			return View(referral);
		}


		private readonly KlinikaEntities db;
		private const string Title = "Skierowania";
	}
}
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
	public class ZuzycieController : Controller
	{
		public ZuzycieController(KlinikaEntities db)
		{
			this.db = db;
			ViewBag.Title = Title;
		}

		public ActionResult Index()
		{
			var zuzycie = db.Zuzycie_Lekow;

			return View(zuzycie.ToList());
		}

		public ActionResult Nowy()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Nowy(
			[Bind(Include = "Ilosc")]
			Zuzycie_Lekow zuzycie)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var sqlQuery =
						$"exec uzyj_lekow @WizytaID={zuzycie.WizytaID}, @ZaopatrzenieID={zuzycie.ZaopatrzenieID}, @Ilosc={zuzycie.Ilosc}";

					db.Database.ExecuteSqlCommand(sqlQuery);

					db.Zuzycie_Lekow.Add(zuzycie);
					db.SaveChanges();

					return RedirectToAction("Index");
				}
			}
			catch (DbUpdateException ex)
			{
				var errorMessage = $"Nie udało się dodać zużycia leków - {ex.InnerException.InnerException.Message}";

				ViewBag.ErrorMessage = errorMessage;
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMessage = ex.Message;
			}

			return View(zuzycie);
		}

		private readonly KlinikaEntities db;
		private const string Title = "Zużycie leków";
	}
}
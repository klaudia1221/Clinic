using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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

		public ActionResult Index(int? id)
		{
			var medUsage = new NewMedUsageModel()
			{
				MedUsage = db.Zuzycie_Lekow.Where(v => v.WizytaID == id).ToList(),
				Id = id
			};

			return View(medUsage);
		}

		public ActionResult Nowy(int? id)
		{
			var medUsage = new Zuzycie_Lekow { WizytaID = id.GetValueOrDefault()};

			return View(medUsage);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Nowy(
			[Bind(Include = "WizytaID, ZaopatrzenieID, Ilosc")]
			Zuzycie_Lekow zuzycie)
		{
			try
			{
				if (ModelState.IsValid)
				{
					var sqlQuery =
						$"exec uzyj_lekow @WizytaID={zuzycie.WizytaID}, @ZaopatrzenieID={zuzycie.ZaopatrzenieID}, @Ilosc={zuzycie.Ilosc}";

					//db.Database.ExecuteSqlCommand(sqlQuery);

					db.Zuzycie_Lekow.Add(zuzycie);
					db.SaveChanges();

					return RedirectToAction("Index", new { id= zuzycie.WizytaID, type="Wizyta" });
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

		public ActionResult Usun(int? id, bool? saveChangesError = false)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			if (saveChangesError.GetValueOrDefault())
				ViewBag.ErrorMessage = $"Nie udało się usunąć wizyty o identyfikatorze: {id}";

			var medUsage = db.Zuzycie_Lekow.Where(item => item.WizytaID == id);

			if (medUsage == null)
				return HttpNotFound();

			return View(medUsage.First());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Usun(int id)
		{
			try
			{
				var medUsage = db.Zuzycie_Lekow.Where(item => item.WizytaID == id);
				db.Zuzycie_Lekow.Remove(medUsage.First());
				db.SaveChanges();
			}
			catch (Exception)
			{
				return RedirectToAction("Usun", new { id = id, saveChangesError = true });
			}

			return RedirectToAction("Index", new { id = id, type = "Wizyta"});
		}

		private readonly KlinikaEntities db;
		private const string Title = "Zużycie leków";
	}
}
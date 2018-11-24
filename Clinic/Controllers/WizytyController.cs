using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
	public class WizytyController : Controller
	{
		public WizytyController(KlinikaEntities db)
		{
			this.db = db;
			ViewBag.Title = Title;
		}

		public ActionResult Index(int? id, string type)
		{
			IQueryable<Wizyta> visits;
			switch (type)
			{
				case "Pacjent":
					visits = db.Wizyta.Where(v => v.PacjentID == id);
					break;
				case "Doktor":
					visits = db.Wizyta.Where(v => v.DoktorID == id);
					break;
				default:
					visits = db.Wizyta;
					break;
			}

			return View(visits.ToList());
		}

		public ActionResult Nowa()
		{

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Nowa(
			[Bind(Include = "PacjentID, DoktorID, Data, Godzina, TypWizyty, Wzrost, Waga, Temperatura, CisnienieKrwi, Objawy, Diagnoza")]
			Wizyta visit)
		{
			try
			{
				if (ModelState.IsValid)
				{
					db.Wizyta.Add(visit);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch (DbUpdateException ex)
			{
				var errorMessage = $"Nie udało się dodać wizyty - {ex.InnerException.InnerException.Message}";

				ViewBag.ErrorMessage = errorMessage;
			}

			return View(visit);
		}

		public ActionResult Edytuj(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var visit = db.Wizyta.Find(id);

			if (visit == null)
				return HttpNotFound();

			return View(visit);
		}

		[HttpPost, ActionName("Edytuj")]
		public ActionResult EdytujPost(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var visitToUpdate = db.Wizyta.Find(id);

			if (TryUpdateModel(visitToUpdate, "",
				new[] { "PacjentID", "DoktorID", "Data", "Godzina", "TypWizyty",
					"Wzrost", "Waga", "Temperatura", "CisnienieKrwi", "Objawy", "Diagnoza" }))
			{
				try
				{
					db.SaveChanges();

					return RedirectToAction("Index");
				}
				catch (DbUpdateException ex)
				{
					var errorMessage = $"Nie udało się edytować wizyty - {ex.InnerException.InnerException.Message}";

					ViewBag.ErrorMessage = errorMessage;
				}
			}

			return View(visitToUpdate);
		}

		public ActionResult Szczegoly(int id)
		{
			var visit = db.Wizyta.Find(id);

			if (visit == null)
				return HttpNotFound();

			return View(visit);
		}

		public ActionResult Usun(int? id, bool? saveChangesError = false)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			if (saveChangesError.GetValueOrDefault())
				ViewBag.ErrorMessage = $"Nie udało się usunąć wizyty o identyfikatorze: {id}";

			var visit = db.Wizyta.Find(id);

			if (visit == null)
				return HttpNotFound();

			return View(visit);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Usun(int id)
		{
			try
			{
				var visit = db.Wizyta.Find(id);
				db.Wizyta.Remove(visit);
				db.SaveChanges();
			}
			catch (Exception)
			{
				return RedirectToAction("Usun", new { id = id, saveChangesError = true });
			}

			return RedirectToAction("Index");
		}

		private readonly KlinikaEntities db;
		private const string Title = "Wizyty pacjentów";
	}
}
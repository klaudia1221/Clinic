using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
	public class PacjenciController : Controller
	{
		public PacjenciController(KlinikaEntities db)
		{
			this.db = db;
			ViewBag.Title = Title;
		}

		public ActionResult Index()
		{
			var patients = db.Pacjent;

			return View(patients.ToList());
		}

		public ActionResult Edytuj(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var patient = db.Pacjent.Find(id);

			if (patient == null)
				return HttpNotFound();

			return View(patient);
		}

		[HttpPost, ActionName("Edytuj")]
		public ActionResult EdytujPost(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var patientToUpdate = db.Pacjent.Find(id);

			if (TryUpdateModel(patientToUpdate, "",
				new[] { "Nazwisko", "Imie", "StanCywilny", "DataUrodzenia", "Plec", "Adres", "NrTelefonu", "Email" }))
			{
				try
				{
					db.SaveChanges();

					return RedirectToAction("Index");
				}
				catch (DbUpdateException ex)
				{
					var errorMessage = $"Nie udało się edytować pacjenta - {ex.InnerException.InnerException.Message}";

					ViewBag.ErrorMessage = errorMessage;
				}
			}

			return View(patientToUpdate);
		}

		public ActionResult Szczegoly(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var patient = db.Pacjent.Find(id);

			if (patient == null)
				return HttpNotFound();

			return View(patient);
		}

		public ActionResult Usun(int? id, bool? saveChangesError = false)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			if (saveChangesError.GetValueOrDefault())
				ViewBag.ErrorMessage = $"Nie udało się usunąć pacjenta o identyfikatorze: {id}";

			var patient = db.Pacjent.Find(id);

			if (patient == null)
				return HttpNotFound();

			return View(patient);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Usun(int id)
		{
			try
			{
				var patient = db.Pacjent.Find(id);
				db.Pacjent.Remove(patient);
				db.SaveChanges();
			}
			catch (Exception)
			{
				return RedirectToAction("Usun", new { id = id, saveChangesError = true });
			}

			return RedirectToAction("Index");
		}

		public ActionResult Nowy()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Nowy(
			[Bind(Include = "Nazwisko, Imie, StanCywilny, DataUrodzenia, Plec, Adres, NrTelefonu, Email")]
			Pacjent patient)
		{
			try
			{
				if (ModelState.IsValid)
				{
					db.Pacjent.Add(patient);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch (DbUpdateException ex)
			{
				var errorMessage = $"Nie udało się dodać pacjenta - {ex.InnerException.InnerException.Message}";

				ViewBag.ErrorMessage = errorMessage;
			}

			return View(patient);
		}

		public ActionResult Historia(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var patientHistory = db.Historia_Pacjenta.Find(id);

			if (patientHistory == null)
				return HttpNotFound();

			return View(patientHistory);
		}

		public ActionResult HistoriaEdytuj(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var patientHistory = db.Historia_Pacjenta.Find(id);

			if (patientHistory == null)
				return HttpNotFound();

			return View(patientHistory);
		}

		[HttpPost, ActionName("HistoriaEdytuj")]
		public ActionResult HistoriaEdytujPost(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var patientHistoryToUpdate = db.Historia_Pacjenta.Find(id);

			if (TryUpdateModel(patientHistoryToUpdate, "",
				new[] { "Odra", "Swinka", "Rozyczka" }))
			{
				try
				{
					db.SaveChanges();

					return RedirectToAction("Historia", new { id = patientHistoryToUpdate.PacjentID});
				}
				catch (DbUpdateException ex)
				{
					var errorMessage = $"Nie udało się edytować historii pacjenta - {ex.InnerException.InnerException.Message}";

					ViewBag.ErrorMessage = errorMessage;
				}
			}

			return View(patientHistoryToUpdate);
		}

		private readonly KlinikaEntities db;
		private const string Title = "Pacjenci";
	}
}
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
	public class PacjenciController : Controller
	{
		public ActionResult Index()
		{
			var patients = db.Pacjent;

			ViewBag.Title = Title;

			return View(patients.ToList());
		}

		// GET
		public ActionResult Edytuj(int? id)
		{
			ViewBag.Title = Title;

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
			ViewBag.Title = Title;

			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var patientToUpdate = db.Pacjent.Find(id);

			if (TryUpdateModel(patientToUpdate, "",
				new [] { "Nazwisko", "Imie", "StanCywilny", "DataUrodzenia", "Plec", "Adres", "NrTelefonu", "Email"}))
			{
				try
				{
					db.SaveChanges();

					return RedirectToAction("Index");
				}
				catch (RetryLimitExceededException) // DbEntityValidationException
				{
					ModelState.AddModelError("", "Error");
				}
			}

			return View(patientToUpdate);
		}

		public ActionResult Szczegoly(int? id)
		{
			ViewBag.Title = Title;

			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var patient = db.Pacjent.Find(id);

			if (patient == null)
				return HttpNotFound();

			return View(patient);
		}

		public ActionResult Usun(int? id, bool? saveChangesError = false)
		{
			ViewBag.Title = Title;
			
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
			catch (RetryLimitExceededException)
			{
				return RedirectToAction("Usun", new { id = id, saveChangesError = true });
			}

			return RedirectToAction("Index");
		}

		private KlinikaEntities db = new KlinikaEntities();
		private const string Title = "Pacjenci";
	}
}
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
    public class DoktorzyController : Controller
    {
        public DoktorzyController(KlinikaEntities db)
        {
            this.db = db;
            ViewBag.Title = Title;
        }

        public ActionResult Index()
        {
            var doctors = db.Doktor;

            return View(doctors.ToList());
        }

        private readonly KlinikaEntities db;
        private const string Title = "Doktorzy";


        public ActionResult Nowy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nowy(
            [Bind(Include = "Nazwisko, Imie, Adres, NrTelefonu, Email, DataUrodzenia, Specjalizacja")] Doktor doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Doktor.Add(doctor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMessage = $"Nie udało się dodać doktora - {ex.InnerException.InnerException.Message}";

                ViewBag.ErrorMessage = errorMessage;
            }

            return View(doctor);
        }
        public ActionResult Edytuj(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var doctor = db.Doktor.Find(id);

            if (doctor == null)
                return HttpNotFound();

            return View(doctor);
        }

        [HttpPost, ActionName("Edytuj")]
        public ActionResult EdytujPost(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var doctorToUpdate = db.Doktor.Find(id);

            if (TryUpdateModel(doctorToUpdate, "",
                new[] { "Nazwisko, Imie, DataUrodzenia, Adres, NrTelefonu, Email, Specjalizacja" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    var errorMessage = $"Nie udało się edytować danych doktora - {ex.InnerException.InnerException.Message}";

                    ViewBag.ErrorMessage = errorMessage;
                }
            }

            return View(doctorToUpdate);
        }

        public ActionResult Szczegoly(int id)
        {
            var doctor = db.Doktor.Find(id);

            if (doctor == null)
                return HttpNotFound();

            return View(doctor);
        }

        public ActionResult Usun(int? id, bool? saveChangesError = false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = $"Nie udało się usunąć doktora o identyfikatorze: {id}";

            var doctor = db.Doktor.Find(id);

            if (doctor == null)
                return HttpNotFound();

            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Usun(int id)
        {
            try
            {
                var doctor = db.Doktor.Find(id);
                db.Doktor.Remove(doctor);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Usun", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }


    }
}
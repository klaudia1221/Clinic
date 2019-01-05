using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    public class ReceptaController : Controller
    {

        public ReceptaController(KlinikaEntities db)
        {
            this.db = db;
            ViewBag.Title = Title;
        }
        // GET: Recepta

        public ActionResult Index(string message)
        {
            var prescriptions = db.Recepta;

            ViewBag.ErrorMessage = message;

            return View(prescriptions.ToList());
        }

        public ActionResult Nowy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nowy(
            [Bind(Include = "PacjentID, DoktorID, Data, Lek, Refundacja, Status")]
            Recepta prescription)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Recepta.Add(prescription);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMessage = $"Nie udało się dodać recepty - {ex.InnerException.InnerException.Message}";

                ViewBag.ErrorMessage = errorMessage;
            }

            return View(prescription);
        }
        public ActionResult Edytuj(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var prescription = db.Recepta.Find(id);

            if (prescription == null)
                return HttpNotFound();

            return View(prescription);
        }

        [HttpPost, ActionName("Edytuj")]
        public ActionResult EdytujPost(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var prescriptionToUpdate = db.Recepta.Find(id);

            if (TryUpdateModel(prescriptionToUpdate, "",
                new[] { "PacjentID, DoktorID, Data, Lek, Refundacja, Status" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    var errorMessage = $"Nie udało się edytować recepty - {ex.InnerException.InnerException.Message}";

                    ViewBag.ErrorMessage = errorMessage;
                }
            }

            return View(prescriptionToUpdate);
        }

        public ActionResult Szczegoly(int id)
        {
            var prescription = db.Recepta.Find(id);

            if (prescription == null)
                return HttpNotFound();

            return View(prescription);
        }

        public ActionResult Usun(int? id, bool? saveChangesError = false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = $"Nie udało się usunąć recepty o identyfikatorze: {id}";

            var prescription = db.Recepta.Find(id);

            if (prescription == null)
                return HttpNotFound();

            return View(prescription);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Usun(int id)
        {
            try
            {
                var prescription = db.Recepta.Find(id);
                db.Recepta.Remove(prescription);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Usun", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }


        private readonly KlinikaEntities db;
        private const string Title = "Recepty";
    }
}
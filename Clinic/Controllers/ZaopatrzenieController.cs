using System;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using Clinic.Models;
using System.Linq;
using System.Net;

namespace Clinic.Controllers
{
    public class ZaopatrzenieController : Controller
    {

        public ZaopatrzenieController(KlinikaEntities db)
        {
            this.db = db;
            ViewBag.Title = Title;
        }
        // GET
        public ActionResult Index()
        {
            var zaopatrzenie = db.Zaopatrzenie;

            return View(zaopatrzenie.ToList());


        }
        public ActionResult Nowy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nowy(
            [Bind(Include = "Nazwa,Opis,Cena,Dostepnosc")]
            Zaopatrzenie zaopatrzenie)
        {
            try
            {
                if (ModelState.IsValid)
                {
             
                    db.Zaopatrzenie.Add(zaopatrzenie);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                var errorMessage = $"Nie udało się dodać zaopatrzenia - {ex.InnerException.InnerException.Message}";

                ViewBag.ErrorMessage = errorMessage;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(zaopatrzenie);
        }
        public ActionResult Edytuj(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var zaopatrzenie = db.Zaopatrzenie.Find(id);

            if (zaopatrzenie == null)
                return HttpNotFound();

            return View(zaopatrzenie);
        }

        [HttpPost, ActionName("Edytuj")]
        public ActionResult EdytujPost(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var zaopatrzenieToUpdate = db.Zaopatrzenie.Find(id);

            TryUpdateModel(zaopatrzenieToUpdate, "",
                new[] {"Nazwa, Opis, Cena, Dostepnosc"});
            
                db.SaveChanges();
                return RedirectToAction("Index");
                //try
                //{
                //    db.SaveChanges();

                //    return RedirectToAction("Index");
                //}
                //catch (DbUpdateException ex)
                //{
                //    var errorMessage = $"Nie udało się edytować zaopatrzenia - {ex.InnerException.InnerException.Message}";

                //    ViewBag.ErrorMessage = errorMessage;
                //}
            

            return View(zaopatrzenieToUpdate);
        }

        public ActionResult Szczegoly(int id)
        {
            var zaopatrzenie = db.Zaopatrzenie.Find(id);

            if (zaopatrzenie == null)
                return HttpNotFound();

            return View(zaopatrzenie);
        }

        public ActionResult Usun(int? id, bool? saveChangesError = false)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = $"Nie udało się usunąć zaopatrzenia o identyfikatorze: {id}";

            var zaopatrzenie = db.Zaopatrzenie.Find(id);

            if (zaopatrzenie == null)
                return HttpNotFound();

            return View(zaopatrzenie);
        }

        [HttpPost]
        public ActionResult Usun(int id)
        {
            try
            {
                var zaopatrzenie = db.Zaopatrzenie.Find(id);
                db.Zaopatrzenie.Remove(zaopatrzenie);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Usun", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }


        private readonly KlinikaEntities db;
        private const string Title = "Zaopatrzenie";
    }
}
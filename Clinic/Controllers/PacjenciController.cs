using System.Linq;
using System.Web.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
	public class PacjenciController : Controller
	{
		public ActionResult Index()
		{
			var db = new KlinikaEntities();
			var patients = db.Pacjent;

			ViewBag.Title = "Pacjenci";

			return View(patients.ToList());
		}

		public ActionResult Edytuj()
		{
			return View();
		}
	}
}
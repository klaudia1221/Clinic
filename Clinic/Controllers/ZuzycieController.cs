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

		private readonly KlinikaEntities db;
		private const string Title = "Pacjenci";
	}
}
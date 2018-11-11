using System.Web.Mvc;

namespace Clinic.Controllers
{
	public class KlinikaController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "System zarządzania kliniką";

			return View();
		}
		public ActionResult Doktor()
		{
			ViewBag.Title = "Doktorzy";

			return View();
		}

		public ActionResult Pacjent()
		{
			ViewBag.Title = "Pacjenci";

			return View();
		}
	}
}
using System.Web.Mvc;

namespace Clinic.Controllers
{
	public class DoktorzyController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Doktorzy";

			return View();
		}
	}
}
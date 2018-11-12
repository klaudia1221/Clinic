using System.Linq;
using System.Web.Mvc;
using Clinic.Models;

namespace Clinic.Controllers
{
	public class KlinikaController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "System zarządzania kliniką";

			return View();
		}
	}
}
﻿using System.Linq;
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
	}
}
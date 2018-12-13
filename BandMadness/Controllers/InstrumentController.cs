using BandMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Controllers
{
	public class InstrumentController : Controller
	{
		#region Add
		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(Instrument instrument)
		{
			BMContext db = new BMContext();
			
			var existing = db.Instruments
				.Where(i => i.Name == instrument.Name)
				.SingleOrDefault();
			if (existing == null)
			{
				db.Instruments.Add(instrument);
				db.SaveChanges();
			}

			return View("Index",db.Instruments);
		}
		#endregion


		#region Index
		[HttpGet]
		public ActionResult Index(IEnumerable<Instrument> instruments)
		{
			if (instruments == null || instruments.Count() == 0)
			{
				var db = new BMContext();

				instruments = db.Instruments
					.ToList();

				return View(instruments);
			}
			return View(instruments.ToList());
		}


		[HttpPost]
		public ActionResult Index(Instrument instrument)
		{
			BMContext db = new BMContext();

			var existing = db.Instruments
				.Where(i => i.Name == instrument.Name)
				.SingleOrDefault();
			if (existing == null)
			{
				db.Instruments.Add(instrument);
				db.SaveChanges();
			}

			return View("Index", db.Instruments.ToList());
		}
		#endregion

		[HttpPost]
		public ActionResult Remove(Instrument instrument)
		{
			ModelState.Clear();
			BMContext db = new BMContext();
			var existing = db.Instruments
				.Where(i => i.Name == instrument.Name)
				.SingleOrDefault();
			db.Instruments.Remove(existing);
			db.SaveChanges();
			return View("Index");
		}

		//[HttpPost]
		//public ActionResult Remove(FormCollection formCollection)
		//{


		//	return View("Index");
		//}
	}
}
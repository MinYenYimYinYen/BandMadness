using BandMadness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Controllers
{
	public class InstrumentController : Controller
	{
		private BMContext db____;
		public BMContext DB
		{
			get
			{
				if (db____ == null)
				{
					db____ = new BMContext();
				}
				return db____;
			}
		}
		
		public ActionResult Index()
		{
			return View(DB.Instruments.ToList());
		}

		[HttpPost]
		public ActionResult Create(Instrument instrument)
		{
			if (ModelState.IsValid)
			{
				var existing = DB.Instruments
					.Where(s => s.Name == instrument.Name)
					.SingleOrDefault();
				if(existing == null)
				{
					DB.Instruments.Add(instrument);
					DB.SaveChanges();
				}
				return View("Index", DB.Instruments.ToList());
			}
			return PartialView("_Invalid");
		}

		public ActionResult Edit(int InstrumentID = -1)
		{
			var DB = new BMContext();
			var instrument = DB.Instruments.Find(InstrumentID);
			if (instrument == null) return View("Index");
			return View(instrument);
		}

		[HttpPost]
		public ActionResult Edit(Instrument instrument)
		{
			if (ModelState.IsValid)
			{
				//happy path
				DB.Entry(instrument).State = EntityState.Modified;
				DB.SaveChanges();
				return View("Index", DB.Instruments.ToList());
			}
			//sad path
			return View("Edit", instrument);
		}

		[HttpPost]
		public ActionResult Delete(Instrument song)
		{
			var DB = new BMContext();

			try
			{
				song = DB.Instruments.Find(song.InstrumentID);
				DB.Instruments.Remove(song);
				DB.SaveChanges();
				return View("Index", DB.Instruments.ToList());
			}
			catch
			{
				return View("Edit", song);
			}
		}


	}
}
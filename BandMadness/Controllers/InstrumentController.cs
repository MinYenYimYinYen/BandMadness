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
				if (existing == null)
				{
					DB.Instruments.Add(instrument);
					DB.SaveChanges();
				}
				return RedirectToAction("Index", DB.Instruments.ToList());
			}
			return View("Index", DB.Instruments.ToList());
		}

		[HttpGet] //https://www.codeproject.com/Articles/1063846/%2FArticles%2F1063846%2FStep-By-Step-Implementation-of-MultiSelectList-In
		public ActionResult Edit(int InstrumentID = -1)
		{
			var instrument = DB.Instruments.Find(InstrumentID);
			return View(instrument);
		}

		[HttpPost]
		public ActionResult Edit(Instrument instrument)
		{
			if (ModelState.IsValid)
			{
				Instrument dbInstrument = DB.Instruments.Find(instrument.InstrumentID);

				#region Primitives
				dbInstrument.Name = instrument.Name;
				#endregion

				#region ManyMembers
				dbInstrument.Members.Clear();
				foreach (var inst in instrument.MemberSelection.MemberIDs)
				{
					var id = Convert.ToInt32(inst);
					dbInstrument.Members.Add(DB.Members.Find(id));
				}
				#endregion

				DB.SaveChanges();
				return RedirectToAction("Index", DB.Instruments.ToList());
			}
			return View(instrument);
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
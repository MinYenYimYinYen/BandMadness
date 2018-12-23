using BandMadness.Models;
using BandMadness.Views.Instrument.ViewModels;
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

		[HttpGet] //https://www.codeproject.com/Articles/1063846/%2FArticles%2F1063846%2FStep-By-Step-Implementation-of-MultiSelectList-In
		public ActionResult Edit(int InstrumentID = -1)
		{
			var instrument = DB.Instruments.Find(InstrumentID);


			//var allMembers = DB.Members.ToList();
			//List<SelectListItem> slMembers = new List<SelectListItem>();
			//foreach(var memb in allMembers)
			//{
			//	var slMember = new SelectListItem
			//	{
			//		Value = memb.MemberID.ToString(),
			//		Text = memb.DisplayName,
			//		Selected = instrument.Members.Contains(memb) ? true : false
			//	};
			//	slMembers.Add(slMember);
			//}
			//var selected = slMembers.Where(slm => slm.Selected).Select(slm => slm.Value).ToList();
			//MultiSelectList MembList = new MultiSelectList
			//	(slMembers.OrderBy(m => m.Text), "Value", "Text", selected);
			//InstrumentEdit model = new InstrumentEdit { SLMembers = MembList };
			//model.Instrument = instrument;
			return View(instrument);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit( Instrument instrument)
		{
			if (ModelState.IsValid)
			{
				//happy path
				DB.Entry(instrument).State = EntityState.Modified;
				List<Member> addThese = new List<Member>();
				foreach(var memb in instrument.MemberSelection.MemberStringIDs)
				{
					var id = Convert.ToInt32(memb);
					addThese.Add(DB.Members.Find(id));
				}
				instrument.Members.Clear();
				instrument.Members.AddRange(addThese);


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
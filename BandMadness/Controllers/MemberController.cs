using BandMadness.Models;
using BandMadness.Views.Member.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Controllers
{
	public class MemberController : Controller
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
			return View(DB.Members.ToList());
		}

		[HttpPost]
		public ActionResult Create(Member member)
		{
			if (ModelState.IsValid)
			{
				var existing = DB.Members
					.Where(s => s.FirstName + s.LastName == member.FirstName + member.LastName)
					.SingleOrDefault();
				if (existing == null)
				{
					DB.Members.Add(member);
					DB.SaveChanges();
					return View("Index", DB.Members.ToList());
				}
				return PartialView("_AlreadyExists");
			}
			return PartialView("_Invalid");
		}

		[HttpGet]
		public ActionResult Edit(int MemberID = -1)
		{
			var member = DB.Members.Find(MemberID);

			var allInstruments = DB.Instruments.ToList();

			List<SelectListItem> items = new List<SelectListItem>();
			foreach (var inst in allInstruments)
			{
				var item = new SelectListItem
				{
					Value = inst.InstrumentID.ToString(),
					Text = inst.Name,
					Selected = member.Instruments.Contains(inst) ? true : false
				};
				items.Add(item);
			}
			var selected = items.Where(i => i.Selected).Select(i => i.Value).ToList();
			MultiSelectList instList = new MultiSelectList
				(items.OrderBy(i => i.Text), "Value", "Text", selected);
			MemberEdit model = new MemberEdit { SLInstruments = instList };
			model.Member = member;


			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Member,InstrumentIDs")]MemberEdit memberEdit)
		{
			if (ModelState.IsValid)
			{
				var member = DB.Members.Find(memberEdit.Member.MemberID);
				member.FirstName = memberEdit.Member.FirstName;
				member.LastName = memberEdit.Member.LastName;
				member.Alias = memberEdit.Member.Alias;


				List<Instrument> addThese = new List<Instrument>();
				foreach (var inst in memberEdit.InstrumentIDs)
				{
					var id = Convert.ToInt32(inst);
					addThese.Add(DB.Instruments.Find(id));
				}
				member.Instruments.Clear();
				member.Instruments.AddRange(addThese);
				
				DB.SaveChanges();
			}
			return View("Index",DB.Members.ToList());
		}

		[HttpPost]
		public ActionResult Delete(Member member)
		{
			var DB = new BMContext();

			try
			{
				member = DB.Members.Find(member.MemberID);
				DB.Members.Remove(member);
				DB.SaveChanges();
				return View("Index", DB.Members.ToList());
			}
			catch
			{
				return View("Edit", member);
			}
		}
	}
}
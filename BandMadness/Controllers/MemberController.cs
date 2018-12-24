using BandMadness.Models;
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

		[HttpGet] //https://www.codeproject.com/Articles/1063846/%2FArticles%2F1063846%2FStep-By-Step-Implementation-of-MultiSelectList-In
		public ActionResult Edit(int MemberID = -1)
		{
			var member = DB.Members.Find(MemberID);
			return View(member);
		}

		[HttpPost]
		public ActionResult Edit(Member member)
		{
			if (ModelState.IsValid)
			{
				Member dbMember = DB.Members.Find(member.MemberID);
				dbMember.Instruments.Clear();
				foreach (var inst in member.InstrumentSelection.InstrumentIDs)
				{
					var id = Convert.ToInt32(inst);
					dbMember.Instruments.Add(DB.Instruments.Find(id));
				}
				DB.SaveChanges();
				return View("Index",DB.Members.ToList());
			}
			return View(member);
		}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit([Bind(Include = "Member,InstrumentIDs")]MemberEdit memberEdit)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		DB.Entry(memberEdit.Member).State = EntityState.Modified;


		//		List<Instrument> addThese = new List<Instrument>();
		//		foreach (var inst in memberEdit.InstrumentIDs)
		//		{
		//			var id = Convert.ToInt32(inst);
		//			addThese.Add(DB.Instruments.Find(id));
		//		}
		//		memberEdit.Member.Instruments.Clear();
		//		memberEdit.Member.Instruments.AddRange(addThese);

		//		DB.SaveChanges();
		//	}
		//	return View("Index",DB.Members.ToList());
		//}

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
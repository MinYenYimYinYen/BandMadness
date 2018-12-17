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

		public ActionResult Edit(int MemberID = -1)
		{
			var DB = new BMContext();
			var member = DB.Members.Find(MemberID);
			if (member == null) return View("Index");

			//ViewBag.DefaultInstrumentID = new SelectList(DB.Instruments, "InstrumentID", "Name", member.DefaultInstrumentID);
			return View(member);
		}

		[HttpPost]
		public ActionResult Edit(Member member)
		{
			if (ModelState.IsValid)
			{
				//happy path
				DB.Entry(member).State = EntityState.Modified;
				DB.SaveChanges();
				return View("Index", DB.Members.ToList());
			}
			//sad path
			return View("Edit", member);
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
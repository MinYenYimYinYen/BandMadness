using BandMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Controllers
{

	public class MemberController : Controller
	{
		#region Create
		[HttpGet]
		public ActionResult Add()
		{
			var db = new BMContext();

			ViewBag.DefaultInstrumentID = new SelectList(db.Instruments, "InstrumentID", "Name");

			return View();
		}

		[HttpPost]
		public ActionResult Add(Member member)
		{
			using (BMContext db = new BMContext())
			{
				var existing = db.Members
					.Where(m => m.FirstName + m.Alias == member.FirstName + m.Alias)
					.SingleOrDefault();
				if(existing == null)
				{
					db.Members.Add(member);
					db.SaveChanges();
				}
			}
			return View("Details",member);
		}
		#endregion
		#region Details
		[HttpGet]
		public ActionResult Details(Member member)
		{

			return View(member);
		}
		[HttpGet]
		public ActionResult Details(string name)
		{
			Member member = null;
			using (BMContext db = new BMContext())
			{
				member = db.Members.Where(m => m.FirstName == name).FirstOrDefault();
				if (member == null)
				{
					member = db.Members.Where(m => m.LastName == name).FirstOrDefault();
					if (member == null)
					{
						member = db.Members.Where(m => m.Alias == name).FirstOrDefault();
					}
				}
			}

			return View(member);
		}
		#endregion


	}
}
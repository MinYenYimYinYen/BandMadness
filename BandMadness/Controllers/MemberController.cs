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
		// GET: Member
		public ActionResult Details()
		{
			Member member = new Member
			{
				FirstName = "Adam",
				LastName = "Pfuhl"
			};
			return View(member);
		}
	}
}
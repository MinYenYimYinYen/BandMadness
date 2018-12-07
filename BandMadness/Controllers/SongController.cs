using BandMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Controllers
{
	public class SongController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			var db = new BMContext();
			return View(db.Songs.ToList());
		}
	}
}
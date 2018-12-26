using BandMadness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Controllers
{
	public class SongController : Controller
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
			return View(DB.Songs.ToList());
		}

		[HttpPost]
		public ActionResult Create(Song song)
		{
			if (ModelState.IsValid)
			{
				var existing = DB.Songs
					.Where(s => s.Title == song.Title)
					.SingleOrDefault();
				if (existing == null)
				{
					DB.Songs.Add(song);
					DB.SaveChanges();
					return View("Index", DB.Songs.ToList());
				}
				return PartialView("_AlreadyExists");
			}
			return PartialView("_Invalid");
		}

		public ActionResult Edit(int SongID = -1)
		{
			var song = DB.Songs.Find(SongID);
			return View(song);
		}

		//[HttpPost]
		//public ActionResult Edit(Song song)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		Song dbSong = DB.Songs.Find(song.SongID);


		//	}
		//}
		[HttpPost]
		public ActionResult AddPilot()
		{
			var pilot = new RecPilot();
			if (TryUpdateModel(pilot))
			{
				DB.Recordings.Add(pilot);
				DB.SaveChanges();
				return RedirectToAction("Edit", DB.Songs.Find(pilot.SongID));
			}
			else
			{
				var x = ModelState;
				ModelState modelstate;
				var songID = x.TryGetValue("SongID", out modelstate);
				return View("Edit",  DB.Songs.Find(Convert.ToInt32(modelstate.Value.AttemptedValue)));
			}

		}


		[HttpPost]
		public ActionResult Delete(Song song)
		{
			var DB = new BMContext();

			try
			{
				song = DB.Songs.Find(song.SongID);
				DB.Songs.Remove(song);
				DB.SaveChanges();
				return View("Index", DB.Songs.ToList());
			}
			catch
			{
				return View("Edit", song);
			}
		}
	}
}

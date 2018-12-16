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
					//return RedirectToAction("Index");

				}
				return PartialView("_AlreadyExists");
			}
			return PartialView("_Invalid");
		}

		// GET: Song/Edit/5
		public ActionResult Edit(int SongID = -1)
		{
			var DB = new BMContext();
			var song = DB.Songs.Find(SongID);
			if (song == null) return View("Index");
			return View(song);
		}

		// POST: Song/Edit/5
		[HttpPost]
		public ActionResult Edit(Song song)
		{
			if (ModelState.IsValid)
			{
				//happy path
				DB.Entry(song).State = EntityState.Modified;
				DB.SaveChanges();
				return View("Index", DB.Songs.ToList());
			}
			//sad path
			return View("Edit", song);
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

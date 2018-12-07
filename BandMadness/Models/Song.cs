using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Song
	{
		public virtual List<Arrangement> Arrangements { get; set; }

		public int SongID { get; set; }
		public String Title { get; set; }

	}
}
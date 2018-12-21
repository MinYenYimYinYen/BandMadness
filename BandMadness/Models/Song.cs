using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Song
	{
		

		public int SongID { get; set; }

		//[MaxLength(256)]
		public string Title { get; set; }

		public string Folder { get; set; }


	}
}
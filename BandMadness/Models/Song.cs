using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Song
	{
		//public virtual List<RecPilot> RecPilots { get; set; }
		//public virtual List<RecAlbum> RecAlbums { get; set; }
		public virtual List<Recording> Recordings { get; set; }

		public int SongID { get; set; }

		//[MaxLength(256)]
		public string Title { get; set; }

		//public string Folder { get; set; }


	}
}
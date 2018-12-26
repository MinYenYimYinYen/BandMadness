using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class RecAlbum : Recording
	{
		public RecAlbum()
		{
		}

		public RecAlbum(int songID = -1) : base(songID)
		{
		}
	}
}
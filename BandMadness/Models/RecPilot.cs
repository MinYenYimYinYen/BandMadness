using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class RecPilot : Recording
	{
		public RecPilot()
		{
		}

		public RecPilot(int songID = -1) : base(songID)
		{
		}
	}
}
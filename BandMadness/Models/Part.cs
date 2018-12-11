using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{

	public class Part
	{
		public virtual Arrangement Arrangement { get; set; }
		public virtual Instrument Instrument { get; set; }
		public virtual Member Member { get; set; }

		public int  PartID { get; set; }

	}
}
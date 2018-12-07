using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Instrument
	{
		#region Region
		public virtual IList<Member> Members { get; set; }
		#endregion
		public int InstrumentID { get; set; }
		public string Name { get; set; }
	}
}
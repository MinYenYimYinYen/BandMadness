using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Instrument
	{
		public Instrument()
		{
			Members = new List<Member>();
		}
		#region Relational
		public virtual List<Member> Members { get; set; }
		//public virtual List<int> MemberIDs { get; set; }
		#endregion
		public int InstrumentID { get; set; }
		public string Name { get; set; }
	}
}
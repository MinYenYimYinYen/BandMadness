using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public virtual List<Recording> Recordings { get; set; }


		#endregion
		public int InstrumentID { get; set; }

		[Required][StringLength(128,MinimumLength =2)]
		public string Name { get; set; }
	}
}
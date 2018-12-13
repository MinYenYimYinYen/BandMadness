using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	[Table("Member")]
	public class Member
	{
		#region Relationships
		public virtual List<Instrument> Instruments { get; set; }
		public virtual List<Part> Parts { get; set; }
		[ForeignKey("DefaultInstrumentID")]
		public virtual Instrument DefaultInstrument { get; set; }
		#endregion

		public int MemberID { get; set; }
		public int? DefaultInstrumentID { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Alias { get; set; }

	}
}
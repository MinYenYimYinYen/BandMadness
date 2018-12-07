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
		public virtual ICollection<Instrument> Instruments { get; set; }
		#endregion

		public int MemberID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
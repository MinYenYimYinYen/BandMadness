using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Member
	{
		public Member()
		{
			Instruments = new List<Instrument>();
		}

		#region Relationships
		public virtual List<Instrument> Instruments { get; set; }
		//public virtual List<int> InstrumentIDs { get; set; }

		#endregion

		public int MemberID { get; set; }

		[MaxLength(64)]
		public string FirstName { get; set; }
		[MaxLength(64)]
		public string LastName { get; set; }
		[MaxLength(64)]
		public string Alias { get; set; }

		public string DisplayName
		{
			get
			{
				return string.IsNullOrWhiteSpace(Alias) ? FirstName + " " + LastName : Alias;
			}
		}


	}
}
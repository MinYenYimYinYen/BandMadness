using BandMadness.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Instrument : IHaveMembers
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

		[Required]
		//[Display(Name ="Instrument Type")]
		[StringLength(128, MinimumLength = 2, ErrorMessage = "Instrument Type must be between 2-128 characters long.")]
		public string Name { get; set; }


		#region ViewModel
		private MemberSelection memberSelection;
		[NotMapped]
		public MemberSelection MemberSelection
		{
			get
			{
				if (memberSelection == null)
				{
					memberSelection = new MemberSelection(this);
				}
				return memberSelection;
			}
			set
			{
				memberSelection = value;
			}
		}


		#endregion


	}
}
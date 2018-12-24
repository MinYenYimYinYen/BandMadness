using BandMadness.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Member : IHaveInstruments
	{
		public Member()
		{
			Instruments = new List<Instrument>();
		}

		#region Relationships
		public virtual List<Instrument> Instruments { get; set; }
		public virtual List<Recording> Recordings { get; set; }

		#endregion

		public int MemberID { get; set; }

		[Required]
		[Display(Name = "First Name")]
		[MaxLength(64)]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		[MaxLength(64)]
		public string LastName { get; set; }

		[Required]
		[Display(Name = "Alias")]
		[MaxLength(64)]
		public string Alias { get; set; }

		public string DisplayName
		{
			get
			{
				return string.IsNullOrWhiteSpace(Alias) ? FirstName + " " + LastName : Alias;
			}
		}

		#region ViewModel
		private InstrumentSelection instrumentSelection;
		[NotMapped]
		public InstrumentSelection InstrumentSelection
		{
			get
			{
				if (instrumentSelection == null)
				{
					instrumentSelection = new InstrumentSelection(this);
				}
				return instrumentSelection;
			}
			set
			{
				instrumentSelection = value;
			}
			#endregion
		}
	}
}
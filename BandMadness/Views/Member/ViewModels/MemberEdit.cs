using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Views.Member.ViewModels
{
	public class MemberEdit
	{
		public MemberEdit()
		{
			InstrumentIDs = new List<string>();
		}

		public List<string> InstrumentIDs { get; set; }

		[Display(Name ="SLInstruments")]
		public MultiSelectList SLInstruments { get; set; }

		public Models.Member Member { get; set; }
	}
}
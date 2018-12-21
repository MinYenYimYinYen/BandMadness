using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Views.Instrument.ViewModels
{
	public class InstrumentEdit
	{
		public List<string> MemberIDs { get; set; }
		[DisplayName("SLMembers")]
		public MultiSelectList	SLMembers{ get; set; }
		public Models.Instrument Instrument { get; set; }

	}
}
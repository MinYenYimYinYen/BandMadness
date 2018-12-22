using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public abstract class Recording
	{
		public virtual int SongID { get; set; }
		public virtual Song Song { get; set; }

		public virtual int InstrumentID { get; set; }
		public virtual Instrument Instrument { get; set; }

		public virtual int MemberID { get; set; }
		public virtual Member Member { get; set; }

		public int RecordingID { get; set; }
		

	}
}
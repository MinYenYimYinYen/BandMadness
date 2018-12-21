using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public abstract class Recording
	{
		//[ForeignKey("SongID")]
		public virtual int SongID { get; set; }
		public virtual Song Song { get; set; }

		//[ForeignKey("InstrumentID")]
		public virtual int InstrumentID { get; set; }
		public virtual Instrument Instrument { get; set; }
		//[ForeignKey("MemberID")]
		public virtual int MemberID { get; set; }
		public virtual Member Member { get; set; }

		public int RecordingID { get; set; }
		

	}
}
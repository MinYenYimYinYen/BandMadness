using BandMadness.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public abstract class Recording : IValidatableObject, IHaveMember, IHaveInstrument
	{
		public Recording() { }
		public Recording(int songID = -1)
		{
			SongID = songID;
			Song = new BMContext().Songs.Find(songID);
		}


		public virtual int SongID { get; set; }
		private Song song;
		public virtual Song Song
		{
			get
			{
				if(song == null)
				{
					song = new BMContext().Songs.Find(SongID);
				}
				return song;
			}
			set { song = value; }
		}


		public int InstrumentID { get; set; }
		public virtual Instrument Instrument { get; set; }


		public int MemberID { get; set; }
		public virtual Member Member { get; set; }


		[Display(Name = "Folder Path")]
		public string FolderPath { get; set; }

		[Display(Name = "File Name")]
		public string FileName { get; set; }
		public DateTime? SubmitDate { get; set; }

		public int RecordingID { get; set; }

		#region ViewModel
		private MemberSelection memberSelection;
		[NotMapped]
		public MemberSelection MemberSelection
		{
			get
			{
				if (memberSelection == null)
				{
					memberSelection = new MemberSelection();
				}
				return memberSelection;
			}
			set
			{
				memberSelection = value;
			}
		}

		private InstrumentSelection instrumentSelection;
		[NotMapped]
		public InstrumentSelection InstrumentSelection
		{
			get
			{
				if (instrumentSelection == null)
				{
					instrumentSelection = new InstrumentSelection();
				}
				return instrumentSelection;
			}
			set
			{
				instrumentSelection = value;
			}
		}

		#endregion

		//Page 154 ToDo: Test Enforce One to One filepath to recording object
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var db = new BMContext();

			#region Enforce one file per recording object

			var existingPath = db.Recordings
				.Where(r => (r.FolderPath + r.FileName)
					.Trim().ToLower()
				== (FolderPath + FileName)
					.Trim().ToLower()
					).SingleOrDefault();
			if (existingPath != null)
			{
				yield return new ValidationResult
					(
						"This file name has already been assigned.",
						new[] { "FolderPath", "FileName" }
					);
			}
			#endregion


		}
	}
}
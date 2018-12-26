using BandMadness.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Song
	{
		public virtual List<Recording> Recordings { get; set; }

		private List<RecPilot> pilotTracks;
		[NotMapped]
		public List<RecPilot> PilotTracks
		{
			get
			{
				pilotTracks = Recordings.OfType<RecPilot>()
					.OrderBy(r =>r.Instrument==null? r.InstrumentID.ToString():  r.Instrument.Name)
					.ThenByDescending(r => r.SubmitDate)
					.ToList();

				return pilotTracks;
			}
		}


		private List<RecAlbum> albumTracks;
		[NotMapped]
		public List<RecAlbum> AlbumTracks
		{
			get
			{
				albumTracks = Recordings.OfType<RecAlbum>()
					.OrderBy(r => r.Instrument.Name)
					.ThenByDescending(r => r.SubmitDate)
					.ToList();

				return albumTracks;
			}
		}

		public int SongID { get; set; }

		[StringLength(128)]
		[Required(ErrorMessage ="Song must have a name")]
		public string Title { get; set; }

		[DataType(DataType.MultilineText)]
		public string Lyrics { get; set;}

		[DataType(DataType.MultilineText)]
		public string Notes { get; set; }
		
		[DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "#.00 bpm")]
		public double? Tempo { get; set; }



		//public string Folder { get; set; }


	}
}
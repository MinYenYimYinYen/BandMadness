using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Models.ManyToMany
{
	public class InstrumentSelection
	{
		public InstrumentSelection() { }
		public InstrumentSelection(IHaveInstruments iInstruments)
		{
			IHaveInstruments = iInstruments;
		}
		public readonly IHaveInstruments IHaveInstruments;
		public readonly Song Song;

		private BMContext db____;
		public BMContext DB
		{
			get
			{
				if (db____ == null)
				{
					db____ = new BMContext();
				}
				return db____;
			}
		}

		public MultiSelectList MultiSelectList
		{
			get
			{
				if (IHaveInstruments == null) throw new Exception("MultiSelectList only available to IHaveInstruments");
				var instruments = DB.Instruments.ToList().OrderBy(i => i.Name);
				var selectedInstrumentIDs = IHaveInstruments.Instruments.Select(i => i.InstrumentID).ToList();
				var selected = new List<int>();
				foreach (var instrument in instruments)
				{
					if (selectedInstrumentIDs.Contains(instrument.InstrumentID))
					{
						selected.Add(instrument.InstrumentID);
					}
				}
				return new MultiSelectList(instruments, "InstrumentID", "Name", selected);
			}
		}

		public SelectList SelectList
		{
			get
			{
				var db = new BMContext();
				var instruments = db.Instruments
					.OrderBy(m => m.Name)
					.AsEnumerable()
					.Select(m => new SelectListItem
					{
						Value = m.InstrumentID.ToString(),
						Text = m.Name
					});
				return new SelectList(instruments, "Value", "Text", null); //5th overload. 
			}
		}


		public List<string> InstrumentIDs { get; set; }







	}
}
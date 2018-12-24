using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Models.ManyToMany
{
	public class InstrumentSelection
	{
		public InstrumentSelection(IHaveInstruments iInstruments)
		{
			IHaveInstruments = iInstruments;
		}
		public IHaveInstruments IHaveInstruments { get; set; }

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
				var instruments = DB.Instruments.ToList().OrderBy(i => i.Name);
				var selected = instruments
					.Union(IHaveInstruments.Instruments)
					.Select(i=>i.InstrumentID) // I think this is the key
					.Distinct()
					.ToList();
				return new MultiSelectList(instruments,"InstrumentID","Name",selected);
			}
		}


		public List<string> InstrumentIDs { get; set; }

		//THIS IS LEAVING OFF AT BULLET POINT 3.  STILL NEED TO IMPLEMENT AS SUCH ON iHAVEMEMBERS



		//private List<SelectListItem> sliInstruments;
		//public List<SelectListItem> GetInstrumentSelectListItems()
		//{
		//	//if (sliInstruments == null)
		//	{
		//		sliInstruments = new List<SelectListItem>();
		//		foreach (var inst in DB.Instruments)
		//		{
		//			var slInstrument = new SelectListItem
		//			{
		//				Value = inst.InstrumentID.ToString(),
		//				Text = inst.Name,
		//				Selected =
		//					IHaveInstruments
		//					.Instruments
		//					.Select(m => m.InstrumentID)
		//					.Contains(inst.InstrumentID) ? true : false
		//			};
		//			sliInstruments.Add(slInstrument);
		//		}
		//	}
		//	return sliInstruments;
		//}

		//private MultiSelectList mslInstruments;
		//public MultiSelectList MSLInstruments
		//{
		//	get
		//	{
		//		//if (mslInstruments == null)
		//		{
		//			var items = GetInstrumentSelectListItems();

		//			var selected =
		//				items
		//				.Where(slm => slm.Selected)
		//				.Select(slm => slm)
		//				.ToList();

		//			mslInstruments = new MultiSelectList
		//				(items.OrderBy(m => m.Text), "Value", "Text", selected);
		//		}
		//		return mslInstruments;
		//	}
		//}

		//private List<string> instrumentStringIDs;
		//public List<string> InstrumentStringIDs
		//{
		//	get
		//	{
		//		if (instrumentStringIDs == null) instrumentStringIDs = new List<string>();
		//		return instrumentStringIDs;
		//	}
		//	set
		//	{
		//		instrumentStringIDs = value;
		//	}
		//}





	}
}
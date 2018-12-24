using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models.ManyToMany
{
	public interface IHaveInstruments
	{
		List<Instrument> Instruments { get; set; }
		InstrumentSelection InstrumentSelection { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models.ManyToMany
{
	public interface IHaveInstruments:IHaveInstrument
	{
		List<Instrument> Instruments { get; set; }
		
	}

	public interface IHaveInstrument
	{
		InstrumentSelection InstrumentSelection { get; set; }
	}
}
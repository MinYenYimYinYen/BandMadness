using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class Arrangement
	{
		public virtual Song Song { get; set; }

		public int ArrangementID { get; set; }

	}
}
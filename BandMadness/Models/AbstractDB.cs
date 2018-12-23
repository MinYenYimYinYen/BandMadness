using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	/// <summary>
	/// This inhereted by Entity Frameword.  Properties in here must be read only.
	/// </summary>
	public abstract class AbstractDB
	{
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
	}
}
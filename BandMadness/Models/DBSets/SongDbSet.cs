using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BandMadness.Models.DBSets
{
	public class SongDbSet:DbSet
	{
		public override object Add(object entity)
		{

			return base.Add(entity);
		}
	}
}
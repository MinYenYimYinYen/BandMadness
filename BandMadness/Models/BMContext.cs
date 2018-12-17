using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BandMadness.Models
{
	public class BMContext : DbContext
	{
		public DbSet<Member> Members { get; set; }
		public DbSet<Instrument> Instruments { get; set; }
		public DbSet<Song> Songs { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//Configure modelBuilder
			modelBuilder.HasDefaultSchema("dbo");
			//modelBuilder.Conventions.Add<PluralizingTableNameConvention>();

			//Create vars for entities
			var members = modelBuilder.Entity<Member>();
			var instruments = modelBuilder.Entity<Instrument>();
			var songs = modelBuilder.Entity<Song>();

			//Configure Relationships
			members
				.HasMany(m => m.Instruments)
				.WithMany(i => i.Members)
				.Map(mi =>
				{
					mi.MapLeftKey("InstrumentRefID");
					mi.MapRightKey("MemberRefID");
					mi.ToTable("MemberInstrument");
				});

		





		}



	}
}
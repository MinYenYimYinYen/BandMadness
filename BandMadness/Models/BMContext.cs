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
		public DbSet<Recording> Recordings { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			

			//Configure modelBuilder
			modelBuilder.HasDefaultSchema("dbo");
			//modelBuilder.Conventions.Add<PluralizingTableNameConvention>();

			//Create vars for entities
			var member = modelBuilder.Entity<Member>();
			var instrument = modelBuilder.Entity<Instrument>();
			var song = modelBuilder.Entity<Song>();
			var recording = modelBuilder.Entity<Recording>();

			member.ToTable("Member");
			instrument.ToTable("Instrument");
			song.ToTable("Song");
			recording.ToTable("Recordings");

			//Configure Relationships
			member
				.HasMany(m => m.Instruments)
				.WithMany(i => i.Members)
				.Map(mi =>
				{
					mi.MapLeftKey("MemberRefID");
					mi.MapRightKey("InstrumentRefID");
					mi.ToTable("MemberInstrument");
				});

			recording
				.HasRequired(r => r.Song)
				.WithMany(s => s.Recordings)
				.HasForeignKey(fk=>fk.SongID);

			recording
				.HasRequired(r => r.Member)
				.WithMany(s => s.Recordings)
				.HasForeignKey(fk => fk.MemberID);

			recording
				.HasRequired(r => r.Instrument)
				.WithMany(s => s.Recordings)
				.HasForeignKey(fk => fk.InstrumentID);










		}

		

	}
}
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
		public DbSet<Arrangement> Arrangements { get; set; }
		public DbSet<Part> Parts { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//Configure modelBuilder
			modelBuilder.HasDefaultSchema("dbo");
			//modelBuilder.Conventions.Add<PluralizingTableNameConvention>();

			//Create vars for entities
			var members = modelBuilder.Entity<Member>();
			var instruments = modelBuilder.Entity<Instrument>();
			var songs = modelBuilder.Entity<Song>();
			var arrangements = modelBuilder.Entity<Arrangement>();
			var parts = modelBuilder.Entity<Part>();

			//Map Entities to Tables
			members.ToTable("Member");
			instruments.ToTable("Instrument");
			songs.ToTable("Song");
			arrangements.ToTable("Arrangement");
			parts.ToTable("Part");

			//Configure Primary Keys
			members.HasKey(m => m.MemberID);
			instruments.HasKey(i => i.InstrumentID);
			songs.HasKey(s => s.SongID);
			arrangements.HasKey(a => a.ArrangementID);

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

			songs
				.HasMany(s => s.Arrangements)
				.WithOptional(a => a.Song)
				.Map(sa =>
				{
					sa.MapKey("SongID");
				});

			arrangements
				.HasMany(a => a.Parts)
				.WithRequired(p => p.Arrangement)
				.Map(m =>
				{
					m.MapKey("ArrangementID");
				});

			parts
				.HasRequired(p => p.Member)
				.WithMany(m => m.Parts)
				.Map(m =>
				{
					m.MapKey("MemberID");
				});






		}
	}
}
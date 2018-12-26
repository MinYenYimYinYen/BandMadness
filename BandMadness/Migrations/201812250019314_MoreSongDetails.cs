namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreSongDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Song", "Lyrics", c => c.String());
            AddColumn("dbo.Song", "Notes", c => c.String());
            AddColumn("dbo.Song", "Tempo", c => c.Double());
            AlterColumn("dbo.Song", "Title", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Song", "Title", c => c.String());
            DropColumn("dbo.Song", "Tempo");
            DropColumn("dbo.Song", "Notes");
            DropColumn("dbo.Song", "Lyrics");
        }
    }
}

namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongsArrangements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arrangement",
                c => new
                    {
                        ArrangementID = c.Int(nullable: false, identity: true),
                        SongID = c.Int(),
                    })
                .PrimaryKey(t => t.ArrangementID)
                .ForeignKey("dbo.Song", t => t.SongID)
                .Index(t => t.SongID);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.SongID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arrangement", "SongID", "dbo.Song");
            DropIndex("dbo.Arrangement", new[] { "SongID" });
            DropTable("dbo.Song");
            DropTable("dbo.Arrangement");
        }
    }
}

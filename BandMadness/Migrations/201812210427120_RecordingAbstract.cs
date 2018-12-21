namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecordingAbstract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recordings",
                c => new
                    {
                        RecordingID = c.Int(nullable: false, identity: true),
                        SongID = c.Int(nullable: false),
                        InstrumentID = c.Int(nullable: false),
                        MemberID = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RecordingID)
                .ForeignKey("dbo.Instrument", t => t.InstrumentID, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Song", t => t.SongID, cascadeDelete: true)
                .Index(t => t.SongID)
                .Index(t => t.InstrumentID)
                .Index(t => t.MemberID);
            
            DropColumn("dbo.Song", "Folder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Song", "Folder", c => c.String());
            DropForeignKey("dbo.Recordings", "SongID", "dbo.Song");
            DropForeignKey("dbo.Recordings", "MemberID", "dbo.Member");
            DropForeignKey("dbo.Recordings", "InstrumentID", "dbo.Instrument");
            DropIndex("dbo.Recordings", new[] { "MemberID" });
            DropIndex("dbo.Recordings", new[] { "InstrumentID" });
            DropIndex("dbo.Recordings", new[] { "SongID" });
            DropTable("dbo.Recordings");
        }
    }
}

namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedUnusedClasses : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Instrument", newName: "Instruments");
            RenameTable(name: "dbo.Song", newName: "Songs");
            DropForeignKey("dbo.Part", "Instrument_InstrumentID", "dbo.Instrument");
            DropForeignKey("dbo.Part", "MemberID", "dbo.Member");
            DropForeignKey("dbo.Part", "ArrangementID", "dbo.Arrangement");
            DropForeignKey("dbo.Arrangement", "SongID", "dbo.Song");
            DropIndex("dbo.Arrangement", new[] { "SongID" });
            DropIndex("dbo.Part", new[] { "Instrument_InstrumentID" });
            DropIndex("dbo.Part", new[] { "MemberID" });
            DropIndex("dbo.Part", new[] { "ArrangementID" });
            AddColumn("dbo.Songs", "Folder", c => c.String());
            DropTable("dbo.Arrangement");
            DropTable("dbo.Part");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Part",
                c => new
                    {
                        PartID = c.Int(nullable: false, identity: true),
                        Instrument_InstrumentID = c.Int(),
                        MemberID = c.Int(nullable: false),
                        ArrangementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PartID);
            
            CreateTable(
                "dbo.Arrangement",
                c => new
                    {
                        ArrangementID = c.Int(nullable: false, identity: true),
                        SongID = c.Int(),
                    })
                .PrimaryKey(t => t.ArrangementID);
            
            DropColumn("dbo.Songs", "Folder");
            CreateIndex("dbo.Part", "ArrangementID");
            CreateIndex("dbo.Part", "MemberID");
            CreateIndex("dbo.Part", "Instrument_InstrumentID");
            CreateIndex("dbo.Arrangement", "SongID");
            AddForeignKey("dbo.Arrangement", "SongID", "dbo.Song", "SongID");
            AddForeignKey("dbo.Part", "ArrangementID", "dbo.Arrangement", "ArrangementID", cascadeDelete: true);
            AddForeignKey("dbo.Part", "MemberID", "dbo.Member", "MemberID", cascadeDelete: true);
            AddForeignKey("dbo.Part", "Instrument_InstrumentID", "dbo.Instrument", "InstrumentID");
            RenameTable(name: "dbo.Songs", newName: "Song");
            RenameTable(name: "dbo.Instruments", newName: "Instrument");
        }
    }
}

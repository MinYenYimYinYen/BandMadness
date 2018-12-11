namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parts : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.PartID)
                .ForeignKey("dbo.Instrument", t => t.Instrument_InstrumentID)
                .ForeignKey("dbo.Member", t => t.MemberID, cascadeDelete: true)
                .ForeignKey("dbo.Arrangement", t => t.ArrangementID, cascadeDelete: true)
                .Index(t => t.Instrument_InstrumentID)
                .Index(t => t.MemberID)
                .Index(t => t.ArrangementID);
            
            AddColumn("dbo.Member", "Alias", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Part", "ArrangementID", "dbo.Arrangement");
            DropForeignKey("dbo.Part", "MemberID", "dbo.Member");
            DropForeignKey("dbo.Part", "Instrument_InstrumentID", "dbo.Instrument");
            DropIndex("dbo.Part", new[] { "ArrangementID" });
            DropIndex("dbo.Part", new[] { "MemberID" });
            DropIndex("dbo.Part", new[] { "Instrument_InstrumentID" });
            DropColumn("dbo.Member", "Alias");
            DropTable("dbo.Part");
        }
    }
}

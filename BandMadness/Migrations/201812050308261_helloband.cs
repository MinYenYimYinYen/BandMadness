namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class helloband : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Instrument",
                c => new
                    {
                        InstrumentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InstrumentID);
            
            CreateTable(
                "Member",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
            CreateTable(
                "MemberInstrument",
                c => new
                    {
                        InstrumentRefID = c.Int(nullable: false),
                        MemberRefID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InstrumentRefID, t.MemberRefID })
                .ForeignKey("Member", t => t.InstrumentRefID, cascadeDelete: true)
                .ForeignKey("Instrument", t => t.MemberRefID, cascadeDelete: true)
                .Index(t => t.InstrumentRefID)
                .Index(t => t.MemberRefID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("MemberInstrument", "MemberRefID", "Instrument");
            DropForeignKey("MemberInstrument", "InstrumentRefID", "Member");
            DropIndex("MemberInstrument", new[] { "MemberRefID" });
            DropIndex("MemberInstrument", new[] { "InstrumentRefID" });
            DropTable("MemberInstrument");
            DropTable("Member");
            DropTable("Instrument");
        }
    }
}

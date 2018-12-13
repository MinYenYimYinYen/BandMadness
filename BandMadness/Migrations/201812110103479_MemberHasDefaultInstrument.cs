namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberHasDefaultInstrument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Member", "DefaultInstrumentID", c => c.Int());
            CreateIndex("dbo.Member", "DefaultInstrumentID");
            AddForeignKey("dbo.Member", "DefaultInstrumentID", "dbo.Instrument", "InstrumentID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Member", "DefaultInstrumentID", "dbo.Instrument");
            DropIndex("dbo.Member", new[] { "DefaultInstrumentID" });
            DropColumn("dbo.Member", "DefaultInstrumentID");
        }
    }
}

namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoDefaultInstrument : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Member", newName: "Members");
            DropForeignKey("dbo.Member", "DefaultInstrumentID", "dbo.Instruments");
            DropIndex("dbo.Members", new[] { "DefaultInstrumentID" });
            AlterColumn("dbo.Members", "FirstName", c => c.String(maxLength: 64));
            AlterColumn("dbo.Members", "LastName", c => c.String(maxLength: 64));
            AlterColumn("dbo.Members", "Alias", c => c.String(maxLength: 64));
            DropColumn("dbo.Members", "DefaultInstrumentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "DefaultInstrumentID", c => c.Int());
            AlterColumn("dbo.Members", "Alias", c => c.String());
            AlterColumn("dbo.Members", "LastName", c => c.String());
            AlterColumn("dbo.Members", "FirstName", c => c.String());
            CreateIndex("dbo.Members", "DefaultInstrumentID");
            AddForeignKey("dbo.Member", "DefaultInstrumentID", "dbo.Instruments", "InstrumentID");
            RenameTable(name: "dbo.Members", newName: "Member");
        }
    }
}

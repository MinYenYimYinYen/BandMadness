namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class what : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "Instrument", newSchema: "dbo");
            MoveTable(name: "Member", newSchema: "dbo");
            MoveTable(name: "MemberInstrument", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.MemberInstrument", newSchema: null);
            MoveTable(name: "dbo.Member", newSchema: null);
            MoveTable(name: "dbo.Instrument", newSchema: null);
        }
    }
}

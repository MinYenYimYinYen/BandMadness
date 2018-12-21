namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExplicitTableNamew : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Instruments", newName: "Instrument");
            RenameTable(name: "dbo.Members", newName: "Member");
            RenameTable(name: "dbo.Songs", newName: "Song");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Song", newName: "Songs");
            RenameTable(name: "dbo.Member", newName: "Members");
            RenameTable(name: "dbo.Instrument", newName: "Instruments");
        }
    }
}

namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SongDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recordings", "FolderPath", c => c.String());
            AddColumn("dbo.Recordings", "FileName", c => c.String());
            AddColumn("dbo.Recordings", "SubmitDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Instrument", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Member", "FirstName", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Member", "FirstName", c => c.String(maxLength: 64));
            AlterColumn("dbo.Instrument", "Name", c => c.String());
            DropColumn("dbo.Recordings", "SubmitDate");
            DropColumn("dbo.Recordings", "FileName");
            DropColumn("dbo.Recordings", "FolderPath");
        }
    }
}

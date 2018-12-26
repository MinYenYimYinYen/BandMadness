namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreSongDetails1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recordings", "SubmitDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recordings", "SubmitDate", c => c.DateTime(nullable: false));
        }
    }
}

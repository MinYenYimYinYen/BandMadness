namespace BandMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MemberInstrument", name: "InstrumentRefID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.MemberInstrument", name: "MemberRefID", newName: "InstrumentRefID");
            RenameColumn(table: "dbo.MemberInstrument", name: "__mig_tmp__0", newName: "MemberRefID");
            RenameIndex(table: "dbo.MemberInstrument", name: "IX_InstrumentRefID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.MemberInstrument", name: "IX_MemberRefID", newName: "IX_InstrumentRefID");
            RenameIndex(table: "dbo.MemberInstrument", name: "__mig_tmp__0", newName: "IX_MemberRefID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MemberInstrument", name: "IX_MemberRefID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.MemberInstrument", name: "IX_InstrumentRefID", newName: "IX_MemberRefID");
            RenameIndex(table: "dbo.MemberInstrument", name: "__mig_tmp__0", newName: "IX_InstrumentRefID");
            RenameColumn(table: "dbo.MemberInstrument", name: "MemberRefID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.MemberInstrument", name: "InstrumentRefID", newName: "MemberRefID");
            RenameColumn(table: "dbo.MemberInstrument", name: "__mig_tmp__0", newName: "InstrumentRefID");
        }
    }
}

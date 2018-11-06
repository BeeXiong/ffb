namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datecolumningameadjusted : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.games", "ReportDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.games", "ReportDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}

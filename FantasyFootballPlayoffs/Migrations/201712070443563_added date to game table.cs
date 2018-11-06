namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddatetogametable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.games", "ReportDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.games", "ReportDate");
        }
    }
}

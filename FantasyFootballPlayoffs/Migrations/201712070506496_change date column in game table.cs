namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatecolumningametable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.games", "gameDate", c => c.String());
            DropColumn("dbo.games", "ReportDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.games", "ReportDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.games", "gameDate");
        }
    }
}

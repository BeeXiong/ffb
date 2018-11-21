namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calendarYearFKaddedtoleaguetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_League", "calendarYearId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_League", "calendarYearId");
            DropColumn("dbo.fantasy_League", "leaguePassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_League", "leaguePassword", c => c.String(nullable: false, maxLength: 50));
            DropIndex("dbo.fantasy_League", new[] { "calendarYearId" });
            DropColumn("dbo.fantasy_League", "calendarYearId");
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedfantatsyleaguedetailtoincludecalendaryearvscurrentyear : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_League_Detail", "currentYearId", "dbo.currentYears");
            DropIndex("dbo.fantasy_League_Detail", new[] { "currentYearId" });
            AddColumn("dbo.fantasy_League_Detail", "calendarYearId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_League_Detail", "calendarYearId");
            DropColumn("dbo.fantasy_League_Detail", "currentYearId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_League_Detail", "currentYearId", c => c.Int(nullable: false));
            DropForeignKey("dbo.fantasy_League_Detail", "calendarYearId", "dbo.calendarYears");
            DropIndex("dbo.fantasy_League_Detail", new[] { "calendarYearId" });
            DropColumn("dbo.fantasy_League_Detail", "calendarYearId");
            CreateIndex("dbo.fantasy_League_Detail", "currentYearId");
        }
    }
}

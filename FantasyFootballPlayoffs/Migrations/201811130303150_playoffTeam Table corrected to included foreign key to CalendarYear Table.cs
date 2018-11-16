namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playoffTeamTablecorrectedtoincludedforeignkeytoCalendarYearTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.playoffTeams", "calendarYearId", c => c.Int(nullable: false));
            CreateIndex("dbo.playoffTeams", "calendarYearId");
            DropColumn("dbo.playoffTeams", "year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.playoffTeams", "year", c => c.Int(nullable: false));
            DropIndex("dbo.playoffTeams", new[] { "calendarYearId" });
            DropColumn("dbo.playoffTeams", "calendarYearId");
        }
    }
}

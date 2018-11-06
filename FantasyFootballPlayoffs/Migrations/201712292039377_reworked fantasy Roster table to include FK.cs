namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reworkedfantasyRostertabletoincludeFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_Roster", "fantasy_TeamId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "fantasy_LeagueId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_Roster", "fantasy_TeamId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_LeagueId");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "fantasy_TeamId", "dbo.fantasy_Team", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.fantasy_Roster", "fantasy_TeamId", "dbo.fantasy_Team");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League");
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_LeagueId" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_TeamId" });
            DropColumn("dbo.fantasy_Roster", "fantasy_LeagueId");
            DropColumn("dbo.fantasy_Roster", "fantasy_TeamId");
        }
    }
}

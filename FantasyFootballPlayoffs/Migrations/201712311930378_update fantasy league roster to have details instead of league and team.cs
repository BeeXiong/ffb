namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefantasyleaguerostertohavedetailsinsteadofleagueandteam : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_TeamId", "dbo.fantasy_Team");
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_TeamId" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_LeagueId" });
            AddColumn("dbo.fantasy_Roster", "fantasy_League_DetailId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_Roster", "fantasy_League_DetailId");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_League_DetailId", "dbo.fantasy_League_Detail", "Id", cascadeDelete: true);
            DropColumn("dbo.fantasy_Roster", "fantasy_TeamId");
            DropColumn("dbo.fantasy_Roster", "fantasy_LeagueId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_Roster", "fantasy_LeagueId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "fantasy_TeamId", c => c.Int(nullable: false));
            DropForeignKey("dbo.fantasy_Roster", "fantasy_League_DetailId", "dbo.fantasy_League_Detail");
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_League_DetailId" });
            DropColumn("dbo.fantasy_Roster", "fantasy_League_DetailId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_LeagueId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_TeamId");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_TeamId", "dbo.fantasy_Team", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League", "Id", cascadeDelete: true);
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateteamtabletoremoveCollectionofGames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.games", "team_team_PK", "dbo.teams");
            DropIndex("dbo.games", new[] { "team_team_PK" });
            DropColumn("dbo.games", "team_team_PK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.games", "team_team_PK", c => c.Int());
            CreateIndex("dbo.games", "team_team_PK");
            AddForeignKey("dbo.games", "team_team_PK", "dbo.teams", "team_PK");
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtofantasyleaguedetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_League_Detail", "fantasy_TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_League_Detail", "fantasy_TeamId");
            AddForeignKey("dbo.fantasy_League_Detail", "fantasy_TeamId", "dbo.fantasy_Team", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.fantasy_League_Detail", "fantasy_TeamId", "dbo.fantasy_Team");
            DropIndex("dbo.fantasy_League_Detail", new[] { "fantasy_TeamId" });
            DropColumn("dbo.fantasy_League_Detail", "fantasy_TeamId");
        }
    }
}

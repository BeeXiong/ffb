namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moveduseridtofantasyleaguedetailstable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_Team", "userId", "dbo.User");
            DropIndex("dbo.fantasy_Team", new[] { "userId" });
            AddColumn("dbo.fantasy_League_Detail", "userId", c => c.String(maxLength: 128));
            CreateIndex("dbo.fantasy_League_Detail", "userId");
            AddForeignKey("dbo.fantasy_League_Detail", "userId", "dbo.User", "UserId");
            DropColumn("dbo.fantasy_Team", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_Team", "userId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.fantasy_League_Detail", "userId", "dbo.User");
            DropIndex("dbo.fantasy_League_Detail", new[] { "userId" });
            DropColumn("dbo.fantasy_League_Detail", "userId");
            CreateIndex("dbo.fantasy_Team", "userId");
            AddForeignKey("dbo.fantasy_Team", "userId", "dbo.User", "UserId");
        }
    }
}

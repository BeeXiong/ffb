namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefantasyownerfromleaguedetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_League_Detail", "fantasy_OwnerId", "dbo.fantasy_Owner");
            DropIndex("dbo.fantasy_League_Detail", new[] { "fantasy_OwnerId" });
            DropColumn("dbo.fantasy_League_Detail", "fantasy_OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_League_Detail", "fantasy_OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_League_Detail", "fantasy_OwnerId");
            AddForeignKey("dbo.fantasy_League_Detail", "fantasy_OwnerId", "dbo.fantasy_Owner", "Id", cascadeDelete: true);
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestattabletoincludegame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.stats", "gameId", c => c.Int(nullable: false));
            CreateIndex("dbo.stats", "gameId");
            AddForeignKey("dbo.stats", "gameId", "dbo.games", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.stats", "gameId", "dbo.games");
            DropIndex("dbo.stats", new[] { "gameId" });
            DropColumn("dbo.stats", "gameId");
        }
    }
}

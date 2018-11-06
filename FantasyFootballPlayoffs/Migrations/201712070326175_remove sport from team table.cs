namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removesportfromteamtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.teams", "sportId", "dbo.sports");
            DropIndex("dbo.teams", new[] { "sportId" });
            DropColumn("dbo.teams", "sportId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teams", "sportId", c => c.Int(nullable: false));
            CreateIndex("dbo.teams", "sportId");
            AddForeignKey("dbo.teams", "sportId", "dbo.sports", "Id", cascadeDelete: true);
        }
    }
}

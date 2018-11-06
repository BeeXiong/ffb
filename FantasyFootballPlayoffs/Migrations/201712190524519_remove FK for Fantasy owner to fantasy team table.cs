namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeFKforFantasyownertofantasyteamtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_Team", "fantasy_OwnerId", "dbo.fantasy_Owner");
            DropIndex("dbo.fantasy_Team", new[] { "fantasy_OwnerId" });
            DropColumn("dbo.fantasy_Team", "fantasy_OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_Team", "fantasy_OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_Team", "fantasy_OwnerId");
            AddForeignKey("dbo.fantasy_Team", "fantasy_OwnerId", "dbo.fantasy_Owner", "Id", cascadeDelete: true);
        }
    }
}

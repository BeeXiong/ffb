namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addplayoffteamIdforeignkeytoplayerstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.players", "playoffteamid", c => c.Int(nullable: false));
            CreateIndex("dbo.players", "playoffteamid");
        }
        
        public override void Down()
        {
            DropIndex("dbo.players", new[] { "playoffteamid" });
            DropColumn("dbo.players", "playoffteamid");
        }
    }
}

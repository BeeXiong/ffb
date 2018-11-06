namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gamedateincludedinteamtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.games", "gameDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.games", "gameDate");
        }
    }
}

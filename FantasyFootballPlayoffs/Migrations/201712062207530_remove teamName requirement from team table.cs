namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeteamNamerequirementfromteamtable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.teams", "teamName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.teams", "teamName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

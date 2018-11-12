namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyaddedtogamestable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.games", "calendarYearId", c => c.Int(nullable: false));
            CreateIndex("dbo.games", "calendarYearId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.games", new[] { "calendarYearId" });
            DropColumn("dbo.games", "calendarYearId");
        }
    }
}

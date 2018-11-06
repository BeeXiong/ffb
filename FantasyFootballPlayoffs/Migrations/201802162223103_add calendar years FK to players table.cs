namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcalendaryearsFKtoplayerstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.players", "calendarYearId", c => c.Int(nullable: true));
            CreateIndex("dbo.players", "calendarYearId");
            AddForeignKey("dbo.players", "calendarYearId", "dbo.calendarYears", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.players", "calendarYearId", "dbo.calendarYears");
            DropIndex("dbo.players", new[] { "calendarYearId" });
            DropColumn("dbo.players", "calendarYearId");
        }
    }
}

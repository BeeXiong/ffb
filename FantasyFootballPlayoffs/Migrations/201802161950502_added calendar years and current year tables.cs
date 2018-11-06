namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcalendaryearsandcurrentyeartables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.calendarYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.currentYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        calendarYearId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.calendarYears", t => t.calendarYearId, cascadeDelete: true)
                .Index(t => t.calendarYearId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.currentYears", "calendarYearId", "dbo.calendarYears");
            DropIndex("dbo.currentYears", new[] { "calendarYearId" });
            DropTable("dbo.currentYears");
            DropTable("dbo.calendarYears");
        }
    }
}

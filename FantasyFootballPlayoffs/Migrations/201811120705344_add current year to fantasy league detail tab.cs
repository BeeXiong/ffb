namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcurrentyeartofantasyleaguedetailtab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_League_Detail", "currentYearId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_League_Detail", "currentYearId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.fantasy_League_Detail", new[] { "currentYearId" });
            DropColumn("dbo.fantasy_League_Detail", "currentYearId");
        }
    }
}

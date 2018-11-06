namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fantasyLeaguetableAnnanotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.fantasy_League", "leaguePassword", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.fantasy_League", "leaguePassword", c => c.String(maxLength: 50));
        }
    }
}

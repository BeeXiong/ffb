namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustamountOfTeamslocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_League", "amountOfTeams", c => c.Int(nullable: false));
            DropColumn("dbo.fantasy_League_Detail", "amountOfTeams");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_League_Detail", "amountOfTeams", c => c.Int(nullable: false));
            DropColumn("dbo.fantasy_League", "amountOfTeams");
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewcolumnforteamcountinFantasyLeagueDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_League_Detail", "amountOfTeams", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.fantasy_League_Detail", "amountOfTeams");
        }
    }
}

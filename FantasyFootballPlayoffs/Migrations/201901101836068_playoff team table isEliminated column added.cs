namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playoffteamtableisEliminatedcolumnadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.playoffTeams", "isEliminated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.playoffTeams", "isEliminated");
        }
    }
}

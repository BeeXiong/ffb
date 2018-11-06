namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedisplaynamesandplayoffTeamstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.playoffTeams", "conferenceId", c => c.Int(nullable: false));
            CreateIndex("dbo.playoffTeams", "conferenceId");
            AddForeignKey("dbo.playoffTeams", "conferenceId", "dbo.conferences", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.playoffTeams", "conferenceId", "dbo.conferences");
            DropIndex("dbo.playoffTeams", new[] { "conferenceId" });
            DropColumn("dbo.playoffTeams", "conferenceId");
        }
    }
}

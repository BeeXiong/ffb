namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtablesfordrafting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.playoffTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        homeTeamId = c.Int(nullable: false),
                        playoffSeed = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.homeTeams", t => t.homeTeamId, cascadeDelete: true)
                .Index(t => t.homeTeamId);
            
            AddColumn("dbo.fantasy_Roster", "roundDrafted", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.playoffTeams", "homeTeamId", "dbo.homeTeams");
            DropIndex("dbo.playoffTeams", new[] { "homeTeamId" });
            DropColumn("dbo.fantasy_Roster", "roundDrafted");
            DropTable("dbo.playoffTeams");
        }
    }
}

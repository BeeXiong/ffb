namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createhomeandawayteamtables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.teams", "locationId", "dbo.locations");
            DropIndex("dbo.teams", new[] { "locationId" });
            CreateTable(
                "dbo.awayTeams",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        awayLocation = c.Int(nullable: false),
                        awayTeamName = c.String(maxLength: 50),
                        stadiumName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.homeTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        locationId = c.Int(nullable: false),
                        homeTeamName = c.String(maxLength: 50),
                        stadiumName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.locations", t => t.locationId, cascadeDelete: true)
                .Index(t => t.locationId);
            
            AddColumn("dbo.players", "awayTeam_id", c => c.Int());
            CreateIndex("dbo.players", "awayTeam_id");
            AddForeignKey("dbo.players", "awayTeam_id", "dbo.awayTeams", "id");
            DropTable("dbo.teams");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        locationId = c.Int(nullable: false),
                        teamName = c.String(maxLength: 50),
                        stadiumName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.players", "awayTeam_id", "dbo.awayTeams");
            DropForeignKey("dbo.homeTeams", "locationId", "dbo.locations");
            DropIndex("dbo.homeTeams", new[] { "locationId" });
            DropIndex("dbo.players", new[] { "awayTeam_id" });
            DropColumn("dbo.players", "awayTeam_id");
            DropTable("dbo.homeTeams");
            DropTable("dbo.awayTeams");
            CreateIndex("dbo.teams", "locationId");
            AddForeignKey("dbo.teams", "locationId", "dbo.locations", "Id", cascadeDelete: true);
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revisedawayTeamTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.players", "awayTeam_id", "dbo.awayTeams");
            DropIndex("dbo.players", new[] { "awayTeam_id" });
            AddColumn("dbo.awayTeams", "locationId", c => c.Int(nullable: false));
            CreateIndex("dbo.awayTeams", "locationId");
            AddForeignKey("dbo.awayTeams", "locationId", "dbo.locations", "Id", cascadeDelete: true);
            DropColumn("dbo.awayTeams", "awayLocation");
            DropColumn("dbo.players", "awayTeam_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.players", "awayTeam_id", c => c.Int());
            AddColumn("dbo.awayTeams", "awayLocation", c => c.Int(nullable: false));
            DropForeignKey("dbo.awayTeams", "locationId", "dbo.locations");
            DropIndex("dbo.awayTeams", new[] { "locationId" });
            DropColumn("dbo.awayTeams", "locationId");
            CreateIndex("dbo.players", "awayTeam_id");
            AddForeignKey("dbo.players", "awayTeam_id", "dbo.awayTeams", "id");
        }
    }
}

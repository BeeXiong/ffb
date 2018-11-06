namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateteamtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.teams", "locationid_Id", "dbo.locations");
            DropForeignKey("dbo.teams", "sportid_Id", "dbo.sports");
            DropForeignKey("dbo.players", "team_team_PK", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamid_team_PK", "dbo.teams");
            DropForeignKey("dbo.games", "hometeamid_team_PK", "dbo.teams");
            DropIndex("dbo.teams", new[] { "locationid_Id" });
            DropIndex("dbo.teams", new[] { "sportid_Id" });
            DropColumn("dbo.players", "teamId");
            RenameColumn(table: "dbo.players", name: "team_team_PK", newName: "teamId");
            RenameColumn(table: "dbo.teams", name: "locationid_Id", newName: "locationId");
            RenameColumn(table: "dbo.teams", name: "sportid_Id", newName: "sportId");
            RenameColumn(table: "dbo.games", name: "awayTeamid_team_PK", newName: "awayTeamid_Id");
            RenameColumn(table: "dbo.games", name: "hometeamid_team_PK", newName: "hometeamid_Id");
            RenameIndex(table: "dbo.players", name: "IX_team_team_PK", newName: "IX_teamId");
            RenameIndex(table: "dbo.games", name: "IX_awayTeamid_team_PK", newName: "IX_awayTeamid_Id");
            RenameIndex(table: "dbo.games", name: "IX_hometeamid_team_PK", newName: "IX_hometeamid_Id");
            DropPrimaryKey("dbo.teams");
            AddColumn("dbo.teams", "Id", c => c.Int(nullable: false, identity: false));
            AlterColumn("dbo.teams", "locationId", c => c.Int(nullable: false));
            AlterColumn("dbo.teams", "sportId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.teams", "Id");
            CreateIndex("dbo.teams", "locationId");
            CreateIndex("dbo.teams", "sportId");
            AddForeignKey("dbo.teams", "locationId", "dbo.locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.teams", "sportId", "dbo.sports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.players", "teamId", "dbo.teams", "Id");
            AddForeignKey("dbo.games", "awayTeamid_Id", "dbo.teams", "Id");
            AddForeignKey("dbo.games", "hometeamid_Id", "dbo.teams", "Id");
            DropColumn("dbo.teams", "team_PK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teams", "team_PK", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.games", "hometeamid_Id", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamid_Id", "dbo.teams");
            DropForeignKey("dbo.players", "teamId", "dbo.teams");
            DropForeignKey("dbo.teams", "sportId", "dbo.sports");
            DropForeignKey("dbo.teams", "locationId", "dbo.locations");
            DropIndex("dbo.teams", new[] { "sportId" });
            DropIndex("dbo.teams", new[] { "locationId" });
            DropPrimaryKey("dbo.teams");
            AlterColumn("dbo.teams", "sportId", c => c.Int());
            AlterColumn("dbo.teams", "locationId", c => c.Int());
            DropColumn("dbo.teams", "Id");
            AddPrimaryKey("dbo.teams", "team_PK");
            RenameIndex(table: "dbo.games", name: "IX_hometeamid_Id", newName: "IX_hometeamid_team_PK");
            RenameIndex(table: "dbo.games", name: "IX_awayTeamid_Id", newName: "IX_awayTeamid_team_PK");
            RenameIndex(table: "dbo.players", name: "IX_teamId", newName: "IX_team_team_PK");
            RenameColumn(table: "dbo.games", name: "hometeamid_Id", newName: "hometeamid_team_PK");
            RenameColumn(table: "dbo.games", name: "awayTeamid_Id", newName: "awayTeamid_team_PK");
            RenameColumn(table: "dbo.teams", name: "sportId", newName: "sportid_Id");
            RenameColumn(table: "dbo.teams", name: "locationId", newName: "locationid_Id");
            RenameColumn(table: "dbo.players", name: "teamId", newName: "team_team_PK");
            AddColumn("dbo.players", "teamId", c => c.Int());
            CreateIndex("dbo.teams", "sportid_Id");
            CreateIndex("dbo.teams", "locationid_Id");
            AddForeignKey("dbo.games", "hometeamid_team_PK", "dbo.teams", "team_PK");
            AddForeignKey("dbo.games", "awayTeamid_team_PK", "dbo.teams", "team_PK");
            AddForeignKey("dbo.players", "team_team_PK", "dbo.teams", "team_PK");
            AddForeignKey("dbo.teams", "sportid_Id", "dbo.sports", "Id");
            AddForeignKey("dbo.teams", "locationid_Id", "dbo.locations", "Id");
        }
    }
}

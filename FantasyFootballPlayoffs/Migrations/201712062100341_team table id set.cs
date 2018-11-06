namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamtableidset : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.players", "team_test", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamid_test", "dbo.teams");
            DropForeignKey("dbo.games", "hometeamid_test", "dbo.teams");
            DropColumn("dbo.players", "teamId");
            RenameColumn(table: "dbo.players", name: "team_test", newName: "teamId");
            RenameColumn(table: "dbo.games", name: "awayTeamid_test", newName: "awayTeamid_Id");
            RenameColumn(table: "dbo.games", name: "hometeamid_test", newName: "hometeamid_Id");
            RenameIndex(table: "dbo.players", name: "IX_team_test", newName: "IX_teamId");
            RenameIndex(table: "dbo.games", name: "IX_awayTeamid_test", newName: "IX_awayTeamid_Id");
            RenameIndex(table: "dbo.games", name: "IX_hometeamid_test", newName: "IX_hometeamid_Id");
            DropPrimaryKey("dbo.teams");
            AddColumn("dbo.teams", "Id", c => c.Int(nullable: false, identity: false));
            AddPrimaryKey("dbo.teams", "Id");
            AddForeignKey("dbo.players", "teamId", "dbo.teams", "Id");
            AddForeignKey("dbo.games", "awayTeamid_Id", "dbo.teams", "Id");
            AddForeignKey("dbo.games", "hometeamid_Id", "dbo.teams", "Id");
            DropColumn("dbo.teams", "test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teams", "test", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.games", "hometeamid_Id", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamid_Id", "dbo.teams");
            DropForeignKey("dbo.players", "teamId", "dbo.teams");
            DropPrimaryKey("dbo.teams");
            DropColumn("dbo.teams", "Id");
            AddPrimaryKey("dbo.teams", "test");
            RenameIndex(table: "dbo.games", name: "IX_hometeamid_Id", newName: "IX_hometeamid_test");
            RenameIndex(table: "dbo.games", name: "IX_awayTeamid_Id", newName: "IX_awayTeamid_test");
            RenameIndex(table: "dbo.players", name: "IX_teamId", newName: "IX_team_test");
            RenameColumn(table: "dbo.games", name: "hometeamid_Id", newName: "hometeamid_test");
            RenameColumn(table: "dbo.games", name: "awayTeamid_Id", newName: "awayTeamid_test");
            RenameColumn(table: "dbo.players", name: "teamId", newName: "team_test");
            AddColumn("dbo.players", "teamId", c => c.Int());
            AddForeignKey("dbo.games", "hometeamid_test", "dbo.teams", "test");
            AddForeignKey("dbo.games", "awayTeamid_test", "dbo.teams", "test");
            AddForeignKey("dbo.players", "team_test", "dbo.teams", "test");
        }
    }
}

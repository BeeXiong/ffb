namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamtableidreset : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.players", "teamId", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamid_Id", "dbo.teams");
            DropForeignKey("dbo.games", "hometeamid_Id", "dbo.teams");
            DropIndex("dbo.players", new[] { "teamId" });
            RenameColumn(table: "dbo.games", name: "awayTeamid_Id", newName: "awayTeamid_test");
            RenameColumn(table: "dbo.games", name: "hometeamid_Id", newName: "hometeamid_test");
            RenameIndex(table: "dbo.games", name: "IX_awayTeamid_Id", newName: "IX_awayTeamid_test");
            RenameIndex(table: "dbo.games", name: "IX_hometeamid_Id", newName: "IX_hometeamid_test");
            DropPrimaryKey("dbo.teams");
            AddColumn("dbo.players", "team_test", c => c.Int());
            AddColumn("dbo.teams", "test", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.teams", "test");
            CreateIndex("dbo.players", "team_test");
            AddForeignKey("dbo.players", "team_test", "dbo.teams", "test");
            AddForeignKey("dbo.games", "awayTeamid_test", "dbo.teams", "test");
            AddForeignKey("dbo.games", "hometeamid_test", "dbo.teams", "test");
            DropColumn("dbo.teams", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teams", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.games", "hometeamid_test", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamid_test", "dbo.teams");
            DropForeignKey("dbo.players", "team_test", "dbo.teams");
            DropIndex("dbo.players", new[] { "team_test" });
            DropPrimaryKey("dbo.teams");
            DropColumn("dbo.teams", "test");
            DropColumn("dbo.players", "team_test");
            AddPrimaryKey("dbo.teams", "Id");
            RenameIndex(table: "dbo.games", name: "IX_hometeamid_test", newName: "IX_hometeamid_Id");
            RenameIndex(table: "dbo.games", name: "IX_awayTeamid_test", newName: "IX_awayTeamid_Id");
            RenameColumn(table: "dbo.games", name: "hometeamid_test", newName: "hometeamid_Id");
            RenameColumn(table: "dbo.games", name: "awayTeamid_test", newName: "awayTeamid_Id");
            CreateIndex("dbo.players", "teamId");
            AddForeignKey("dbo.games", "hometeamid_Id", "dbo.teams", "Id");
            AddForeignKey("dbo.games", "awayTeamid_Id", "dbo.teams", "Id");
            AddForeignKey("dbo.players", "teamId", "dbo.teams", "Id");
        }
    }
}

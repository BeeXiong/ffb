namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixforeignkeyplayertable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.players", name: "playerPosition_playerPosition_PK", newName: "playerPositionid_playerPosition_PK");
            RenameColumn(table: "dbo.players", name: "team_team_PK", newName: "teamid_team_PK");
            RenameIndex(table: "dbo.players", name: "IX_playerPosition_playerPosition_PK", newName: "IX_playerPositionid_playerPosition_PK");
            RenameIndex(table: "dbo.players", name: "IX_team_team_PK", newName: "IX_teamid_team_PK");
            DropColumn("dbo.players", "team_FK");
            DropColumn("dbo.players", "playerPosition_FK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.players", "playerPosition_FK", c => c.Int());
            AddColumn("dbo.players", "team_FK", c => c.Int());
            RenameIndex(table: "dbo.players", name: "IX_teamid_team_PK", newName: "IX_team_team_PK");
            RenameIndex(table: "dbo.players", name: "IX_playerPositionid_playerPosition_PK", newName: "IX_playerPosition_playerPosition_PK");
            RenameColumn(table: "dbo.players", name: "teamid_team_PK", newName: "team_team_PK");
            RenameColumn(table: "dbo.players", name: "playerPositionid_playerPosition_PK", newName: "playerPosition_playerPosition_PK");
        }
    }
}

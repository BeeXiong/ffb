namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefantasyteamtables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_League_Member", "fantasy_Leagueid_fantasy_League_PK", "dbo.fantasy_League");
            DropForeignKey("dbo.fantasy_League_Member", "fantasy_Teamsid_fantasy_Team_PK", "dbo.fantasy_Team");
            DropForeignKey("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK", "dbo.fantasy_Owner");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Ownersid_fantasy_Owner_PK", "dbo.fantasy_Owner");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Teamsid_fantasy_Team_PK", "dbo.fantasy_Team");
            DropIndex("dbo.fantasy_League_Member", new[] { "fantasy_Leagueid_fantasy_League_PK" });
            DropIndex("dbo.fantasy_League_Member", new[] { "fantasy_Teamsid_fantasy_Team_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Ownersid_fantasy_Owner_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Teamsid_fantasy_Team_PK" });
            DropIndex("dbo.fantasy_Team", new[] { "fantasy_Ownerid_fantasy_Owner_PK" });
            RenameColumn(table: "dbo.fantasy_League", name: "sportid_sport_PK", newName: "sport_sport_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "playerid_player_PK", newName: "player_player_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_Ownersid_fantasy_Owner_PK", newName: "fantasy_OwnerId");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_Teamsid_fantasy_Team_PK", newName: "fantasy_teamId");
            RenameIndex(table: "dbo.fantasy_League", name: "IX_sportid_sport_PK", newName: "IX_sport_sport_PK");
            RenameIndex(table: "dbo.fantasy_Roster", name: "IX_playerid_player_PK", newName: "IX_player_player_PK");
            DropPrimaryKey("dbo.fantasy_League");
            DropPrimaryKey("dbo.fantasy_Roster");
            DropPrimaryKey("dbo.fantasy_Owner");
            DropPrimaryKey("dbo.fantasy_Team");
            AddColumn("dbo.fantasy_League", "Id", c => c.Int(nullable: false, identity: false));
            AddColumn("dbo.fantasy_League", "sportId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "Id", c => c.Int(nullable: false, identity: false));
            AddColumn("dbo.fantasy_Roster", "playerId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Owner", "Id", c => c.Int(nullable: false, identity: false));
            AddColumn("dbo.fantasy_Team", "Id", c => c.Int(nullable: false, identity: false));
            AlterColumn("dbo.fantasy_Roster", "fantasy_OwnerId", c => c.Int(nullable: false));
            AlterColumn("dbo.fantasy_Roster", "fantasy_teamId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.fantasy_League", "Id");
            AddPrimaryKey("dbo.fantasy_Roster", "Id");
            AddPrimaryKey("dbo.fantasy_Owner", "Id");
            AddPrimaryKey("dbo.fantasy_Team", "Id");
            CreateIndex("dbo.fantasy_Roster", "fantasy_teamId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_OwnerId");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_OwnerId", "dbo.fantasy_Owner", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "fantasy_teamId", "dbo.fantasy_Team", "Id", cascadeDelete: true);
            DropColumn("dbo.fantasy_League", "fantasy_League_PK");
            DropColumn("dbo.fantasy_Roster", "fantasy_Rosters_PK");
            DropColumn("dbo.fantasy_Owner", "fantasy_Owner_PK");
            DropColumn("dbo.fantasy_Team", "fantasy_Team_PK");
            DropColumn("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK");
            DropTable("dbo.fantasy_League_Member");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.fantasy_League_Member",
                c => new
                    {
                        fantasy_League_Member_PK = c.Int(nullable: false, identity: true),
                        isAMember = c.String(nullable: false, maxLength: 50),
                        fantasy_Leagueid_fantasy_League_PK = c.Int(),
                        fantasy_Teamsid_fantasy_Team_PK = c.Int(),
                    })
                .PrimaryKey(t => t.fantasy_League_Member_PK);
            
            AddColumn("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK", c => c.Int());
            AddColumn("dbo.fantasy_Team", "fantasy_Team_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_Owner", "fantasy_Owner_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_Roster", "fantasy_Rosters_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_League", "fantasy_League_PK", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.fantasy_Roster", "fantasy_teamId", "dbo.fantasy_Team");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_OwnerId", "dbo.fantasy_Owner");
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_OwnerId" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_teamId" });
            DropPrimaryKey("dbo.fantasy_Team");
            DropPrimaryKey("dbo.fantasy_Owner");
            DropPrimaryKey("dbo.fantasy_Roster");
            DropPrimaryKey("dbo.fantasy_League");
            AlterColumn("dbo.fantasy_Roster", "fantasy_teamId", c => c.Int());
            AlterColumn("dbo.fantasy_Roster", "fantasy_OwnerId", c => c.Int());
            DropColumn("dbo.fantasy_Team", "Id");
            DropColumn("dbo.fantasy_Owner", "Id");
            DropColumn("dbo.fantasy_Roster", "playerId");
            DropColumn("dbo.fantasy_Roster", "Id");
            DropColumn("dbo.fantasy_League", "sportId");
            DropColumn("dbo.fantasy_League", "Id");
            AddPrimaryKey("dbo.fantasy_Team", "fantasy_Team_PK");
            AddPrimaryKey("dbo.fantasy_Owner", "fantasy_Owner_PK");
            AddPrimaryKey("dbo.fantasy_Roster", "fantasy_Rosters_PK");
            AddPrimaryKey("dbo.fantasy_League", "fantasy_League_PK");
            RenameIndex(table: "dbo.fantasy_Roster", name: "IX_player_player_PK", newName: "IX_playerid_player_PK");
            RenameIndex(table: "dbo.fantasy_League", name: "IX_sport_sport_PK", newName: "IX_sportid_sport_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_teamId", newName: "fantasy_Teamsid_fantasy_Team_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_OwnerId", newName: "fantasy_Ownersid_fantasy_Owner_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "player_player_PK", newName: "playerid_player_PK");
            RenameColumn(table: "dbo.fantasy_League", name: "sport_sport_PK", newName: "sportid_sport_PK");
            CreateIndex("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK");
            CreateIndex("dbo.fantasy_Roster", "fantasy_Teamsid_fantasy_Team_PK");
            CreateIndex("dbo.fantasy_Roster", "fantasy_Ownersid_fantasy_Owner_PK");
            CreateIndex("dbo.fantasy_League_Member", "fantasy_Teamsid_fantasy_Team_PK");
            CreateIndex("dbo.fantasy_League_Member", "fantasy_Leagueid_fantasy_League_PK");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_Teamsid_fantasy_Team_PK", "dbo.fantasy_Team", "fantasy_Team_PK");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_Ownersid_fantasy_Owner_PK", "dbo.fantasy_Owner", "fantasy_Owner_PK");
            AddForeignKey("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK", "dbo.fantasy_Owner", "fantasy_Owner_PK");
            AddForeignKey("dbo.fantasy_League_Member", "fantasy_Teamsid_fantasy_Team_PK", "dbo.fantasy_Team", "fantasy_Team_PK");
            AddForeignKey("dbo.fantasy_League_Member", "fantasy_Leagueid_fantasy_League_PK", "dbo.fantasy_League", "fantasy_League_PK");
        }
    }
}

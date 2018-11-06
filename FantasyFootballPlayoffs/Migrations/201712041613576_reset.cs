namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reset : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League");
            DropForeignKey("dbo.fantasy_Roster", "sportId", "dbo.sports");
            DropForeignKey("dbo.stats", "playerId", "dbo.players");
            DropForeignKey("dbo.stats", "statisticalCategoryid", "dbo.statisticalCategories");
            DropForeignKey("dbo.gameStats", "statId", "dbo.stats");
            DropForeignKey("dbo.teamInformations", "locationId", "dbo.locations");
            DropForeignKey("dbo.teamInformations", "sportId", "dbo.sports");
            DropForeignKey("dbo.teamInformations", "teamId", "dbo.teams");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_OwnerId", "dbo.fantasy_Owner");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_TeamId", "dbo.fantasy_Team");
            DropForeignKey("dbo.players", "playerPositionid", "dbo.playerPositions");
            DropForeignKey("dbo.players", "teamid", "dbo.teams");
            DropForeignKey("dbo.fantasy_Roster", "playerId", "dbo.players");
            DropForeignKey("dbo.games", "awayTeamId", "dbo.teams");
            DropForeignKey("dbo.games", "homeTeamId", "dbo.teams");
            DropForeignKey("dbo.games", "sportId", "dbo.sports");
            DropForeignKey("dbo.gameStats", "gameId", "dbo.games");
            DropIndex("dbo.fantasy_Roster", new[] { "playerId" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_TeamId" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_OwnerId" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_LeagueId" });
            DropIndex("dbo.fantasy_Roster", new[] { "sportId" });
            DropIndex("dbo.players", new[] { "teamid" });
            DropIndex("dbo.players", new[] { "playerPositionid" });
            DropIndex("dbo.games", new[] { "sportId" });
            DropIndex("dbo.games", new[] { "homeTeamId" });
            DropIndex("dbo.games", new[] { "awayTeamId" });
            DropIndex("dbo.gameStats", new[] { "gameId" });
            DropIndex("dbo.gameStats", new[] { "statId" });
            DropIndex("dbo.stats", new[] { "playerId" });
            DropIndex("dbo.stats", new[] { "statisticalCategoryid" });
            DropIndex("dbo.teamInformations", new[] { "locationId" });
            DropIndex("dbo.teamInformations", new[] { "teamId" });
            DropIndex("dbo.teamInformations", new[] { "sportId" });
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_OwnerId", newName: "fantasy_Ownersid_fantasy_Owner_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_TeamId", newName: "fantasy_Teamsid_fantasy_Team_PK");
            RenameColumn(table: "dbo.players", name: "playerPositionid", newName: "playerPositionid_playerPosition_PK");
            RenameColumn(table: "dbo.players", name: "teamid", newName: "teamid_team_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "playerId", newName: "playerid_player_PK");
            RenameColumn(table: "dbo.games", name: "awayTeamId", newName: "awayTeamid_team_PK");
            RenameColumn(table: "dbo.games", name: "homeTeamId", newName: "hometeamid_team_PK");
            RenameColumn(table: "dbo.games", name: "sportId", newName: "sportid_sport_PK");
            RenameColumn(table: "dbo.gameStats", name: "gameId", newName: "gameid_game_PK");
            DropPrimaryKey("dbo.fantasy_League");
            DropPrimaryKey("dbo.fantasy_Owner");
            DropPrimaryKey("dbo.fantasy_Roster");
            DropPrimaryKey("dbo.fantasy_Team");
            DropPrimaryKey("dbo.players");
            DropPrimaryKey("dbo.playerPositions");
            DropPrimaryKey("dbo.teams");
            DropPrimaryKey("dbo.sports");
            DropPrimaryKey("dbo.games");
            DropPrimaryKey("dbo.gameStats");
            DropPrimaryKey("dbo.statisticalCategories");
            DropPrimaryKey("dbo.locations");
            CreateTable(
                "dbo.fantasy_League_Member",
                c => new
                    {
                        fantasy_League_Member_PK = c.Int(nullable: false, identity: true),
                        isAMember = c.String(nullable: false, maxLength: 50),
                        fantasy_Leagueid_fantasy_League_PK = c.Int(),
                        fantasy_Teamsid_fantasy_Team_PK = c.Int(),
                    })
                .PrimaryKey(t => t.fantasy_League_Member_PK)
                .ForeignKey("dbo.fantasy_League", t => t.fantasy_Leagueid_fantasy_League_PK)
                .ForeignKey("dbo.fantasy_Team", t => t.fantasy_Teamsid_fantasy_Team_PK)
                .Index(t => t.fantasy_Leagueid_fantasy_League_PK)
                .Index(t => t.fantasy_Teamsid_fantasy_Team_PK);
            
            CreateTable(
                "dbo.fantasy_Player_Slot",
                c => new
                    {
                        fantasy_Player_Slots_PK = c.Int(nullable: false),
                        player_Slot = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.fantasy_Player_Slots_PK, t.player_Slot });
            
            AddColumn("dbo.fantasy_League", "fantasy_League_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_League", "sportid_sport_PK", c => c.Int());
            AddColumn("dbo.fantasy_Owner", "fantasy_Owner_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_Owner", "userName", c => c.String(maxLength: 50));
            AddColumn("dbo.fantasy_Owner", "ownerPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.fantasy_Roster", "fantasy_Rosters_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_Team", "fantasy_Team_PK", c => c.Int(nullable: false, identity: false));
            AddColumn("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK", c => c.Int());
            AddColumn("dbo.players", "player_PK", c => c.Int(nullable: false, identity: false));
            AddColumn("dbo.playerPositions", "playerPosition_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.teams", "team_PK", c => c.Int(nullable: false, identity: false));
            AddColumn("dbo.teams", "locationid_location_PK", c => c.Int());
            AddColumn("dbo.teams", "sportid_sport_PK", c => c.Int());
            AddColumn("dbo.sports", "sport_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.games", "game_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.gameStats", "gameStat_PK", c => c.Int(nullable: false, identity: false));
            AddColumn("dbo.gameStats", "yardage", c => c.Int());
            AddColumn("dbo.gameStats", "points", c => c.Int());
            AddColumn("dbo.gameStats", "statisticCategoryQuantity", c => c.Int());
            AddColumn("dbo.gameStats", "isATouchdown", c => c.String(maxLength: 50));
            AddColumn("dbo.gameStats", "isAtdbetween35_49", c => c.String(maxLength: 50));
            AddColumn("dbo.gameStats", "isAtdOver50", c => c.String(maxLength: 50));
            AddColumn("dbo.gameStats", "playerid_player_PK", c => c.Int());
            AddColumn("dbo.gameStats", "statisticalCategoryid_statisticalCategory_PK", c => c.Int());
            AddColumn("dbo.statisticalCategories", "statisticalCategory_PK", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.locations", "location_PK", c => c.Int(nullable: false, identity: false));
            AlterColumn("dbo.fantasy_Roster", "playerid_player_PK", c => c.Int());
            AlterColumn("dbo.fantasy_Roster", "fantasy_Teamsid_fantasy_Team_PK", c => c.Int());
            AlterColumn("dbo.fantasy_Roster", "fantasy_Ownersid_fantasy_Owner_PK", c => c.Int());
            AlterColumn("dbo.players", "teamid_team_PK", c => c.Int());
            AlterColumn("dbo.players", "playerPositionid_playerPosition_PK", c => c.Int());
            AlterColumn("dbo.players", "isHealthy", c => c.Int());
            AlterColumn("dbo.games", "sportid_sport_PK", c => c.Int());
            AlterColumn("dbo.games", "hometeamid_team_PK", c => c.Int());
            AlterColumn("dbo.games", "awayTeamid_team_PK", c => c.Int());
            AlterColumn("dbo.gameStats", "gameid_game_PK", c => c.Int());
            AddPrimaryKey("dbo.fantasy_League", "fantasy_League_PK");
            AddPrimaryKey("dbo.fantasy_Owner", "fantasy_Owner_PK");
            AddPrimaryKey("dbo.fantasy_Roster", "fantasy_Rosters_PK");
            AddPrimaryKey("dbo.fantasy_Team", "fantasy_Team_PK");
            AddPrimaryKey("dbo.players", "player_PK");
            AddPrimaryKey("dbo.playerPositions", "playerPosition_PK");
            AddPrimaryKey("dbo.teams", "team_PK");
            AddPrimaryKey("dbo.sports", "sport_PK");
            AddPrimaryKey("dbo.games", "game_PK");
            AddPrimaryKey("dbo.gameStats", "gameStat_PK");
            AddPrimaryKey("dbo.statisticalCategories", "statisticalCategory_PK");
            AddPrimaryKey("dbo.locations", "location_PK");
            CreateIndex("dbo.fantasy_League", "sportid_sport_PK");
            CreateIndex("dbo.games", "awayTeamid_team_PK");
            CreateIndex("dbo.games", "hometeamid_team_PK");
            CreateIndex("dbo.games", "sportid_sport_PK");
            CreateIndex("dbo.teams", "locationid_location_PK");
            CreateIndex("dbo.teams", "sportid_sport_PK");
            CreateIndex("dbo.players", "playerPositionid_playerPosition_PK");
            CreateIndex("dbo.players", "teamid_team_PK");
            CreateIndex("dbo.fantasy_Roster", "fantasy_Ownersid_fantasy_Owner_PK");
            CreateIndex("dbo.fantasy_Roster", "fantasy_Teamsid_fantasy_Team_PK");
            CreateIndex("dbo.fantasy_Roster", "playerid_player_PK");
            CreateIndex("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK");
            CreateIndex("dbo.gameStats", "gameid_game_PK");
            CreateIndex("dbo.gameStats", "playerid_player_PK");
            CreateIndex("dbo.gameStats", "statisticalCategoryid_statisticalCategory_PK");
            AddForeignKey("dbo.fantasy_League", "sportid_sport_PK", "dbo.sports", "sport_PK");
            AddForeignKey("dbo.teams", "locationid_location_PK", "dbo.locations", "location_PK");
            AddForeignKey("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK", "dbo.fantasy_Owner", "fantasy_Owner_PK");
            AddForeignKey("dbo.gameStats", "playerid_player_PK", "dbo.players", "player_PK");
            AddForeignKey("dbo.gameStats", "statisticalCategoryid_statisticalCategory_PK", "dbo.statisticalCategories", "statisticalCategory_PK");
            AddForeignKey("dbo.teams", "sportid_sport_PK", "dbo.sports", "sport_PK");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_Ownersid_fantasy_Owner_PK", "dbo.fantasy_Owner", "fantasy_Owner_PK");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_Teamsid_fantasy_Team_PK", "dbo.fantasy_Team", "fantasy_Team_PK");
            AddForeignKey("dbo.players", "playerPositionid_playerPosition_PK", "dbo.playerPositions", "playerPosition_PK");
            AddForeignKey("dbo.players", "teamid_team_PK", "dbo.teams", "team_PK");
            AddForeignKey("dbo.fantasy_Roster", "playerid_player_PK", "dbo.players", "player_PK");
            AddForeignKey("dbo.games", "awayTeamid_team_PK", "dbo.teams", "team_PK");
            AddForeignKey("dbo.games", "hometeamid_team_PK", "dbo.teams", "team_PK");
            AddForeignKey("dbo.games", "sportid_sport_PK", "dbo.sports", "sport_PK");
            AddForeignKey("dbo.gameStats", "gameid_game_PK", "dbo.games", "game_PK");
            DropColumn("dbo.fantasy_League", "Id");
            DropColumn("dbo.fantasy_Owner", "Id");
            DropColumn("dbo.fantasy_Roster", "Id");
            DropColumn("dbo.fantasy_Roster", "fantasy_LeagueId");
            DropColumn("dbo.fantasy_Roster", "sportId");
            DropColumn("dbo.fantasy_Team", "Id");
            DropColumn("dbo.players", "id");
            DropColumn("dbo.playerPositions", "id");
            DropColumn("dbo.teams", "Id");
            DropColumn("dbo.sports", "Id");
            DropColumn("dbo.games", "Id");
            DropColumn("dbo.gameStats", "Id");
            DropColumn("dbo.gameStats", "statId");
            DropColumn("dbo.statisticalCategories", "Id");
            DropColumn("dbo.locations", "id");
            DropColumn("dbo.zRawNFLRosters", "teamid");
            DropTable("dbo.stats");
            DropTable("dbo.teamInformations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.teamInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        locationId = c.Int(nullable: false),
                        teamId = c.Int(nullable: false),
                        sportId = c.Int(nullable: false),
                        fullTeamName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.stats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        playerId = c.Int(nullable: false),
                        statisticalCategoryid = c.Int(nullable: false),
                        yardage = c.Int(),
                        points = c.Int(),
                        statisticCategoryQuantity = c.Int(),
                        isATouchdown = c.String(maxLength: 50),
                        isAtdbetween35_49 = c.String(maxLength: 50),
                        isAtdOver50 = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.zRawNFLRosters", "teamid", c => c.Int(nullable: false));
            AddColumn("dbo.locations", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.statisticalCategories", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.gameStats", "statId", c => c.Int(nullable: false));
            AddColumn("dbo.gameStats", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.games", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.sports", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.teams", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.playerPositions", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.players", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_Team", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_Roster", "sportId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "fantasy_LeagueId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_Owner", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.fantasy_League", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.gameStats", "gameid_game_PK", "dbo.games");
            DropForeignKey("dbo.games", "sportid_sport_PK", "dbo.sports");
            DropForeignKey("dbo.games", "hometeamid_team_PK", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamid_team_PK", "dbo.teams");
            DropForeignKey("dbo.fantasy_Roster", "playerid_player_PK", "dbo.players");
            DropForeignKey("dbo.players", "teamid_team_PK", "dbo.teams");
            DropForeignKey("dbo.players", "playerPositionid_playerPosition_PK", "dbo.playerPositions");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Teamsid_fantasy_Team_PK", "dbo.fantasy_Team");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Ownersid_fantasy_Owner_PK", "dbo.fantasy_Owner");
            DropForeignKey("dbo.teams", "sportid_sport_PK", "dbo.sports");
            DropForeignKey("dbo.gameStats", "statisticalCategoryid_statisticalCategory_PK", "dbo.statisticalCategories");
            DropForeignKey("dbo.gameStats", "playerid_player_PK", "dbo.players");
            DropForeignKey("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK", "dbo.fantasy_Owner");
            DropForeignKey("dbo.fantasy_League_Member", "fantasy_Teamsid_fantasy_Team_PK", "dbo.fantasy_Team");
            DropForeignKey("dbo.teams", "locationid_location_PK", "dbo.locations");
            DropForeignKey("dbo.fantasy_League", "sportid_sport_PK", "dbo.sports");
            DropForeignKey("dbo.fantasy_League_Member", "fantasy_Leagueid_fantasy_League_PK", "dbo.fantasy_League");
            DropIndex("dbo.gameStats", new[] { "statisticalCategoryid_statisticalCategory_PK" });
            DropIndex("dbo.gameStats", new[] { "playerid_player_PK" });
            DropIndex("dbo.gameStats", new[] { "gameid_game_PK" });
            DropIndex("dbo.fantasy_Team", new[] { "fantasy_Ownerid_fantasy_Owner_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "playerid_player_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Teamsid_fantasy_Team_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Ownersid_fantasy_Owner_PK" });
            DropIndex("dbo.players", new[] { "teamid_team_PK" });
            DropIndex("dbo.players", new[] { "playerPositionid_playerPosition_PK" });
            DropIndex("dbo.teams", new[] { "sportid_sport_PK" });
            DropIndex("dbo.teams", new[] { "locationid_location_PK" });
            DropIndex("dbo.games", new[] { "sportid_sport_PK" });
            DropIndex("dbo.games", new[] { "hometeamid_team_PK" });
            DropIndex("dbo.games", new[] { "awayTeamid_team_PK" });
            DropIndex("dbo.fantasy_League", new[] { "sportid_sport_PK" });
            DropIndex("dbo.fantasy_League_Member", new[] { "fantasy_Teamsid_fantasy_Team_PK" });
            DropIndex("dbo.fantasy_League_Member", new[] { "fantasy_Leagueid_fantasy_League_PK" });
            DropPrimaryKey("dbo.locations");
            DropPrimaryKey("dbo.statisticalCategories");
            DropPrimaryKey("dbo.gameStats");
            DropPrimaryKey("dbo.games");
            DropPrimaryKey("dbo.sports");
            DropPrimaryKey("dbo.teams");
            DropPrimaryKey("dbo.playerPositions");
            DropPrimaryKey("dbo.players");
            DropPrimaryKey("dbo.fantasy_Team");
            DropPrimaryKey("dbo.fantasy_Roster");
            DropPrimaryKey("dbo.fantasy_Owner");
            DropPrimaryKey("dbo.fantasy_League");
            AlterColumn("dbo.gameStats", "gameid_game_PK", c => c.Int(nullable: false));
            AlterColumn("dbo.games", "awayTeamid_team_PK", c => c.Int(nullable: false));
            AlterColumn("dbo.games", "hometeamid_team_PK", c => c.Int(nullable: false));
            AlterColumn("dbo.games", "sportid_sport_PK", c => c.Int(nullable: false));
            AlterColumn("dbo.players", "isHealthy", c => c.Int(nullable: false));
            AlterColumn("dbo.players", "playerPositionid_playerPosition_PK", c => c.Int(nullable: false));
            AlterColumn("dbo.players", "teamid_team_PK", c => c.Int(nullable: false));
            AlterColumn("dbo.fantasy_Roster", "fantasy_Ownersid_fantasy_Owner_PK", c => c.Int(nullable: false));
            AlterColumn("dbo.fantasy_Roster", "fantasy_Teamsid_fantasy_Team_PK", c => c.Int(nullable: false));
            AlterColumn("dbo.fantasy_Roster", "playerid_player_PK", c => c.Int(nullable: false));
            DropColumn("dbo.locations", "location_PK");
            DropColumn("dbo.statisticalCategories", "statisticalCategory_PK");
            DropColumn("dbo.gameStats", "statisticalCategoryid_statisticalCategory_PK");
            DropColumn("dbo.gameStats", "playerid_player_PK");
            DropColumn("dbo.gameStats", "isAtdOver50");
            DropColumn("dbo.gameStats", "isAtdbetween35_49");
            DropColumn("dbo.gameStats", "isATouchdown");
            DropColumn("dbo.gameStats", "statisticCategoryQuantity");
            DropColumn("dbo.gameStats", "points");
            DropColumn("dbo.gameStats", "yardage");
            DropColumn("dbo.gameStats", "gameStat_PK");
            DropColumn("dbo.games", "game_PK");
            DropColumn("dbo.sports", "sport_PK");
            DropColumn("dbo.teams", "sportid_sport_PK");
            DropColumn("dbo.teams", "locationid_location_PK");
            DropColumn("dbo.teams", "team_PK");
            DropColumn("dbo.playerPositions", "playerPosition_PK");
            DropColumn("dbo.players", "player_PK");
            DropColumn("dbo.fantasy_Team", "fantasy_Ownerid_fantasy_Owner_PK");
            DropColumn("dbo.fantasy_Team", "fantasy_Team_PK");
            DropColumn("dbo.fantasy_Roster", "fantasy_Rosters_PK");
            DropColumn("dbo.fantasy_Owner", "ownerPassword");
            DropColumn("dbo.fantasy_Owner", "userName");
            DropColumn("dbo.fantasy_Owner", "fantasy_Owner_PK");
            DropColumn("dbo.fantasy_League", "sportid_sport_PK");
            DropColumn("dbo.fantasy_League", "fantasy_League_PK");
            DropTable("dbo.fantasy_Player_Slot");
            DropTable("dbo.fantasy_League_Member");
            AddPrimaryKey("dbo.locations", "id");
            AddPrimaryKey("dbo.statisticalCategories", "Id");
            AddPrimaryKey("dbo.gameStats", "Id");
            AddPrimaryKey("dbo.games", "Id");
            AddPrimaryKey("dbo.sports", "Id");
            AddPrimaryKey("dbo.teams", "Id");
            AddPrimaryKey("dbo.playerPositions", "id");
            AddPrimaryKey("dbo.players", "id");
            AddPrimaryKey("dbo.fantasy_Team", "Id");
            AddPrimaryKey("dbo.fantasy_Roster", "Id");
            AddPrimaryKey("dbo.fantasy_Owner", "Id");
            AddPrimaryKey("dbo.fantasy_League", "Id");
            RenameColumn(table: "dbo.gameStats", name: "gameid_game_PK", newName: "gameId");
            RenameColumn(table: "dbo.games", name: "sportid_sport_PK", newName: "sportId");
            RenameColumn(table: "dbo.games", name: "hometeamid_team_PK", newName: "homeTeamId");
            RenameColumn(table: "dbo.games", name: "awayTeamid_team_PK", newName: "awayTeamId");
            RenameColumn(table: "dbo.fantasy_Roster", name: "playerid_player_PK", newName: "playerId");
            RenameColumn(table: "dbo.players", name: "teamid_team_PK", newName: "teamid");
            RenameColumn(table: "dbo.players", name: "playerPositionid_playerPosition_PK", newName: "playerPositionid");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_Teamsid_fantasy_Team_PK", newName: "fantasy_TeamId");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_Ownersid_fantasy_Owner_PK", newName: "fantasy_OwnerId");
            CreateIndex("dbo.teamInformations", "sportId");
            CreateIndex("dbo.teamInformations", "teamId");
            CreateIndex("dbo.teamInformations", "locationId");
            CreateIndex("dbo.stats", "statisticalCategoryid");
            CreateIndex("dbo.stats", "playerId");
            CreateIndex("dbo.gameStats", "statId");
            CreateIndex("dbo.gameStats", "gameId");
            CreateIndex("dbo.games", "awayTeamId");
            CreateIndex("dbo.games", "homeTeamId");
            CreateIndex("dbo.games", "sportId");
            CreateIndex("dbo.players", "playerPositionid");
            CreateIndex("dbo.players", "teamid");
            CreateIndex("dbo.fantasy_Roster", "sportId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_LeagueId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_OwnerId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_TeamId");
            CreateIndex("dbo.fantasy_Roster", "playerId");
            AddForeignKey("dbo.gameStats", "gameId", "dbo.games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.games", "sportId", "dbo.sports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.games", "homeTeamId", "dbo.teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.games", "awayTeamId", "dbo.teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "playerId", "dbo.players", "id", cascadeDelete: true);
            AddForeignKey("dbo.players", "teamid", "dbo.teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.players", "playerPositionid", "dbo.playerPositions", "id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "fantasy_TeamId", "dbo.fantasy_Team", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "fantasy_OwnerId", "dbo.fantasy_Owner", "Id", cascadeDelete: true);
            AddForeignKey("dbo.teamInformations", "teamId", "dbo.teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.teamInformations", "sportId", "dbo.sports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.teamInformations", "locationId", "dbo.locations", "id", cascadeDelete: true);
            AddForeignKey("dbo.gameStats", "statId", "dbo.stats", "Id", cascadeDelete: true);
            AddForeignKey("dbo.stats", "statisticalCategoryid", "dbo.statisticalCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.stats", "playerId", "dbo.players", "id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "sportId", "dbo.sports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League", "Id", cascadeDelete: true);
        }
    }
}

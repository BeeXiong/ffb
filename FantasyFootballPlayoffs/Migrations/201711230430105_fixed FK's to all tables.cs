namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedFKstoalltables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Rosters_fantasy_Rosters_PK", "dbo.fantasy_Roster");
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Rosters_fantasy_Rosters_PK" });
            RenameColumn(table: "dbo.fantasy_League_Member", name: "fantasy_Leagues_fantasy_League_PK", newName: "fantasy_Leagueid_fantasy_League_PK");
            RenameColumn(table: "dbo.fantasy_League", name: "sport_sport_PK", newName: "sportid_sport_PK");
            RenameColumn(table: "dbo.games", name: "sport_sport_PK", newName: "sportid_sport_PK");
            RenameColumn(table: "dbo.gameStats", name: "game_game_PK", newName: "gameid_game_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "player_player_PK", newName: "playerid_player_PK");
            RenameColumn(table: "dbo.gameStats", name: "player_player_PK", newName: "playerid_player_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_Owners_fantasy_Owner_PK", newName: "fantasy_Ownersid_fantasy_Owner_PK");
            RenameColumn(table: "dbo.fantasy_Team", name: "fantasy_Owners_fantasy_Owner_PK", newName: "fantasy_Ownerid_fantasy_Owner_PK");
            RenameColumn(table: "dbo.fantasy_League_Member", name: "fantasy_Teams_fantasy_Team_PK", newName: "fantasy_Teamsid_fantasy_Team_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_Teams_fantasy_Team_PK", newName: "fantasy_Teamsid_fantasy_Team_PK");
            RenameColumn(table: "dbo.gameStats", name: "statisticalCategory_statisticalCategory_PK", newName: "statisticalCategoryid_statisticalCategory_PK");
            RenameIndex(table: "dbo.fantasy_League_Member", name: "IX_fantasy_Leagues_fantasy_League_PK", newName: "IX_fantasy_Leagueid_fantasy_League_PK");
            RenameIndex(table: "dbo.fantasy_League_Member", name: "IX_fantasy_Teams_fantasy_Team_PK", newName: "IX_fantasy_Teamsid_fantasy_Team_PK");
            RenameIndex(table: "dbo.fantasy_League", name: "IX_sport_sport_PK", newName: "IX_sportid_sport_PK");
            RenameIndex(table: "dbo.games", name: "IX_sport_sport_PK", newName: "IX_sportid_sport_PK");
            RenameIndex(table: "dbo.fantasy_Roster", name: "IX_fantasy_Owners_fantasy_Owner_PK", newName: "IX_fantasy_Ownersid_fantasy_Owner_PK");
            RenameIndex(table: "dbo.fantasy_Roster", name: "IX_fantasy_Teams_fantasy_Team_PK", newName: "IX_fantasy_Teamsid_fantasy_Team_PK");
            RenameIndex(table: "dbo.fantasy_Roster", name: "IX_player_player_PK", newName: "IX_playerid_player_PK");
            RenameIndex(table: "dbo.fantasy_Team", name: "IX_fantasy_Owners_fantasy_Owner_PK", newName: "IX_fantasy_Ownerid_fantasy_Owner_PK");
            RenameIndex(table: "dbo.gameStats", name: "IX_game_game_PK", newName: "IX_gameid_game_PK");
            RenameIndex(table: "dbo.gameStats", name: "IX_player_player_PK", newName: "IX_playerid_player_PK");
            RenameIndex(table: "dbo.gameStats", name: "IX_statisticalCategory_statisticalCategory_PK", newName: "IX_statisticalCategoryid_statisticalCategory_PK");
            AddColumn("dbo.games", "awayTeamid_team_PK", c => c.Int());
            AddColumn("dbo.games", "hometeamid_team_PK", c => c.Int());
            CreateIndex("dbo.games", "awayTeamid_team_PK");
            CreateIndex("dbo.games", "hometeamid_team_PK");
            AddForeignKey("dbo.games", "awayTeamid_team_PK", "dbo.teams", "team_PK");
            AddForeignKey("dbo.games", "hometeamid_team_PK", "dbo.teams", "team_PK");
            DropColumn("dbo.fantasy_League_Member", "fantasy_League_FK");
            DropColumn("dbo.fantasy_League_Member", "fantasy_Team_FK");
            DropColumn("dbo.fantasy_League", "sport_FK");
            DropColumn("dbo.games", "homeTeam_FK");
            DropColumn("dbo.games", "awayTeam_FK");
            DropColumn("dbo.games", "sport_FK");
            DropColumn("dbo.gameStats", "game_FK");
            DropColumn("dbo.gameStats", "player_FK");
            DropColumn("dbo.gameStats", "statisticalCategory_FK");
            DropColumn("dbo.fantasy_Roster", "player_FK");
            DropColumn("dbo.fantasy_Roster", "fantasy_team_FK");
            DropColumn("dbo.fantasy_Roster", "fantasy_Owner_FK");
            DropColumn("dbo.fantasy_Roster", "fantasy_Rosters_fantasy_Rosters_PK");
            DropColumn("dbo.fantasy_Team", "fantasy_Owner_FK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_Team", "fantasy_Owner_FK", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "fantasy_Rosters_fantasy_Rosters_PK", c => c.Int());
            AddColumn("dbo.fantasy_Roster", "fantasy_Owner_FK", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "fantasy_team_FK", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "player_FK", c => c.Int(nullable: false));
            AddColumn("dbo.gameStats", "statisticalCategory_FK", c => c.Int(nullable: false));
            AddColumn("dbo.gameStats", "player_FK", c => c.Int(nullable: false));
            AddColumn("dbo.gameStats", "game_FK", c => c.Int(nullable: false));
            AddColumn("dbo.games", "sport_FK", c => c.Int(nullable: false));
            AddColumn("dbo.games", "awayTeam_FK", c => c.Int(nullable: false));
            AddColumn("dbo.games", "homeTeam_FK", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_League", "sport_FK", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_League_Member", "fantasy_Team_FK", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_League_Member", "fantasy_League_FK", c => c.Int(nullable: false));
            DropForeignKey("dbo.games", "hometeamid_team_PK", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamid_team_PK", "dbo.teams");
            DropIndex("dbo.games", new[] { "hometeamid_team_PK" });
            DropIndex("dbo.games", new[] { "awayTeamid_team_PK" });
            DropColumn("dbo.games", "hometeamid_team_PK");
            DropColumn("dbo.games", "awayTeamid_team_PK");
            RenameIndex(table: "dbo.gameStats", name: "IX_statisticalCategoryid_statisticalCategory_PK", newName: "IX_statisticalCategory_statisticalCategory_PK");
            RenameIndex(table: "dbo.gameStats", name: "IX_playerid_player_PK", newName: "IX_player_player_PK");
            RenameIndex(table: "dbo.gameStats", name: "IX_gameid_game_PK", newName: "IX_game_game_PK");
            RenameIndex(table: "dbo.fantasy_Team", name: "IX_fantasy_Ownerid_fantasy_Owner_PK", newName: "IX_fantasy_Owners_fantasy_Owner_PK");
            RenameIndex(table: "dbo.fantasy_Roster", name: "IX_playerid_player_PK", newName: "IX_player_player_PK");
            RenameIndex(table: "dbo.fantasy_Roster", name: "IX_fantasy_Teamsid_fantasy_Team_PK", newName: "IX_fantasy_Teams_fantasy_Team_PK");
            RenameIndex(table: "dbo.fantasy_Roster", name: "IX_fantasy_Ownersid_fantasy_Owner_PK", newName: "IX_fantasy_Owners_fantasy_Owner_PK");
            RenameIndex(table: "dbo.games", name: "IX_sportid_sport_PK", newName: "IX_sport_sport_PK");
            RenameIndex(table: "dbo.fantasy_League", name: "IX_sportid_sport_PK", newName: "IX_sport_sport_PK");
            RenameIndex(table: "dbo.fantasy_League_Member", name: "IX_fantasy_Teamsid_fantasy_Team_PK", newName: "IX_fantasy_Teams_fantasy_Team_PK");
            RenameIndex(table: "dbo.fantasy_League_Member", name: "IX_fantasy_Leagueid_fantasy_League_PK", newName: "IX_fantasy_Leagues_fantasy_League_PK");
            RenameColumn(table: "dbo.gameStats", name: "statisticalCategoryid_statisticalCategory_PK", newName: "statisticalCategory_statisticalCategory_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_Teamsid_fantasy_Team_PK", newName: "fantasy_Teams_fantasy_Team_PK");
            RenameColumn(table: "dbo.fantasy_League_Member", name: "fantasy_Teamsid_fantasy_Team_PK", newName: "fantasy_Teams_fantasy_Team_PK");
            RenameColumn(table: "dbo.fantasy_Team", name: "fantasy_Ownerid_fantasy_Owner_PK", newName: "fantasy_Owners_fantasy_Owner_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "fantasy_Ownersid_fantasy_Owner_PK", newName: "fantasy_Owners_fantasy_Owner_PK");
            RenameColumn(table: "dbo.gameStats", name: "playerid_player_PK", newName: "player_player_PK");
            RenameColumn(table: "dbo.fantasy_Roster", name: "playerid_player_PK", newName: "player_player_PK");
            RenameColumn(table: "dbo.gameStats", name: "gameid_game_PK", newName: "game_game_PK");
            RenameColumn(table: "dbo.games", name: "sportid_sport_PK", newName: "sport_sport_PK");
            RenameColumn(table: "dbo.fantasy_League", name: "sportid_sport_PK", newName: "sport_sport_PK");
            RenameColumn(table: "dbo.fantasy_League_Member", name: "fantasy_Leagueid_fantasy_League_PK", newName: "fantasy_Leagues_fantasy_League_PK");
            CreateIndex("dbo.fantasy_Roster", "fantasy_Rosters_fantasy_Rosters_PK");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_Rosters_fantasy_Rosters_PK", "dbo.fantasy_Roster", "fantasy_Rosters_PK");
        }
    }
}

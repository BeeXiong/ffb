namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.fantasy_League_Member",
                c => new
                    {
                        fantasy_League_Member_PK = c.Int(nullable: false, identity: true),
                        fantasy_League_FK = c.Int(nullable: false),
                        fantasy_Team_FK = c.Int(nullable: false),
                        isAMember = c.String(nullable: false, maxLength: 50),
                        fantasy_Leagues_fantasy_League_PK = c.Int(),
                        fantasy_Teams_fantasy_Team_PK = c.Int(),
                    })
                .PrimaryKey(t => t.fantasy_League_Member_PK)
                .ForeignKey("dbo.fantasy_League", t => t.fantasy_Leagues_fantasy_League_PK)
                .ForeignKey("dbo.fantasy_Team", t => t.fantasy_Teams_fantasy_Team_PK)
                .Index(t => t.fantasy_Leagues_fantasy_League_PK)
                .Index(t => t.fantasy_Teams_fantasy_Team_PK);
            
            CreateTable(
                "dbo.fantasy_League",
                c => new
                    {
                        fantasy_League_PK = c.Int(nullable: false, identity: true),
                        sport_FK = c.Int(nullable: false),
                        leagueName = c.String(nullable: false, maxLength: 50),
                        leaguePassword = c.String(maxLength: 50),
                        sport_sport_PK = c.Int(),
                    })
                .PrimaryKey(t => t.fantasy_League_PK)
                .ForeignKey("dbo.sports", t => t.sport_sport_PK)
                .Index(t => t.sport_sport_PK);
            
            CreateTable(
                "dbo.sports",
                c => new
                    {
                        sport_PK = c.Int(nullable: false, identity: true),
                        sportDescription = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.sport_PK);
            
            CreateTable(
                "dbo.games",
                c => new
                    {
                        game_PK = c.Int(nullable: false, identity: true),
                        homeTeam_FK = c.Int(nullable: false),
                        awayTeam_FK = c.Int(nullable: false),
                        sport_FK = c.Int(nullable: false),
                        isactive = c.String(maxLength: 50),
                        team_team_PK = c.Int(),
                        sport_sport_PK = c.Int(),
                    })
                .PrimaryKey(t => t.game_PK)
                .ForeignKey("dbo.teams", t => t.team_team_PK)
                .ForeignKey("dbo.sports", t => t.sport_sport_PK)
                .Index(t => t.team_team_PK)
                .Index(t => t.sport_sport_PK);
            
            CreateTable(
                "dbo.gameStats",
                c => new
                    {
                        gameStat_PK = c.Int(nullable: false, identity: true),
                        game_FK = c.Int(nullable: false),
                        player_FK = c.Int(nullable: false),
                        statisticalCategory_FK = c.Int(nullable: false),
                        yardage = c.Int(),
                        points = c.Int(),
                        statisticCategoryQuantity = c.Int(),
                        isATouchdown = c.String(maxLength: 50),
                        isAtdbetween35_49 = c.String(maxLength: 50),
                        isAtdOver50 = c.String(maxLength: 50),
                        game_game_PK = c.Int(),
                        player_player_PK = c.Int(),
                        statisticalCategory_statisticalCategory_PK = c.Int(),
                    })
                .PrimaryKey(t => t.gameStat_PK)
                .ForeignKey("dbo.games", t => t.game_game_PK)
                .ForeignKey("dbo.players", t => t.player_player_PK)
                .ForeignKey("dbo.statisticalCategories", t => t.statisticalCategory_statisticalCategory_PK)
                .Index(t => t.game_game_PK)
                .Index(t => t.player_player_PK)
                .Index(t => t.statisticalCategory_statisticalCategory_PK);
            
            CreateTable(
                "dbo.players",
                c => new
                    {
                        player_PK = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false, maxLength: 50),
                        lastName = c.String(maxLength: 50),
                        team_FK = c.Int(),
                        playerPosition_FK = c.Int(),
                        isHealthy = c.Int(),
                        isStarter = c.String(maxLength: 50),
                        isLoaded = c.String(maxLength: 50),
                        playerPosition_playerPosition_PK = c.Int(),
                        team_team_PK = c.Int(),
                    })
                .PrimaryKey(t => t.player_PK)
                .ForeignKey("dbo.playerPositions", t => t.playerPosition_playerPosition_PK)
                .ForeignKey("dbo.teams", t => t.team_team_PK)
                .Index(t => t.playerPosition_playerPosition_PK)
                .Index(t => t.team_team_PK);
            
            CreateTable(
                "dbo.fantasy_Roster",
                c => new
                    {
                        fantasy_Rosters_PK = c.Int(nullable: false, identity: true),
                        player_FK = c.Int(nullable: false),
                        fantasy_team_FK = c.Int(nullable: false),
                        fantasy_Owner_FK = c.Int(nullable: false),
                        fantasy_Owners_fantasy_Owner_PK = c.Int(),
                        fantasy_Teams_fantasy_Team_PK = c.Int(),
                        fantasy_Rosters_fantasy_Rosters_PK = c.Int(),
                        player_player_PK = c.Int(),
                    })
                .PrimaryKey(t => t.fantasy_Rosters_PK)
                .ForeignKey("dbo.fantasy_Owner", t => t.fantasy_Owners_fantasy_Owner_PK)
                .ForeignKey("dbo.fantasy_Team", t => t.fantasy_Teams_fantasy_Team_PK)
                .ForeignKey("dbo.fantasy_Roster", t => t.fantasy_Rosters_fantasy_Rosters_PK)
                .ForeignKey("dbo.players", t => t.player_player_PK)
                .Index(t => t.fantasy_Owners_fantasy_Owner_PK)
                .Index(t => t.fantasy_Teams_fantasy_Team_PK)
                .Index(t => t.fantasy_Rosters_fantasy_Rosters_PK)
                .Index(t => t.player_player_PK);
            
            CreateTable(
                "dbo.fantasy_Owner",
                c => new
                    {
                        fantasy_Owner_PK = c.Int(nullable: false, identity: true),
                        firstName = c.String(maxLength: 50),
                        lastName = c.String(nullable: false, maxLength: 50),
                        userName = c.String(maxLength: 50),
                        ownerPassword = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.fantasy_Owner_PK);
            
            CreateTable(
                "dbo.fantasy_Team",
                c => new
                    {
                        fantasy_Team_PK = c.Int(nullable: false, identity: true),
                        fantasy_Owner_FK = c.Int(nullable: false),
                        teamName = c.String(nullable: false, maxLength: 50),
                        nickName = c.String(maxLength: 50),
                        fantasy_Owners_fantasy_Owner_PK = c.Int(),
                    })
                .PrimaryKey(t => t.fantasy_Team_PK)
                .ForeignKey("dbo.fantasy_Owner", t => t.fantasy_Owners_fantasy_Owner_PK)
                .Index(t => t.fantasy_Owners_fantasy_Owner_PK);
            
            CreateTable(
                "dbo.playerPositions",
                c => new
                    {
                        playerPosition_PK = c.Int(nullable: false, identity: true),
                        position = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.playerPosition_PK);
            
            CreateTable(
                "dbo.teams",
                c => new
                    {
                        team_PK = c.Int(nullable: false, identity: true),
                        location_FK = c.Int(nullable: false),
                        sport_FK = c.Int(nullable: false),
                        teamName = c.String(nullable: false, maxLength: 50),
                        stadiumName = c.String(maxLength: 50),
                        location_location_PK = c.Int(),
                        sport_sport_PK = c.Int(),
                    })
                .PrimaryKey(t => t.team_PK)
                .ForeignKey("dbo.locations", t => t.location_location_PK)
                .ForeignKey("dbo.sports", t => t.sport_sport_PK)
                .Index(t => t.location_location_PK)
                .Index(t => t.sport_sport_PK);
            
            CreateTable(
                "dbo.locations",
                c => new
                    {
                        location_PK = c.Int(nullable: false, identity: true),
                        location = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.location_PK);
            
            CreateTable(
                "dbo.statisticalCategories",
                c => new
                    {
                        statisticalCategory_PK = c.Int(nullable: false, identity: true),
                        statisticalCategory = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.statisticalCategory_PK);
            
            CreateTable(
                "dbo.fantasy_Player_Slot",
                c => new
                    {
                        fantasy_Player_Slots_PK = c.Int(nullable: false),
                        player_Slot = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.fantasy_Player_Slots_PK, t.player_Slot });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.games", "sport_sport_PK", "dbo.sports");
            DropForeignKey("dbo.gameStats", "statisticalCategory_statisticalCategory_PK", "dbo.statisticalCategories");
            DropForeignKey("dbo.teams", "sport_sport_PK", "dbo.sports");
            DropForeignKey("dbo.players", "team_team_PK", "dbo.teams");
            DropForeignKey("dbo.teams", "location_location_PK", "dbo.locations");
            DropForeignKey("dbo.games", "team_team_PK", "dbo.teams");
            DropForeignKey("dbo.players", "playerPosition_playerPosition_PK", "dbo.playerPositions");
            DropForeignKey("dbo.gameStats", "player_player_PK", "dbo.players");
            DropForeignKey("dbo.fantasy_Roster", "player_player_PK", "dbo.players");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Rosters_fantasy_Rosters_PK", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Teams_fantasy_Team_PK", "dbo.fantasy_Team");
            DropForeignKey("dbo.fantasy_Team", "fantasy_Owners_fantasy_Owner_PK", "dbo.fantasy_Owner");
            DropForeignKey("dbo.fantasy_League_Member", "fantasy_Teams_fantasy_Team_PK", "dbo.fantasy_Team");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Owners_fantasy_Owner_PK", "dbo.fantasy_Owner");
            DropForeignKey("dbo.gameStats", "game_game_PK", "dbo.games");
            DropForeignKey("dbo.fantasy_League", "sport_sport_PK", "dbo.sports");
            DropForeignKey("dbo.fantasy_League_Member", "fantasy_Leagues_fantasy_League_PK", "dbo.fantasy_League");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.teams", new[] { "sport_sport_PK" });
            DropIndex("dbo.teams", new[] { "location_location_PK" });
            DropIndex("dbo.fantasy_Team", new[] { "fantasy_Owners_fantasy_Owner_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "player_player_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Rosters_fantasy_Rosters_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Teams_fantasy_Team_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Owners_fantasy_Owner_PK" });
            DropIndex("dbo.players", new[] { "team_team_PK" });
            DropIndex("dbo.players", new[] { "playerPosition_playerPosition_PK" });
            DropIndex("dbo.gameStats", new[] { "statisticalCategory_statisticalCategory_PK" });
            DropIndex("dbo.gameStats", new[] { "player_player_PK" });
            DropIndex("dbo.gameStats", new[] { "game_game_PK" });
            DropIndex("dbo.games", new[] { "sport_sport_PK" });
            DropIndex("dbo.games", new[] { "team_team_PK" });
            DropIndex("dbo.fantasy_League", new[] { "sport_sport_PK" });
            DropIndex("dbo.fantasy_League_Member", new[] { "fantasy_Teams_fantasy_Team_PK" });
            DropIndex("dbo.fantasy_League_Member", new[] { "fantasy_Leagues_fantasy_League_PK" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.fantasy_Player_Slot");
            DropTable("dbo.statisticalCategories");
            DropTable("dbo.locations");
            DropTable("dbo.teams");
            DropTable("dbo.playerPositions");
            DropTable("dbo.fantasy_Team");
            DropTable("dbo.fantasy_Owner");
            DropTable("dbo.fantasy_Roster");
            DropTable("dbo.players");
            DropTable("dbo.gameStats");
            DropTable("dbo.games");
            DropTable("dbo.sports");
            DropTable("dbo.fantasy_League");
            DropTable("dbo.fantasy_League_Member");
        }
    }
}

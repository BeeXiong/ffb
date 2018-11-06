namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class resetduetomergeconflicts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.gameStats", "gameid_Id", "dbo.games");
            DropForeignKey("dbo.gameStats", "playerid_Id", "dbo.players");
            DropForeignKey("dbo.gameStats", "statisticalCategoryid_Id", "dbo.statisticalCategories");
            DropForeignKey("dbo.players", "playerPositionId", "dbo.playerPositions");
            DropForeignKey("dbo.players", "teamId", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamid_Id", "dbo.teams");
            DropForeignKey("dbo.games", "hometeamid_Id", "dbo.teams");
            DropForeignKey("dbo.games", "sportid_Id", "dbo.sports");
            DropIndex("dbo.players", new[] { "teamId" });
            DropIndex("dbo.players", new[] { "playerPositionId" });
            DropIndex("dbo.games", new[] { "awayTeamid_Id" });
            DropIndex("dbo.games", new[] { "hometeamid_Id" });
            DropIndex("dbo.games", new[] { "sportid_Id" });
            DropIndex("dbo.gameStats", new[] { "gameid_Id" });
            DropIndex("dbo.gameStats", new[] { "playerid_Id" });
            DropIndex("dbo.gameStats", new[] { "statisticalCategoryid_Id" });
            RenameColumn(table: "dbo.games", name: "awayTeamid_Id", newName: "awayTeamId");
            RenameColumn(table: "dbo.games", name: "hometeamid_Id", newName: "homeTeamId");
            RenameColumn(table: "dbo.games", name: "sportid_Id", newName: "sportId");
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.players", t => t.playerId, cascadeDelete: true)
                .ForeignKey("dbo.statisticalCategories", t => t.statisticalCategoryid, cascadeDelete: true)
                .Index(t => t.playerId)
                .Index(t => t.statisticalCategoryid);
            
            AddColumn("dbo.zRawNFLRosters", "teamid", c => c.Int(nullable: false));
            AlterColumn("dbo.players", "teamid", c => c.Int(nullable: false));
            AlterColumn("dbo.players", "playerPositionid", c => c.Int(nullable: false));
            AlterColumn("dbo.players", "isHealthy", c => c.Int(nullable: true));
            AlterColumn("dbo.games", "awayTeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.games", "homeTeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.games", "sportId", c => c.Int(nullable: false));
            CreateIndex("dbo.players", "teamid");
            CreateIndex("dbo.players", "playerPositionid");
            CreateIndex("dbo.games", "sportId");
            CreateIndex("dbo.games", "homeTeamId");
            CreateIndex("dbo.games", "awayTeamId");
            AddForeignKey("dbo.players", "playerPositionid", "dbo.playerPositions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.players", "teamid", "dbo.teams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.games", "awayTeamId", "dbo.teams", "Id", cascadeDelete: false);
            AddForeignKey("dbo.games", "homeTeamId", "dbo.teams", "Id", cascadeDelete: false);
            AddForeignKey("dbo.games", "sportId", "dbo.sports", "Id", cascadeDelete: true);
            DropTable("dbo.gameStats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.gameStats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        yardage = c.Int(),
                        points = c.Int(),
                        statisticCategoryQuantity = c.Int(),
                        isATouchdown = c.String(maxLength: 50),
                        isAtdbetween35_49 = c.String(maxLength: 50),
                        isAtdOver50 = c.String(maxLength: 50),
                        gameid_Id = c.Int(),
                        playerid_Id = c.Int(),
                        statisticalCategoryid_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.games", "sportId", "dbo.sports");
            DropForeignKey("dbo.games", "homeTeamId", "dbo.teams");
            DropForeignKey("dbo.games", "awayTeamId", "dbo.teams");
            DropForeignKey("dbo.players", "teamid", "dbo.teams");
            DropForeignKey("dbo.players", "playerPositionid", "dbo.playerPositions");
            DropForeignKey("dbo.stats", "statisticalCategoryid", "dbo.statisticalCategories");
            DropForeignKey("dbo.stats", "playerId", "dbo.players");
            DropIndex("dbo.stats", new[] { "statisticalCategoryid" });
            DropIndex("dbo.stats", new[] { "playerId" });
            DropIndex("dbo.games", new[] { "awayTeamId" });
            DropIndex("dbo.games", new[] { "homeTeamId" });
            DropIndex("dbo.games", new[] { "sportId" });
            DropIndex("dbo.players", new[] { "playerPositionid" });
            DropIndex("dbo.players", new[] { "teamid" });
            AlterColumn("dbo.games", "sportId", c => c.Int());
            AlterColumn("dbo.games", "homeTeamId", c => c.Int());
            AlterColumn("dbo.games", "awayTeamId", c => c.Int());
            AlterColumn("dbo.players", "isHealthy", c => c.Int());
            AlterColumn("dbo.players", "playerPositionid", c => c.Int());
            AlterColumn("dbo.players", "teamid", c => c.Int());
            DropColumn("dbo.zRawNFLRosters", "teamid");
            DropTable("dbo.stats");
            RenameColumn(table: "dbo.games", name: "sportId", newName: "sportid_Id");
            RenameColumn(table: "dbo.games", name: "homeTeamId", newName: "hometeamid_Id");
            RenameColumn(table: "dbo.games", name: "awayTeamId", newName: "awayTeamid_Id");
            CreateIndex("dbo.gameStats", "statisticalCategoryid_Id");
            CreateIndex("dbo.gameStats", "playerid_Id");
            CreateIndex("dbo.gameStats", "gameid_Id");
            CreateIndex("dbo.games", "sportid_Id");
            CreateIndex("dbo.games", "hometeamid_Id");
            CreateIndex("dbo.games", "awayTeamid_Id");
            CreateIndex("dbo.players", "playerPositionId");
            CreateIndex("dbo.players", "teamId");
            AddForeignKey("dbo.games", "sportid_Id", "dbo.sports", "Id");
            AddForeignKey("dbo.games", "hometeamid_Id", "dbo.teams", "Id");
            AddForeignKey("dbo.games", "awayTeamid_Id", "dbo.teams", "Id");
            AddForeignKey("dbo.players", "teamId", "dbo.teams", "Id");
            AddForeignKey("dbo.players", "playerPositionId", "dbo.playerPositions", "Id");
            AddForeignKey("dbo.gameStats", "statisticalCategoryid_Id", "dbo.statisticalCategories", "Id");
            AddForeignKey("dbo.gameStats", "playerid_Id", "dbo.players", "Id");
            AddForeignKey("dbo.gameStats", "gameid_Id", "dbo.games", "Id");
        }
    }
}

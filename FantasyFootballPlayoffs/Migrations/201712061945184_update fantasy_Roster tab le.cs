namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefantasy_Rostertable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_teamId" });
            AddColumn("dbo.fantasy_Roster", "fantasy_LeagueId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "sportId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "sport_sport_PK", c => c.Int());
            CreateIndex("dbo.fantasy_Roster", "fantasy_TeamId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_LeagueId");
            CreateIndex("dbo.fantasy_Roster", "sport_sport_PK");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "sport_sport_PK", "dbo.sports", "sport_PK");
            DropColumn("dbo.fantasy_League", "sportId");
            DropTable("dbo.fantasy_Player_Slot");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.fantasy_Player_Slot",
                c => new
                    {
                        fantasy_Player_Slots_PK = c.Int(nullable: false),
                        player_Slot = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.fantasy_Player_Slots_PK, t.player_Slot });
            
            AddColumn("dbo.fantasy_League", "sportId", c => c.Int(nullable: false));
            DropForeignKey("dbo.fantasy_Roster", "sport_sport_PK", "dbo.sports");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League");
            DropIndex("dbo.fantasy_Roster", new[] { "sport_sport_PK" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_LeagueId" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_TeamId" });
            DropColumn("dbo.fantasy_Roster", "sport_sport_PK");
            DropColumn("dbo.fantasy_Roster", "sportId");
            DropColumn("dbo.fantasy_Roster", "fantasy_LeagueId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_teamId");
        }
    }
}

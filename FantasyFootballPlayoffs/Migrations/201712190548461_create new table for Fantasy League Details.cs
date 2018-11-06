namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createnewtableforFantasyLeagueDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League");
            DropForeignKey("dbo.fantasy_Roster", "fantasy_TeamId", "dbo.fantasy_Team");
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_TeamId" });
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_LeagueId" });
            CreateTable(
                "dbo.fantasy_League_Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fantasy_OwnerId = c.Int(nullable: false),
                        fantasy_LeagueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.fantasy_League", t => t.fantasy_LeagueId, cascadeDelete: true)
                .ForeignKey("dbo.fantasy_Owner", t => t.fantasy_OwnerId, cascadeDelete: true)
                .Index(t => t.fantasy_OwnerId)
                .Index(t => t.fantasy_LeagueId);
            
            DropColumn("dbo.fantasy_Roster", "fantasy_TeamId");
            DropColumn("dbo.fantasy_Roster", "fantasy_LeagueId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_Roster", "fantasy_LeagueId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Roster", "fantasy_TeamId", c => c.Int(nullable: false));
            DropForeignKey("dbo.fantasy_League_Detail", "fantasy_OwnerId", "dbo.fantasy_Owner");
            DropForeignKey("dbo.fantasy_League_Detail", "fantasy_LeagueId", "dbo.fantasy_League");
            DropIndex("dbo.fantasy_League_Detail", new[] { "fantasy_LeagueId" });
            DropIndex("dbo.fantasy_League_Detail", new[] { "fantasy_OwnerId" });
            DropTable("dbo.fantasy_League_Detail");
            CreateIndex("dbo.fantasy_Roster", "fantasy_LeagueId");
            CreateIndex("dbo.fantasy_Roster", "fantasy_TeamId");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_TeamId", "dbo.fantasy_Team", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Roster", "fantasy_LeagueId", "dbo.fantasy_League", "Id", cascadeDelete: true);
        }
    }
}

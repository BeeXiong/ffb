namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdplayerslotFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_Roster", "fantasy_Player_SlotId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_Roster", "fantasy_Player_SlotId");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_Player_SlotId", "dbo.fantasy_Player_Slot", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Player_SlotId", "dbo.fantasy_Player_Slot");
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Player_SlotId" });
            DropColumn("dbo.fantasy_Roster", "fantasy_Player_SlotId");
        }
    }
}

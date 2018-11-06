namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeplayerslotstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_Roster", "fantasy_Player_SlotId", c => c.Int(nullable: false));
            AlterColumn("dbo.fantasy_Player_Slot", "playerSlot", c => c.String());
            CreateIndex("dbo.fantasy_Roster", "fantasy_Player_SlotId");
            //AddForeignKey("dbo.fantasy_Roster", "fantasy_Player_SlotId", "dbo.fantasy_Player_Slot", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Player_SlotId", "dbo.fantasy_Player_Slot");
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Player_SlotId" });
            AlterColumn("dbo.fantasy_Player_Slot", "playerSlot", c => c.Int(nullable: false));
            DropColumn("dbo.fantasy_Roster", "fantasy_Player_SlotId");
        }
    }
}

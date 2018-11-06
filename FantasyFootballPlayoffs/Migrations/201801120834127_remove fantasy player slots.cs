namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefantasyplayerslots : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_Roster", "fantasy_Player_SlotId", "dbo.fantasy_Player_Slot");
            DropIndex("dbo.fantasy_Roster", new[] { "fantasy_Player_SlotId" });
            DropColumn("dbo.fantasy_Roster", "fantasy_Player_SlotId");
            DropTable("dbo.fantasy_Player_Slot");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.fantasy_Player_Slot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        playerSlot = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.fantasy_Roster", "fantasy_Player_SlotId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_Roster", "fantasy_Player_SlotId");
            AddForeignKey("dbo.fantasy_Roster", "fantasy_Player_SlotId", "dbo.fantasy_Player_Slot", "Id", cascadeDelete: true);
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class readdplayerslotstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.fantasy_Player_Slot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        playerSlot = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.fantasy_Player_Slot");
        }
    }
}

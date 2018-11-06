namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reworkingplayerslottable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.fantasy_Player_Slot", "D1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "D2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "K1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "K2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "QB1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "QB2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "RB1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "RB2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "TE1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "TE2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "WR1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "WR2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "WR3Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "WR4Id", "dbo.fantasy_Roster");
            DropIndex("dbo.fantasy_Player_Slot", new[] { "QB1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "QB2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "RB1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "RB2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "WR1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "WR2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "WR3Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "WR4Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "TE1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "TE2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "D1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "D2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "K1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "K2Id" });
            AddColumn("dbo.fantasy_Player_Slot", "playerSlot", c => c.Int(nullable: false));
            DropColumn("dbo.fantasy_Player_Slot", "QB1Id");
            DropColumn("dbo.fantasy_Player_Slot", "QB2Id");
            DropColumn("dbo.fantasy_Player_Slot", "RB1Id");
            DropColumn("dbo.fantasy_Player_Slot", "RB2Id");
            DropColumn("dbo.fantasy_Player_Slot", "WR1Id");
            DropColumn("dbo.fantasy_Player_Slot", "WR2Id");
            DropColumn("dbo.fantasy_Player_Slot", "WR3Id");
            DropColumn("dbo.fantasy_Player_Slot", "WR4Id");
            DropColumn("dbo.fantasy_Player_Slot", "TE1Id");
            DropColumn("dbo.fantasy_Player_Slot", "TE2Id");
            DropColumn("dbo.fantasy_Player_Slot", "D1Id");
            DropColumn("dbo.fantasy_Player_Slot", "D2Id");
            DropColumn("dbo.fantasy_Player_Slot", "K1Id");
            DropColumn("dbo.fantasy_Player_Slot", "K2Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_Player_Slot", "K2Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "K1Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "D2Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "D1Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "TE2Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "TE1Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "WR4Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "WR3Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "WR2Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "WR1Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "RB2Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "RB1Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "QB2Id", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Player_Slot", "QB1Id", c => c.Int(nullable: false));
            DropColumn("dbo.fantasy_Player_Slot", "playerSlot");
            CreateIndex("dbo.fantasy_Player_Slot", "K2Id");
            CreateIndex("dbo.fantasy_Player_Slot", "K1Id");
            CreateIndex("dbo.fantasy_Player_Slot", "D2Id");
            CreateIndex("dbo.fantasy_Player_Slot", "D1Id");
            CreateIndex("dbo.fantasy_Player_Slot", "TE2Id");
            CreateIndex("dbo.fantasy_Player_Slot", "TE1Id");
            CreateIndex("dbo.fantasy_Player_Slot", "WR4Id");
            CreateIndex("dbo.fantasy_Player_Slot", "WR3Id");
            CreateIndex("dbo.fantasy_Player_Slot", "WR2Id");
            CreateIndex("dbo.fantasy_Player_Slot", "WR1Id");
            CreateIndex("dbo.fantasy_Player_Slot", "RB2Id");
            CreateIndex("dbo.fantasy_Player_Slot", "RB1Id");
            CreateIndex("dbo.fantasy_Player_Slot", "QB2Id");
            CreateIndex("dbo.fantasy_Player_Slot", "QB1Id");
            AddForeignKey("dbo.fantasy_Player_Slot", "WR4Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "WR3Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "WR2Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "WR1Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "TE2Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "TE1Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "RB2Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "RB1Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "QB2Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "QB1Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "K2Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "K1Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "D2Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
            AddForeignKey("dbo.fantasy_Player_Slot", "D1Id", "dbo.fantasy_Roster", "Id", cascadeDelete: true);
        }
    }
}

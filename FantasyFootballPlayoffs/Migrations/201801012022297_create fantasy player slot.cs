namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createfantasyplayerslot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.fantasy_Player_Slot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QB1Id = c.Int(nullable: false),
                        QB2Id = c.Int(nullable: false),
                        RB1Id = c.Int(nullable: false),
                        RB2Id = c.Int(nullable: false),
                        WR1Id = c.Int(nullable: false),
                        WR2Id = c.Int(nullable: false),
                        WR3Id = c.Int(nullable: false),
                        WR4Id = c.Int(nullable: false),
                        TE1Id = c.Int(nullable: false),
                        TE2Id = c.Int(nullable: false),
                        D1Id = c.Int(nullable: false),
                        D2Id = c.Int(nullable: false),
                        K1Id = c.Int(nullable: false),
                        K2Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.fantasy_Roster", t => t.D1Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.D2Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.K1Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.K2Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.QB1Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.QB2Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.RB1Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.RB2Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.TE1Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.TE2Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.WR1Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.WR2Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.WR3Id, cascadeDelete: false)
                .ForeignKey("dbo.fantasy_Roster", t => t.WR4Id, cascadeDelete: false)
                .Index(t => t.QB1Id)
                .Index(t => t.QB2Id)
                .Index(t => t.RB1Id)
                .Index(t => t.RB2Id)
                .Index(t => t.WR1Id)
                .Index(t => t.WR2Id)
                .Index(t => t.WR3Id)
                .Index(t => t.WR4Id)
                .Index(t => t.TE1Id)
                .Index(t => t.TE2Id)
                .Index(t => t.D1Id)
                .Index(t => t.D2Id)
                .Index(t => t.K1Id)
                .Index(t => t.K2Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.fantasy_Player_Slot", "WR4Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "WR3Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "WR2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "WR1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "TE2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "TE1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "RB2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "RB1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "QB2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "QB1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "K2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "K1Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "D2Id", "dbo.fantasy_Roster");
            DropForeignKey("dbo.fantasy_Player_Slot", "D1Id", "dbo.fantasy_Roster");
            DropIndex("dbo.fantasy_Player_Slot", new[] { "K2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "K1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "D2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "D1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "TE2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "TE1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "WR4Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "WR3Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "WR2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "WR1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "RB2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "RB1Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "QB2Id" });
            DropIndex("dbo.fantasy_Player_Slot", new[] { "QB1Id" });
            DropTable("dbo.fantasy_Player_Slot");
        }
    }
}

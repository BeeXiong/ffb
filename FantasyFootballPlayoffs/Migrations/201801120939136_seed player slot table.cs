namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedplayerslottable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('QB1')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('QB2')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('RB1')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('RB2')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('WR1')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('WR2')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('WR3')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('WR4')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('TE1')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('TE2')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('D1')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('D2')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('K1')" + Environment.NewLine +
"INSERT INTO [dbo].[fantasy_Player_Slot] (playerSlot) VALUES ('K2')");
        }
    
        
        public override void Down()
        {
        }
    }
}

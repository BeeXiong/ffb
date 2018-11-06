namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserFKtofantasyteamtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_Team", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.fantasy_Team", "user_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.fantasy_Team", "user_Id");
            AddForeignKey("dbo.fantasy_Team", "user_Id", "dbo.User", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.fantasy_Team", "user_Id", "dbo.User");
            DropIndex("dbo.fantasy_Team", new[] { "user_Id" });
            DropColumn("dbo.fantasy_Team", "user_Id");
            DropColumn("dbo.fantasy_Team", "userId");
        }
    }
}

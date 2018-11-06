namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connectingusertablewithfantansyleaguetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_League", "userId", c => c.String(maxLength: 128));
            CreateIndex("dbo.fantasy_League", "userId");
            AddForeignKey("dbo.fantasy_League", "userId", "dbo.User", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.fantasy_League", "userId", "dbo.User");
            DropIndex("dbo.fantasy_League", new[] { "userId" });
            DropColumn("dbo.fantasy_League", "userId");
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertuserIdtostringfromInt : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.fantasy_Team", new[] { "user_Id" });
            DropColumn("dbo.fantasy_Team", "userId");
            RenameColumn(table: "dbo.fantasy_Team", name: "user_Id", newName: "userId");
            AlterColumn("dbo.fantasy_Team", "userId", c => c.String(maxLength: 128));
            CreateIndex("dbo.fantasy_Team", "userId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.fantasy_Team", new[] { "userId" });
            AlterColumn("dbo.fantasy_Team", "userId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.fantasy_Team", name: "userId", newName: "user_Id");
            AddColumn("dbo.fantasy_Team", "userId", c => c.Int(nullable: false));
            CreateIndex("dbo.fantasy_Team", "user_Id");
        }
    }
}

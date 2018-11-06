namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addentrycodetoleaguetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_League", "entryCode", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.fantasy_League", "entryCode");
        }
    }
}

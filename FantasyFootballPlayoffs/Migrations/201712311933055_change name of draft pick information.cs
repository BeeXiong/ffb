namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenameofdraftpickinformation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.fantasy_Roster", "draftPickNumber", c => c.Int(nullable: false));
            DropColumn("dbo.fantasy_Roster", "roundDrafted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.fantasy_Roster", "roundDrafted", c => c.Int(nullable: false));
            DropColumn("dbo.fantasy_Roster", "draftPickNumber");
        }
    }
}

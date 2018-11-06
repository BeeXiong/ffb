namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reworkingstatstableforFGandPointsallowed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.stats", "PAT", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isAFG39", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isAFG49", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isAFG59", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isAFG60", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "points0", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "points7", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "points20", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "points27", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "points34", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "points35", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.stats", "points35");
            DropColumn("dbo.stats", "points34");
            DropColumn("dbo.stats", "points27");
            DropColumn("dbo.stats", "points20");
            DropColumn("dbo.stats", "points7");
            DropColumn("dbo.stats", "points0");
            DropColumn("dbo.stats", "isAFG60");
            DropColumn("dbo.stats", "isAFG59");
            DropColumn("dbo.stats", "isAFG49");
            DropColumn("dbo.stats", "isAFG39");
            DropColumn("dbo.stats", "PAT");
        }
    }
}

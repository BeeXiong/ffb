namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustedisAcolumnstobeBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.stats", "isATouchdown", c => c.Boolean(nullable: false));
            AlterColumn("dbo.stats", "isAtdbetween35_49", c => c.Boolean(nullable: false));
            AlterColumn("dbo.stats", "isAtdOver50", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.stats", "isAtdOver50", c => c.String());
            AlterColumn("dbo.stats", "isAtdbetween35_49", c => c.String());
            AlterColumn("dbo.stats", "isATouchdown", c => c.String());
        }
    }
}

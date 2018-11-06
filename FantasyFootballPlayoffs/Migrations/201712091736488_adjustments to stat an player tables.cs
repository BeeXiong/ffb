namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adjustmentstostatanplayertables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.players", "isHealthy", c => c.String());
            AlterColumn("dbo.stats", "yardage", c => c.Int(nullable: false));
            AlterColumn("dbo.stats", "points", c => c.Int(nullable: false));
            AlterColumn("dbo.stats", "isATouchdown", c => c.String());
            AlterColumn("dbo.stats", "isAtdbetween35_49", c => c.String());
            AlterColumn("dbo.stats", "isAtdOver50", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.stats", "isAtdOver50", c => c.String(maxLength: 50));
            AlterColumn("dbo.stats", "isAtdbetween35_49", c => c.String(maxLength: 50));
            AlterColumn("dbo.stats", "isATouchdown", c => c.String(maxLength: 50));
            AlterColumn("dbo.stats", "points", c => c.Int());
            AlterColumn("dbo.stats", "yardage", c => c.Int());
            AlterColumn("dbo.players", "isHealthy", c => c.Int(nullable: false));
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revisestattable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.stats", "passAttempt", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "passCompletion", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "passYards", c => c.Int(nullable: false));
            AddColumn("dbo.stats", "isAPassTouchdown", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isAinterception", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "rushAttempt", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "rushYards", c => c.Int(nullable: false));
            AddColumn("dbo.stats", "isARushTouchdown", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isAFumble", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "target", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "reception", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "recYards", c => c.Int(nullable: false));
            AddColumn("dbo.stats", "isARecTouchdown", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isA2Point", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isASack", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isADefensiveTD", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isAFumbleRecovery", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "isASafety", c => c.Boolean(nullable: false));
            DropColumn("dbo.stats", "yardage");
            DropColumn("dbo.stats", "isATouchdown");
        }
        
        public override void Down()
        {
            AddColumn("dbo.stats", "isATouchdown", c => c.Boolean(nullable: false));
            AddColumn("dbo.stats", "yardage", c => c.Int(nullable: false));
            DropColumn("dbo.stats", "isASafety");
            DropColumn("dbo.stats", "isAFumbleRecovery");
            DropColumn("dbo.stats", "isADefensiveTD");
            DropColumn("dbo.stats", "isASack");
            DropColumn("dbo.stats", "isA2Point");
            DropColumn("dbo.stats", "isARecTouchdown");
            DropColumn("dbo.stats", "recYards");
            DropColumn("dbo.stats", "reception");
            DropColumn("dbo.stats", "target");
            DropColumn("dbo.stats", "isAFumble");
            DropColumn("dbo.stats", "isARushTouchdown");
            DropColumn("dbo.stats", "rushYards");
            DropColumn("dbo.stats", "rushAttempt");
            DropColumn("dbo.stats", "isAinterception");
            DropColumn("dbo.stats", "isAPassTouchdown");
            DropColumn("dbo.stats", "passYards");
            DropColumn("dbo.stats", "passCompletion");
            DropColumn("dbo.stats", "passAttempt");
        }
    }
}

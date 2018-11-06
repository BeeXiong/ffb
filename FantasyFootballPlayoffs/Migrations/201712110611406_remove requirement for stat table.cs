namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removerequirementforstattable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.statisticalCategories", "statisticalCategory", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.statisticalCategories", "statisticalCategory", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

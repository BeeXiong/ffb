namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createnullablefieldsinstatstabl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.stats", "statisticalCategoryid", "dbo.statisticalCategories");
            DropIndex("dbo.stats", new[] { "statisticalCategoryid" });
            AlterColumn("dbo.stats", "statisticalCategoryid", c => c.Int());
            AlterColumn("dbo.stats", "passYards", c => c.Int());
            AlterColumn("dbo.stats", "rushYards", c => c.Int());
            AlterColumn("dbo.stats", "recYards", c => c.Int());
            CreateIndex("dbo.stats", "statisticalCategoryid");
            AddForeignKey("dbo.stats", "statisticalCategoryid", "dbo.statisticalCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.stats", "statisticalCategoryid", "dbo.statisticalCategories");
            DropIndex("dbo.stats", new[] { "statisticalCategoryid" });
            AlterColumn("dbo.stats", "recYards", c => c.Int(nullable: false));
            AlterColumn("dbo.stats", "rushYards", c => c.Int(nullable: false));
            AlterColumn("dbo.stats", "passYards", c => c.Int(nullable: false));
            AlterColumn("dbo.stats", "statisticalCategoryid", c => c.Int(nullable: false));
            CreateIndex("dbo.stats", "statisticalCategoryid");
            AddForeignKey("dbo.stats", "statisticalCategoryid", "dbo.statisticalCategories", "Id", cascadeDelete: true);
        }
    }
}

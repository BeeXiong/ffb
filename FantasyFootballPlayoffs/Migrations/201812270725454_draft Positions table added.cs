namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class draftPositionstableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.draftPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        draftPositionNumber = c.Int(nullable: false),
                        detailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.fantasy_League_Detail", t => t.detailId, cascadeDelete: true)
                .Index(t => t.detailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.draftPositions", "detailId", "dbo.fantasy_League_Detail");
            DropIndex("dbo.draftPositions", new[] { "detailId" });
            DropTable("dbo.draftPositions");
        }
    }
}

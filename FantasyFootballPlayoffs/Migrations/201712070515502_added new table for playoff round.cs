namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewtableforplayoffround : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.playoffRounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        round = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.playoffRounds");
        }
    }
}

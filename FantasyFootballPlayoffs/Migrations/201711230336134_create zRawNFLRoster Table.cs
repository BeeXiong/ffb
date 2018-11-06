namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createzRawNFLRosterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.zRawNFLRosters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        playerPosition = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        location = c.String(),
                        teamName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.zRawNFLRosters");
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeround : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.games", "playoffRoundId", "dbo.playoffRounds");
            DropIndex("dbo.games", new[] { "playoffRoundId" });
            DropColumn("dbo.games", "playoffRoundId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.games", "playoffRoundId", c => c.Int(nullable: false));
            CreateIndex("dbo.games", "playoffRoundId");
            AddForeignKey("dbo.games", "playoffRoundId", "dbo.playoffRounds", "Id", cascadeDelete: true);
        }
    }
}

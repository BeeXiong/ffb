namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingerrors : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            AddColumn("dbo.games", "playoffRoundId", c => c.Int(nullable: false));
            CreateIndex("dbo.games", "playoffRoundId");
            AddForeignKey("dbo.games", "playoffRoundId", "dbo.playoffRounds", "Id", cascadeDelete: true);
        }
    }
}

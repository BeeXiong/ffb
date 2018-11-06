namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gametableupdatedtoincluderound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.games", "playoffRoundId", c => c.Int(nullable: false));
            CreateIndex("dbo.games", "playoffRoundId");
            AddForeignKey("dbo.games", "playoffRoundId", "dbo.playoffRounds", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            //DropForeignKey("dbo.games", "playoffRoundId", "dbo.playoffRounds");
            //DropIndex("dbo.games", new[] { "playoffRoundId" });
            //DropColumn("dbo.games", "playoffRoundId");
        }
    }
}

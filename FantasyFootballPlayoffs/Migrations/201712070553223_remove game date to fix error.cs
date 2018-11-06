namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removegamedatetofixerror : DbMigration
    {
        public override void Up()
        {
          
        }
        
        public override void Down()
        {
            AddColumn("dbo.games", "gameDate", c => c.String());
        }
    }
}

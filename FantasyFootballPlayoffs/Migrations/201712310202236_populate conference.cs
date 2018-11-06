namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateconference : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[conferences] (conferenceName) VALUES ('AFC')" + Environment.NewLine +
"INSERT INTO [dbo].[conferences] (conferenceName) VALUES ('NFC')" );
    }
        
        public override void Down()
        {
        }
    }
}

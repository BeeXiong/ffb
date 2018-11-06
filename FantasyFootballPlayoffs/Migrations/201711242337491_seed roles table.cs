namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedrolestable : DbMigration
    {
        public override void Up()
        {
            
            Sql("INSERT INTO Roles(RoleId, Name) VALUES (1, 'Admin')");
            Sql("INSERT INTO Roles(RoleId, Name) VALUES (2, 'LeagueAdmin')");
            Sql("INSERT INTO Roles(RoleId, Name) VALUES (3, 'User')");
        }
        
        public override void Down()
        {
            
        }
    }
}

namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFKteamTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.teams", name: "sport_sport_PK", newName: "sportid_sport_PK");
            RenameColumn(table: "dbo.teams", name: "location_location_PK", newName: "locationid_location_PK");
            RenameIndex(table: "dbo.teams", name: "IX_location_location_PK", newName: "IX_locationid_location_PK");
            RenameIndex(table: "dbo.teams", name: "IX_sport_sport_PK", newName: "IX_sportid_sport_PK");
            DropColumn("dbo.teams", "location_FK");
            DropColumn("dbo.teams", "sport_FK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.teams", "sport_FK", c => c.Int(nullable: false));
            AddColumn("dbo.teams", "location_FK", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.teams", name: "IX_sportid_sport_PK", newName: "IX_sport_sport_PK");
            RenameIndex(table: "dbo.teams", name: "IX_locationid_location_PK", newName: "IX_location_location_PK");
            RenameColumn(table: "dbo.teams", name: "locationid_location_PK", newName: "location_location_PK");
            RenameColumn(table: "dbo.teams", name: "sportid_sport_PK", newName: "sport_sport_PK");
        }
    }
}

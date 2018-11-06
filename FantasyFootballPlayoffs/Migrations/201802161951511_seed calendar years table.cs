namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedcalendaryearstable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[calendarYears] (year) VALUES ('2017')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2018')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2019')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2020')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2021')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2022')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2023')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2024')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2025')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2026')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2027')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2028')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2029')" + Environment.NewLine +
"INSERT INTO [dbo].[calendarYears] (year) VALUES ('2030')");
        }
    
        
        public override void Down()
        {
        }
    }
}

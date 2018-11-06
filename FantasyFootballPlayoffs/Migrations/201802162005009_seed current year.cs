namespace FantasyFootballPlayoffs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FantasyFootballPlayoffs.Models;

    public partial class seedcurrentyear : DbMigration
    {
        private FantasyDbContext _context;
        private int yearPK;

        public seedcurrentyear()
        {
            _context = new FantasyDbContext();
        }
        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}
        public int determineCurrentYear()
        {
            DateTime currentYear;
            currentYear = DateTime.Now;
            return currentYear.Year;
        }

        public override void Up()
        {
            int currentYear = determineCurrentYear();

            var yearRecord = _context.calendarYears.Where(m => m.year == currentYear).ToList();
            Sql("INSERT INTO [dbo].[currentYears] (calendarYearId) VALUES ("+ yearRecord.First().Id +")");
        }
        
        public override void Down()
        {
        }
    }
}

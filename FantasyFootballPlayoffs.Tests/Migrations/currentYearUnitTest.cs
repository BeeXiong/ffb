using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FantasyFootballPlayoffs.Models;

namespace FantasyFootballPlayoffs.Tests.Migrations
{
    [TestClass]
    public class currentYearUnitTest
    {
        private FantasyDbContext _context;

        public currentYearUnitTest()
        {
            _context = new FantasyDbContext();
        }

        [TestMethod]
        public void determineYearTest()
        {
            // Arrange
            DateTime currentDateTime;
            int currentyear;
            
            int yearPK;

            // Act
            currentDateTime = DateTime.Now;
            currentyear = currentDateTime.Year;
            var yearRecord = _context.calendarYears.Where(m => m.year == currentyear).ToList();
            yearPK = yearRecord.First().Id;

            // Assert
            Assert.AreEqual(2 ,yearPK);
        }
    }
}

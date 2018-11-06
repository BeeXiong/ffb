using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyFootballPlayoffs.Models
{
    public class currentYear
    {
        public int Id { get; set; }
        public int calendarYearId { get; set; }
        public virtual calendarYear calendarYear { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public class fantasy_League_Detail
    {
        [Key]
        public int Id { get; set; }
        //public int fantasy_OwnerId { get; set; }
        public int fantasy_LeagueId { get; set; }
        public int fantasy_TeamId { get; set; }
        public string userId { get; set; }
        public int calendarYearId { get; set; }

        //public virtual fantasy_Owner fantasy_Owner { get; set; }
        public virtual fantasy_League fantasy_League { get; set; }
        public virtual fantasy_Team fantasy_Team { get; set; }
        public virtual User user { get; set; }
        public virtual calendarYear calendarYear { get; set; }


    }
}
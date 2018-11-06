using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FantasyFootballPlayoffs.Models
{
    public class teamInformation
    {
        public int Id { get; set; }
        public int locationId { get; set; }
        public int homeTeamId { get; set; }
        public int awayTeamId { get; set; }
        public int sportId { get; set; }

        [Display(Name = "Team Name")]
        public string fullTeamName { get; set; }

        public virtual location location { get; set; }
        public virtual homeTeam homeTeam { get; set; }
        public virtual awayTeam awayTeam { get; set; }
        public virtual sport sport { get; set; }
        
        
    }
}
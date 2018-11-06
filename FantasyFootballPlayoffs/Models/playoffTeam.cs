using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public class playoffTeam
    {
        public int Id { get; set; }
        [Display(Name = "Team")]
        public int homeTeamId { get; set; }
        [Display(Name = "Conference")]
        public int conferenceId { get; set; }

        [Display(Name = "Playoff Seed")]
        public int playoffSeed { get; set; }

        [Display(Name = "Year")]
        public int year { get; set; }

        public virtual homeTeam homeTeam { get; set; } 
        public virtual conference conference { get; set; }
    }
}
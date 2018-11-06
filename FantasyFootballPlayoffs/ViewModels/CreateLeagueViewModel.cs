using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballPlayoffs.ViewModels
{
    public class CreateLeagueViewModel
    {
        public ICollection<fantasy_League> commishLeagues { get; set; }
        public ICollection<fantasy_League_Detail> leagueDetails { get; set; }
        public int Id { get; set; }
        public fantasy_League fantasy_League { get; set; }
        public User commish { get; set; }

        //public string leagueName { get; set; }

        //public string leaguePassword { get; set; }

        //public string userId { get; set; }

    }
}
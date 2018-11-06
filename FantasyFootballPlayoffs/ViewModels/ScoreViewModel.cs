using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballPlayoffs.ViewModels
{
    public class ScoreViewModel
    {
        public ICollection<fantasy_Roster> leagueRosters { get; set; }
        public ICollection<fantasy_League_Detail> leagueTeams { get; set; } 
        public ICollection<roundPoints> points { get; set; }
    }
}
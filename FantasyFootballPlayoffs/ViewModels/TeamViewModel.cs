using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;

namespace FantasyFootballPlayoffs.ViewModels
{
    public class TeamViewModel
    {
        public ICollection<fantasy_Roster> teamRoster { get; set; }

        public fantasy_League_Detail teamDetail { get; set; }

        public ICollection<roundPoints> points { get; set; }
        public ICollection<playoffTeam> eliminatedTteams { get; set; }
    }
}
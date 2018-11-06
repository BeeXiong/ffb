using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballPlayoffs.ViewModels
{
    public class CreateTeamsViewModel
    {
        public ICollection<fantasy_League> fantasy_Leagues { get; set; }
        public ICollection<fantasy_League_Detail> userTeams { get; set; }

        public int Id { get; set; }

        public fantasy_League_Detail fantasy_League_Detail { get; set; }
        public fantasy_League fantasy_League_Error { get; set; }
        public User fantasyPlayer { get; set; }

    }
}
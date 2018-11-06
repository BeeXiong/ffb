using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballPlayoffs.ViewModels
{
    public class fantasyTeamViewModel
    {
        public fantasy_Team fantasty_Team { get; set; }
        public int Id { get; set; }
    }
}
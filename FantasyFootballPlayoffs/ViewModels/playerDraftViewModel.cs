using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;
using System.ComponentModel.DataAnnotations;


namespace FantasyFootballPlayoffs.ViewModels
{
    public class PlayerDraftViewModel
    {
        public int id { get; set; }

        public ICollection<player> players { get; set; }

        public ICollection<playoffTeam> playoffteams { get; set; }

        public ICollection<fantasy_Roster> draftedPlayers { get; set; }

        public ICollection<fantasy_Roster> currentTeam { get; set; }

        public fantasy_League_Detail fantasyDetail { get; set; }
        
        public fantasy_Roster lastPick { get; set; }

    }
}
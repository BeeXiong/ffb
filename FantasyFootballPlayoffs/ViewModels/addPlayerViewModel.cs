using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;

namespace FantasyFootballPlayoffs.ViewModels
{
    public class AddPlayerViewModel
    {
        public ICollection<playerPosition> playerPositions;
        public ICollection<player> playoffTeamPlayers;

        public playoffTeam SelectedTeam { get; set; }
        public player newPlayer { get; set; }
        public playerPosition position { get; set; }
    }
}
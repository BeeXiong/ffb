using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballPlayoffs.ViewModels
{
    public class CreateGameViewModel
    {
    
        public ICollection<teamInformation> HomeTeamNames { get; set; }
        public ICollection<teamInformation> AwayTeamNames { get; set; }
        public ICollection<game> currentGames { get; set; }
        public ICollection<homeTeam> teams { get; set; } 
        public ICollection<conference> conferences { get; set; }
        public playoffTeam playoffTeam { get; set; }

        [Key]
        public int Id { get; set; }
        public int sportId { get; set; }

        [Display(Name = "Home Team Name")]
        public int homeTeamId { get; set; }
 
        [Display(Name = "Away Team Name")]
        public int awayTeamId { get; set; }
        public string isactive { get; set; }
        public int playoffRoundId { get; set; }

    }
}
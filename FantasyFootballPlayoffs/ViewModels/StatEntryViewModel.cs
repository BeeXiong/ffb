using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballPlayoffs.ViewModels
{
    public class StatEntryViewModel
    {
        //public IEnumerable<player> gamePlayers;
        public IEnumerable<statisticalCategory> statCategories;
        public ICollection<playerinformation> gamePlayers;
        public ICollection<stat> gamestats;
        public ICollection<boxScoreStat> boxScoreStats;
        public game game { get; set; }
        public stat gameStat { get; set; }

        public int Id { get;set;}
        public int gameId { get; set; }

        //viewModel bind from html variables
        public int playerId { get; set; }

        public int? statisticalCategoryid { get; set; }

        public bool passAttempt { get; set; }

        public bool passCompletion { get; set; }

        public int? passYards { get; set; }

        public bool isAPassTouchdown { get; set; }

        public bool isAinterception { get; set; }

        public bool rushAttempt { get; set; }

        public int? rushYards { get; set; }

        public bool isARushTouchdown { get; set; }

        public bool isAFumble { get; set; }

        public bool target { get; set; }

        public bool reception { get; set; }

        public int? recYards { get; set; }

        public bool isARecTouchdown { get; set; }

        public bool isAtdbetween35_49 { get; set; }

        public bool isAtdOver50 { get; set; }

        public bool isA2Point { get; set; }

        public bool isASack { get; set; }

        public bool isADefensiveTD { get; set; }

        public bool isAFumbleRecovery { get; set; }

        public bool isASafety { get; set; }

        public int points { get; set; }

        public int? statisticCategoryQuantity { get; set; }

        public bool PAT { get; set; }

        public bool isAFG39 { get; set; }

        public bool isAFG49 { get; set; }

        public bool isAFG59 { get; set; }

        public bool isAFG60 { get; set; }

        public bool points0 { get; set; }

        public bool points7 { get; set; }

        public bool points20 { get; set; }

        public bool points27 { get; set; }

        public bool points34 { get; set; }

        public bool points35 { get; set; }


    }
}
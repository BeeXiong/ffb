using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballPlayoffs.Models
{
    public class roundStats
    {
        public int? playerId { get; set; }

        public int? Comp { get; set; }

        public int? Att { get; set; }

        public int? PassingYards { get; set; }

        public int? PassTD { get; set; }

        public int? Rush { get; set; }

        public int? RushYards { get; set; }

        public int?RushTd { get; set; }

        public int? Rec { get; set; }

        public int? RecYards { get; set; }

        public int? RecTD { get; set; }

        public int? td3549 { get; set; }

        public int? td50 { get; set; }

        public int? twoPt { get; set; }

        public int? Fum { get; set; }

        public int? Int { get; set; }

        public int? Sack { get; set; }

        public int? DefTD { get; set; }

        public int? FumRec { get; set; }

        public int? Safety { get; set; }

        public int? PAT { get; set; }

        public int? FG39 { get; set; }

        public int? FG49 { get; set; }

        public int? FG59 { get; set; }

        public int? FG60 { get; set; }

        public int? points0 { get; set; }

        public int? points7 { get; set; }

        public int? points20 { get; set; }

        public int? points27 { get; set; }

        public int? points34 { get; set; }

        public int? points35 { get; set; }

        public int? StatisticalCategoryid { get; set; }

        public int? StatQuantity { get; set; }

        public int? gameId { get; set; }

        public int? fantasy_Player_SlotId { get; set; }

        public int? fantasy_TeamId { get; set; }

        public int? fantasy_LeagueId { get; set; }

        public int? fantasy_League_DetailId { get; set; }

        public int? RosterId { get; set; }

        public int? playoffRoundId { get; set; }

        public int? playerPositionId { get; set; }

        public player player { get; set; }

    }
}
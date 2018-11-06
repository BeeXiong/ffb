using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FantasyFootballPlayoffs.Models;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballPlayoffs.Models
{
    public class roundPoints
    {
        public int playerId { get; set; }

        public int? playoffRoundId { get; set; }

        public decimal? playerPoints { get; set; }
    }
}
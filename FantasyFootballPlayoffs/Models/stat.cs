    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
        public partial class stat
    {
        [Key]
        public int Id { get; set; }

        public int playerId { get; set; }

        public int gameId { get; set; }
  
        public int? statisticalCategoryid { get; set; }

        [Display(Name = "Pass Attempt")]
        public bool passAttempt { get; set; }

        [Display(Name = "Pass Completion")]
        public bool passCompletion { get; set; }

        [Display(Name = "Pass Yards")]
        public int? passYards { get; set; }

        [Display(Name = "Pass TD")]
        public bool isAPassTouchdown { get; set; }

        [Display(Name = "Pass Int")]
        public bool isAinterception { get; set; }

        [Display(Name = "Rush")]
        public bool rushAttempt { get; set; }

        [Display (Name= "Rush Yards")]
        public int? rushYards { get; set; }

        [Display(Name = "Rush TD")]
        public bool isARushTouchdown { get; set; }

        [Display(Name = "Fumble")]
        public bool isAFumble { get; set; }

        [Display(Name = "Target")]
        public bool target { get; set; }

        [Display(Name = "Rec")]
        public bool reception { get; set; }

        [Display(Name = "Rec Yards")]
        public int? recYards { get; set; }

        [Display(Name = "Rec TD")]
        public bool isARecTouchdown { get; set; }

        [Display(Name = "TD 35-49")]
        public bool isAtdbetween35_49 { get; set; }

        [Display(Name = "TD 50+")]
        public bool isAtdOver50 { get; set; }

        [Display(Name = "2pt Conv")]
        public bool isA2Point { get; set; }

        [Display(Name = "Sack")]
        public bool isASack { get; set; }

        [Display(Name = "Def TD")]
        public bool isADefensiveTD { get; set; }

        [Display(Name = "Fum Rec")]
        public bool isAFumbleRecovery { get; set; }

        [Display(Name = "Safety")]
        public bool isASafety { get; set; }

        [Display(Name = "Points")]
        public int points { get; set; }
        
        [Display(Name = "PAT")]
        public bool PAT { get; set; }

        [Display(Name = "FG 17-39")]
        public bool isAFG39 { get; set; }

        [Display(Name = "FG 40-49")]
        public bool isAFG49 { get; set; }

        [Display(Name = "FG 50-59")]
        public bool isAFG59 { get; set; }

        [Display(Name = "FG 60+")]
        public bool isAFG60 { get; set; }

        [Display(Name = "Points Allowed - 0")]
        public bool points0 { get; set; }

        [Display(Name = "Points Allowed - 1-7")]
        public bool points7 { get; set; }

        [Display(Name = "Points Allowed - 8-20")]
        public bool points20 { get; set; }

        [Display(Name = "Points Allowed - 21-27")]
        public bool points27 { get; set; }

        [Display(Name = "Points Allowed - 28-34")]
        public bool points34 { get; set; }

        [Display(Name = "Points Allowed - 35+")]
        public bool points35 { get; set; }

        [Display(Name = "Quantity")]
        public int? statisticCategoryQuantity { get; set; }

        [Display(Name = "Player")]
        public virtual player player { get; set; }

        [Display(Name = "Stat Category")]
        public virtual statisticalCategory statisticalCategory { get; set; }

        public virtual game game { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FantasyFootballPlayoffs.Models
{
    public class draftPosition
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Draft Position")]
        public int draftPositionNumber { get; set; }

        public int detailId { get; set; }

        public virtual fantasy_League_Detail detail { get; set; }
    }
}
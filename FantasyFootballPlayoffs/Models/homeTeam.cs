    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class homeTeam
    {

        [Key]
        public int Id { get; set; }

        public int locationId { get; set; }

        //public int sportId { get; set; }

        [StringLength(50)]
        [Display(Name = "Home Team Name")]
        public string homeTeamName { get; set; }

        [StringLength(50)]
        public string stadiumName { get; set; }

        public virtual location location { get; set; }

        //public virtual sport sport { get; set; }
    }
}

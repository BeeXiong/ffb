    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class awayTeam
    {
        [Key]
        public int Id { get; set; }

        public int locationId { get; set; }

        [StringLength(50)]
        [Display(Name = "Away Team Name")]
        public string awayTeamName { get; set; }

        [StringLength(50)]
        public string stadiumName { get; set; }
        public virtual location location { get; set; }

    }
}

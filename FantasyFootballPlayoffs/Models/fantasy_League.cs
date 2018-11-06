    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class fantasy_League
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "League Name")]
        public string leagueName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "League Password")]
        public string leaguePassword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Entry Code")]
        public string entryCode { get; set; }
        public int amountOfTeams { get; set; }

        public string userId { get; set; }

        public virtual User user { get; set; }
    }
}

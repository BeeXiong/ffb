    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class fantasy_Team
    {
        [Key]
        public int Id { get; set; }
        //public string userId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Team Name")]
        public string teamName { get; set; }

        [StringLength(50)]
        [Display(Name = "Nick Name")]
        public string nickName { get; set; }

    }
}

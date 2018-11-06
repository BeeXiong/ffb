    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class sport
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Sport")]
        public string sportDescription { get; set; }

    }
}

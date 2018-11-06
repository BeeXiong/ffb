    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class location
    {
        public int Id { get; set; }
        [Column("location")]
        [Required]
        [StringLength(50)]
        public string teamLocation { get; set; }
    }
}

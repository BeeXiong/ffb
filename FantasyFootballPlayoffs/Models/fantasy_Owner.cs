   using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class fantasy_Owner
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [StringLength(50)]
        public string userName { get; set; }

        [StringLength(50)]
        public string ownerPassword { get; set; }
    }
}

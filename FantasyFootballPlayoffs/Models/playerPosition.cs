    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class playerPosition
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string position { get; set; }

    }
}

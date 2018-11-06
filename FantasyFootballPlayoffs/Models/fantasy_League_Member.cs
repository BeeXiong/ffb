using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class fantasy_League_Member
    {
        [Key]
        public int id { get; set; }


        [Required]
        [StringLength(50)]
        public string isAMember { get; set; }

    }
}

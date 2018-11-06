    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class fantasy_Player_Slot
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        public string playerSlot { get; set; }
    }
}

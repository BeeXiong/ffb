    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class fantasy_Roster
    {
        [Key]
        public int Id { get; set; }

        public int draftPickNumber { get; set; }

        public int playerId { get; set; }

        public int sportId { get; set; }

        public int fantasy_Player_SlotId { get; set; }

        public int fantasy_League_DetailId { get; set; }

        public virtual player player { get; set; }

        public virtual fantasy_League_Detail fantasy_League_Detail { get; set; }

        public virtual sport sport { get; set; }

        public virtual fantasy_Player_Slot fantasy_Player_Slot { get; set; }
    }
}

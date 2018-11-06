    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class game
    {

        [Key]
        public int Id { get; set; }

        public int sportId { get; set; }

        public int homeTeamId { get; set; }
        
        public int awayTeamId { get; set; }

        public int playoffRoundId { get; set; }

        [StringLength(50)]
        public string isactive { get; set; }

        public virtual sport sport { get; set; }

        [ForeignKey("homeTeamId")]
        public virtual homeTeam homeTeam { get; set; }

        [ForeignKey("awayTeamId")]
        public virtual awayTeam awayTeam { get; set; }

        public virtual playoffRound playoffRound { get; set; }
        public string gameDate { get; set; }
    }
}

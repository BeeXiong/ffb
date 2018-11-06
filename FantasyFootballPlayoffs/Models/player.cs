    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class player
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Player Name")]
        public string firstName { get; set; }

        [StringLength(50)]
        public string lastName { get; set; }

        public int teamid { get; set; }

        public int playerPositionid { get; set; }

        public string isHealthy { get; set; }

        [StringLength(50)]
        public string isStarter { get; set; }

        [StringLength(50)]
        public string isLoaded { get; set; }

        public int calendarYearId { get; set; }

        public virtual calendarYear calendarYear { get; set; }

        public virtual playerPosition playerPosition { get; set; }

        public virtual homeTeam team { get; set; }
    }
}

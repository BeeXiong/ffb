using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyFootballPlayoffs.Models
{
    public class gameStat
    {
        public int Id { get; set; }

        //public int game_FK { get; set; }

        //public int player_FK { get; set; }

        //public int statisticalCategory_FK { get; set; }

        public int? yardage { get; set; }

        public int? points { get; set; }

        public int? statisticCategoryQuantity { get; set; }

        [StringLength(50)]
        public string isATouchdown { get; set; }

        [StringLength(50)]
        public string isAtdbetween35_49 { get; set; }

        [StringLength(50)]
        public string isAtdOver50 { get; set; }

        public virtual game gameid { get; set; }

        public virtual player playerid { get; set; }

        public virtual statisticalCategory statisticalCategoryid { get; set; }
        public int gameId { get; set; }
        public int statId { get; set; }
        public virtual game game { get; set; }
        public virtual stat stat { get; set; }
    }
}
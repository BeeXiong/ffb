    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public partial class statisticalCategory
    {
        public int Id { get; set; }

        [Column("statisticalCategory")]
        [StringLength(50)]
        [Display(Name = "Stat Category")]
        public string statisticalCategories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public class conference
    {
        public int id { get; set; }
        [Display(Name = "Conference")]
        public string conferenceName { get; set; }
    }
}
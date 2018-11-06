using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace FantasyFootballPlayoffs.Models
{
    public class draftedPlayer
    {
        public int Id { get; set; }

        public int roundDrafted { get; set; }

        public int playerId {get;set;}



        public player player { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyFootballPlayoffs.Models
{
    public class zRawNFLRoster
    {
        public int id { get; set; }
        public string playerPosition { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string location { get; set; }
        public string teamName { get; set; }
        public int teamid { get; set; }


    }
}
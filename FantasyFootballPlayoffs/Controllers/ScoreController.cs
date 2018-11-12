using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FantasyFootballPlayoffs.Models;
using Microsoft.AspNet.Identity;
using FantasyFootballPlayoffs.ViewModels;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace FantasyFootballPlayoffs.Controllers
{
    public class ScoreController : Controller
    {
        private FantasyDbContext _context;

        public ScoreController()
        {
            _context = new FantasyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Scores
        public ActionResult Index()
        {
            return View();
        }

        // GET: Scores/Details/5
        public ActionResult view(int leagueId)
        {
            var teamInLeague = _context.fantasy_League_Details.First(m => m.fantasy_LeagueId == leagueId);
            var leagueYear = teamInLeague.currentYearId;

            string currentUserId = User.Identity.GetUserId();
            var leagueRosters = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.fantasy_LeagueId == leagueId ).ToList();
            var leagueTeams = _context.fantasy_League_Details.Where(m => m.fantasy_LeagueId == leagueId).ToList();
            //var playoffRounds = _context.playoffRounds.ToList();

            var sqlText = "SELECT        stats.playerId, SUM(CAST(stats.passCompletion AS INT)) AS Comp, SUM(CAST(stats.passAttempt AS INT)) AS Att, COALESCE (SUM(stats.passYards), 0) AS PassingYards, SUM(CAST(stats.isAPassTouchdown AS INT)) AS PassTD, " + Environment.NewLine +
"                         SUM(CAST(stats.rushAttempt AS INT)) AS Rush, COALESCE (SUM(stats.rushYards), 0) AS RushYards, SUM(CAST(stats.isARushTouchdown AS INT)) AS RushTD, SUM(CAST(stats.target AS INT)) AS Target, " + Environment.NewLine +
"                         SUM(CAST(stats.reception AS INT)) AS Rec, COALESCE (SUM(stats.recYards), 0) AS RecYards, SUM(CAST(stats.isARecTouchdown AS INT)) AS RecTD, SUM(CAST(stats.isAtdbetween35_49 AS INT)) AS td3549, " + Environment.NewLine +
"                         SUM(CAST(stats.isAtdOver50 AS INT)) AS td50, SUM(CAST(stats.isA2Point AS INT)) AS twoPt, SUM(CAST(stats.isAFumble AS INT)) AS Fum, SUM(CAST(stats.isAinterception AS INT)) AS Int, SUM(CAST(stats.isASack AS INT)) " + Environment.NewLine +
"                         AS Sack, SUM(CAST(stats.isADefensiveTD AS INT)) AS DefTD, SUM(CAST(stats.isAFumbleRecovery AS INT)) AS FumRec, SUM(CAST(stats.isASafety AS INT)) AS Safety, SUM(CAST(stats.PAT AS INT)) AS PAT, " + Environment.NewLine +
"                         SUM(CAST(stats.isAFG39 AS INT)) AS FG39, SUM(CAST(stats.isAFG49 AS INT)) AS FG49, SUM(CAST(stats.isAFG59 AS INT)) AS FG59, SUM(CAST(stats.isAFG60 AS INT)) AS FG60, SUM(CAST(stats.points0 AS INT)) AS points0, " + Environment.NewLine +
"                         SUM(CAST(stats.points7 AS INT)) AS points7, SUM(CAST(stats.points20 AS INT)) AS points20, SUM(CAST(stats.points27 AS INT)) AS points27, SUM(CAST(stats.points34 AS INT)) AS points34, SUM(CAST(stats.points35 AS INT)) " + Environment.NewLine +
"                         AS points35, stats.gameId, fantasy_Roster.fantasy_Player_SlotId, fantasy_League_Detail.fantasy_TeamId, fantasy_League_Detail.fantasy_LeagueId, fantasy_Roster.fantasy_League_DetailId, games.playoffRoundId, " + Environment.NewLine +
"                         playerPositions.Id AS playerPositionId, games.calendarYearId" + Environment.NewLine +
"FROM            stats INNER JOIN" + Environment.NewLine +
"                         fantasy_Roster ON stats.playerId = fantasy_Roster.playerId INNER JOIN" + Environment.NewLine +
"                         fantasy_League_Detail ON fantasy_Roster.fantasy_League_DetailId = fantasy_League_Detail.Id INNER JOIN" + Environment.NewLine +
"                         games ON stats.gameId = games.Id INNER JOIN" + Environment.NewLine +
"                         players ON stats.playerId = players.Id INNER JOIN" + Environment.NewLine +
"                         playerPositions ON players.playerPositionId = playerPositions.Id" + Environment.NewLine +
"GROUP BY stats.playerId, stats.statisticalCategoryid, stats.statisticCategoryQuantity, stats.gameId, fantasy_Roster.fantasy_Player_SlotId, fantasy_League_Detail.fantasy_TeamId, fantasy_League_Detail.fantasy_LeagueId, " + Environment.NewLine +
"                         fantasy_Roster.fantasy_League_DetailId, games.playoffRoundId, playerPositions.Id, games.calendarYearId" + Environment.NewLine +
"HAVING                   (games.calendarYearId = " + leagueYear + ")";

            var test = _context.Database.SqlQuery<roundStats>(sqlText).ToList();
            var playerPoints = new List<roundPoints>();
            

            foreach(var player in leagueRosters)
            {
                var fantasyStats = test.Where(m => m.playerId == player.playerId).ToList();

                if(fantasyStats.Count > 0)
                {
                    for (int i = 0; i < fantasyStats.Count; i++)
                    {
                        var roundPts = new roundPoints();
                        decimal? fantasyPoints = 0;
                        decimal? points = 0;
                        points = (decimal)fantasyStats[i].PassingYards / 25;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].PassTD * 4;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].Fum * -2;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)(fantasyStats[i].RushYards) / 10;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].RushTd * 6;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].RecYards / 10;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].RecTD * 6;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].Rec * 1 / 2;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].td50 * 2;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].td3549 * 1;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].twoPt * 2;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].Sack * 1;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].DefTD * 6;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].FumRec * 2;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].Safety * 2;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].PAT * 1;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].FG39 * 3;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].FG49 * 4;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].FG59 * 5;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].FG60 * 8;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].points0 * 10;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].points7 * 7;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].points20 * 3;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].points27 * 1;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].points34 * 0;
                        fantasyPoints = fantasyPoints + points;
                        points = (decimal)fantasyStats[i].points35 * -5;
                        fantasyPoints = fantasyPoints + points;

                        if (fantasyStats[i].PassingYards >= 400)
                        {
                            points = 3;
                            fantasyPoints = fantasyPoints + points;
                        }
                        else if (fantasyStats[i].PassingYards >= 300)
                        {
                            points = 2;
                            fantasyPoints = fantasyPoints + points;
                        }
                        if (fantasyStats[i].RushYards >= 200)
                        {
                            points = 3;
                            fantasyPoints = fantasyPoints + points;
                        }
                        else if (fantasyStats[i].RushYards >= 100)
                        {
                            points = 2;
                            fantasyPoints = fantasyPoints + points;
                        }
                        if (fantasyStats[i].RecYards >= 200)
                        {
                            points = 3;
                            fantasyPoints = fantasyPoints + points;
                        }
                        else if (fantasyStats[i].RecYards >= 100)
                        {
                            points = 2;
                            fantasyPoints = fantasyPoints + points;
                        }
                        if (fantasyStats[i].Int > 0 && fantasyStats[i].playerPositionId == 1)
                        {
                            points = (decimal)fantasyStats[i].Int * -2;
                            fantasyPoints = fantasyPoints + points;
                        }
                        else if (fantasyStats[i].Int > 0 && fantasyStats[i].playerPositionId == 5)
                        {
                            points = (decimal)fantasyStats[i].Int * 2;
                            fantasyPoints = fantasyPoints + points;
                        }

                        roundPts.playerPoints = fantasyPoints;
                        roundPts.playerId = player.playerId;
                        roundPts.playoffRoundId = fantasyStats[i].playoffRoundId;
                        playerPoints.Add(roundPts);
                        roundPts = null;
                    }
                } 

            }

            var viewModel = new ScoreViewModel()
            {
                leagueRosters = leagueRosters,
                leagueTeams = leagueTeams,
                points = playerPoints,
            };

            return View(viewModel);
        }
    }
}

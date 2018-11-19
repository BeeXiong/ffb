using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FantasyFootballPlayoffs.Models;
using FantasyFootballPlayoffs.ViewModels;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace FantasyFootballPlayoffs.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatsController : Controller
    {
        
        private FantasyDbContext _context;

        public StatsController()
        {
            _context = new FantasyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Stats
        public ActionResult Index()
        {
            var Playoff_FantasyDb = _context.games;
            return View(Playoff_FantasyDb);
        }

        // GET: Stats/createGames
        public ActionResult createGames()
        {
            string sqlText;

            sqlText = "SELECT        locations.location + ' ' + homeTeams.homeTeamName AS fullTeamName, homeTeams.id" + Environment.NewLine +
" FROM            homeTeams INNER JOIN" + Environment.NewLine +
"                         locations ON homeTeams.locationid = locations.id";

            var listofHomeTeams = _context.Database.SqlQuery<teamInformation>(sqlText).ToList();

            sqlText = "SELECT        locations.location + ' ' + awayTeams.awayTeamName AS fullTeamName, awayTeams.id" + Environment.NewLine +
" FROM            awayTeams INNER JOIN" + Environment.NewLine +
"                         locations ON awayTeams.locationid = locations.id";

            var listofAwayTeams = _context.Database.SqlQuery<teamInformation>(sqlText).ToList();

            sqlText = "SELECT        Id, year" + Environment.NewLine +
" FROM            calendarYears";

            var listofYears = _context.Database.SqlQuery<calendarYear>(sqlText).ToList();

            var listofcurrentGames = _context.games.ToList();

            var viewModel = new CreateGameViewModel()
            {
                HomeTeamNames = listofHomeTeams,
                AwayTeamNames = listofAwayTeams,
                currentGames = listofcurrentGames,
                years = listofYears
            };

            return View(viewModel);
        }
        // POST: Stats/createGames
        [HttpPost]
        public ActionResult createGames(CreateGameViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                string sqlText;
                string date = DateTime.Now.ToString("MM/dd/yyyy");

                sqlText = "INSERT        " + Environment.NewLine +
"INTO              games(homeTeamId, awayTeamId, isactive, sportId, playoffRoundId, gameDate, calendarYearId)" + Environment.NewLine +
"VALUES        (" + model.homeTeamId + ", " + model.awayTeamId + ", '" + model.isactive + "' , " + model.sportId+ ", " + model.playoffRoundId + ", '" + date + "', " + model.gameYearId + ")";

                _context.Database.ExecuteSqlCommand(sqlText);


                return RedirectToAction("Index");
            }
            catch(DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult gameDelete(int gameId)
        {
            try
            {
                var deletedGame = new game();
                deletedGame = _context.games.SingleOrDefault(m => m.Id == gameId);

                if (deletedGame == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    _context.games.Remove(deletedGame);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // POST: Stats/Edit/id(of the game)
        [HttpPost]
        public ActionResult SaveStat(int id, StatEntryViewModel stat)
        {
            try
            {
                // id represents the statId and if it is -1 it is a new stat that will get saved.
                if(id == -1)
                {
                    var gameStat = new stat();

                    gameStat.playerId = stat.playerId;
                    gameStat.gameId = stat.gameId;
                    gameStat.statisticalCategoryid = stat.statisticalCategoryid;
                    gameStat.passAttempt = stat.passAttempt;
                    gameStat.passCompletion = stat.passCompletion;
                    gameStat.passYards = stat.passYards;
                    gameStat.isAPassTouchdown = stat.isAPassTouchdown;
                    gameStat.isAinterception = stat.isAinterception;
                    gameStat.rushAttempt = stat.rushAttempt;
                    gameStat.rushYards = stat.rushYards;
                    gameStat.isARushTouchdown = stat.isARushTouchdown;
                    gameStat.isAFumble = stat.isAFumble;
                    gameStat.target = stat.target;
                    gameStat.reception = stat.reception;
                    gameStat.recYards = stat.recYards;
                    gameStat.isARecTouchdown = stat.isARecTouchdown;
                    gameStat.isAtdbetween35_49 = stat.isAtdbetween35_49;
                    gameStat.isAtdOver50 = stat.isAtdOver50;
                    gameStat.isA2Point = stat.isA2Point;
                    gameStat.isASack = stat.isASack;
                    gameStat.isADefensiveTD = stat.isADefensiveTD;
                    gameStat.isAFumbleRecovery = stat.isAFumbleRecovery;
                    gameStat.isASafety = stat.isASafety;
                    gameStat.PAT = stat.PAT;
                    gameStat.isAFG39 = stat.isAFG39;
                    gameStat.isAFG49 = stat.isAFG49;
                    gameStat.isAFG59 = stat.isAFG59;
                    gameStat.isAFG60 = stat.isAFG60;
                    gameStat.points0 = stat.points0;
                    gameStat.points7 = stat.points7;
                    gameStat.points20 = stat.points20;
                    gameStat.points27 = stat.points27;
                    gameStat.points34 = stat.points34;
                    gameStat.points35 = stat.points35;

                    _context.stats.Add(gameStat);
                    _context.SaveChanges();

                    //gets the game where the stat was saved to and passes it in the redirect
                    var game_Id = stat.gameId;

                    return RedirectToAction("AddStats", "Stats", new { gameId = game_Id });
                }
                else //if it is not -1 it will get the stat from the viewModel and query the stat. Changes will be made to that record and it will be updated.
                {
                    var stat_Id = stat.Id;

                    stat revisedStat = _context.stats.SingleOrDefault(m => m.Id == stat_Id);

                    revisedStat.playerId = stat.playerId;
                    revisedStat.gameId = stat.gameId;
                    revisedStat.statisticalCategoryid = stat.statisticalCategoryid;
                    revisedStat.passAttempt = stat.passAttempt;
                    revisedStat.passCompletion = stat.passCompletion;
                    revisedStat.passYards = stat.passYards;
                    revisedStat.isAPassTouchdown = stat.isAPassTouchdown;
                    revisedStat.isAinterception = stat.isAinterception;
                    revisedStat.rushAttempt = stat.rushAttempt;
                    revisedStat.rushYards = stat.rushYards;
                    revisedStat.isARushTouchdown = stat.isARushTouchdown;
                    revisedStat.isAFumble = stat.isAFumble;
                    revisedStat.target = stat.target;
                    revisedStat.reception = stat.reception;
                    revisedStat.recYards = stat.recYards;
                    revisedStat.isARecTouchdown = stat.isARecTouchdown;
                    revisedStat.isAtdbetween35_49 = stat.isAtdbetween35_49;
                    revisedStat.isAtdOver50 = stat.isAtdOver50;
                    revisedStat.isA2Point = stat.isA2Point;
                    revisedStat.isASack = stat.isASack;
                    revisedStat.isADefensiveTD = stat.isADefensiveTD;
                    revisedStat.isAFumbleRecovery = stat.isAFumbleRecovery;
                    revisedStat.isASafety = stat.isASafety;
                    revisedStat.PAT = stat.PAT;
                    revisedStat.isAFG39 = stat.isAFG39;
                    revisedStat.isAFG49 = stat.isAFG49;
                    revisedStat.isAFG59 = stat.isAFG59;
                    revisedStat.isAFG60 = stat.isAFG60;
                    revisedStat.points0 = stat.points0;
                    revisedStat.points7 = stat.points7;
                    revisedStat.points20 = stat.points20;
                    revisedStat.points27 = stat.points27;
                    revisedStat.points34 = stat.points34;
                    revisedStat.points35 = stat.points35;

                    _context.SaveChanges();

                    //gets the game where the stat was saved to and passes it in the redirect
                    var game_Id = revisedStat.gameId;

                    return RedirectToAction("AddStats", "Stats", new { gameId = game_Id });
                }

            }
            catch
            {
                return View();
            }
        }

        public ViewResult AddStats(int gameId)
        {
            //add viewmodel
            var listOfStatCategories = _context.statisticalCategories.ToList();
            var game_Id = gameId;
            var currentgame = _context.games.SingleOrDefault(m => m.Id == gameId);
            var listOfStats = _context.stats.Where(m => m.gameId == game_Id).ToList();

            var sqlText = "SELECT        firstName + ' ' + lastName AS fullName, teamId, Id AS playerId" + Environment.NewLine +
"FROM            players" + Environment.NewLine +
"WHERE        (teamId = " + currentgame.homeTeamId + ") AND (calendarYearId = " + currentgame.calendarYearId + ") OR" + Environment.NewLine +
"                         (teamId = " + currentgame.awayTeamId + ") AND (calendarYearId = " + currentgame.calendarYearId + ")";

            var listOfPlayers = _context.Database.SqlQuery<playerinformation>(sqlText).ToList();

            sqlText = "SELECT        stats.playerId, players.firstName, players.lastName, SUM(CAST(stats.passCompletion AS INT)) AS Comp, SUM(CAST(stats.passAttempt AS INT)) AS Att, COALESCE(SUM(stats.passYards), 0) AS PassingYards," + Environment.NewLine +
                         "SUM(CAST(stats.isAPassTouchdown AS INT)) AS PassTD, SUM(CAST(stats.rushAttempt AS INT)) AS Rush, COALESCE(SUM(stats.rushYards), 0) AS RushYards, SUM(CAST(stats.isARushTouchdown AS INT)) AS RushTD," + Environment.NewLine +
                         "SUM(CAST(stats.target AS INT)) AS Target, SUM(CAST(stats.reception AS INT)) AS Rec, COALESCE(SUM(stats.recYards), 0) AS RecYards, SUM(CAST(stats.isARecTouchdown AS INT)) AS RecTD," + Environment.NewLine +
                         "SUM(CAST(stats.isAtdbetween35_49 AS INT)) AS td3549, SUM(CAST(stats.isAtdOver50 AS INT)) AS td50, SUM(CAST(stats.isA2Point AS INT)) AS twoPt, SUM(CAST(stats.isAFumble AS INT)) AS Fum," + Environment.NewLine +
                         "SUM(CAST(stats.isAinterception AS INT)) AS Int, SUM(CAST(stats.isASack AS INT)) AS Sack, SUM(CAST(stats.isADefensiveTD AS INT)) AS DefTD, SUM(CAST(stats.isAFumbleRecovery AS INT)) AS FumRec," + Environment.NewLine +
                         "SUM(CAST(stats.isASafety AS INT)) AS Safety, SUM(CAST(stats.PAT AS INT)) AS PAT, SUM(CAST(stats.isAFG39 AS INT)) AS FG39, SUM(CAST(stats.isAFG49 AS INT)) AS FG49, SUM(CAST(stats.isAFG59 AS INT)) AS FG59," + Environment.NewLine +
                         "SUM(CAST(stats.isAFG60 AS INT)) AS FG60, SUM(CAST(stats.points0 AS INT)) AS points0, SUM(CAST(stats.points7 AS INT)) AS points7, SUM(CAST(stats.points20 AS INT)) AS points20, SUM(CAST(stats.points27 AS INT))" + Environment.NewLine +
                         "AS points27, SUM(CAST(stats.points34 AS INT)) AS points34, SUM(CAST(stats.points35 AS INT)) AS points35, stats.gameId, games.playoffRoundId, playerPositions.Id AS playerPositionId, players.teamId" + Environment.NewLine +
"FROM            stats INNER JOIN" + Environment.NewLine +
                         "games ON stats.gameId = games.Id INNER JOIN" + Environment.NewLine +
                         "players ON stats.playerId = players.Id INNER JOIN" + Environment.NewLine +
                         "playerPositions ON players.playerPositionId = playerPositions.Id" + Environment.NewLine +
"WHERE(stats.gameId = " + game_Id + ")" + Environment.NewLine +
"GROUP BY stats.playerId, playerPositions.Id, stats.statisticalCategoryid, stats.statisticCategoryQuantity, stats.gameId, games.playoffRoundId, players.firstName, players.lastName, players.teamId" + Environment.NewLine +
"ORDER BY stats.playerId";

            var listOfBoxScoreStats = _context.Database.SqlQuery<boxScoreStat>(sqlText).ToList();

            StatEntryViewModel viewModel = new StatEntryViewModel()
            {
                gamePlayers = listOfPlayers,
                statCategories = listOfStatCategories,
                gameId = gameId,
                game = currentgame,
                gamestats = listOfStats,
                boxScoreStats = listOfBoxScoreStats
            };

            return View("statEntry", viewModel);
        }

        // GET: Stats/editStat/2
        public ActionResult editStat(int statId)//bug with reload of edited stat. Does not reload with edited stat when you submit.
        {
            var stat = _context.stats.SingleOrDefault(m => m.Id == statId);

            var listOfStatCategories = _context.statisticalCategories.ToList();
            var game_Id = stat.gameId;
            var currentgame = _context.games.SingleOrDefault(m => m.Id == stat.gameId);
            var listOfStats = _context.stats.Where(m => m.gameId == game_Id).ToList();

            var sqlText = "SELECT        firstName + ' ' + lastName AS fullName, teamId, Id AS playerId" + Environment.NewLine +
"FROM            players" + Environment.NewLine +
"WHERE        (teamId = " + currentgame.homeTeamId + ") OR" + Environment.NewLine +
"                         (teamId = " + currentgame.awayTeamId + ")";

            var listOfPlayers = _context.Database.SqlQuery<playerinformation>(sqlText).ToList();

             sqlText = "SELECT        stats.playerId, players.firstName, players.lastName, SUM(CAST(stats.passCompletion AS INT)) AS Comp, SUM(CAST(stats.passAttempt AS INT)) AS Att, COALESCE(SUM(stats.passYards), 0) AS PassingYards," + Environment.NewLine +
             "SUM(CAST(stats.isAPassTouchdown AS INT)) AS PassTD, SUM(CAST(stats.rushAttempt AS INT)) AS Rush, COALESCE(SUM(stats.rushYards), 0) AS RushYards, SUM(CAST(stats.isARushTouchdown AS INT)) AS RushTD," + Environment.NewLine +
             "SUM(CAST(stats.target AS INT)) AS Target, SUM(CAST(stats.reception AS INT)) AS Rec, COALESCE(SUM(stats.recYards), 0) AS RecYards, SUM(CAST(stats.isARecTouchdown AS INT)) AS RecTD," + Environment.NewLine +
             "SUM(CAST(stats.isAtdbetween35_49 AS INT)) AS td3549, SUM(CAST(stats.isAtdOver50 AS INT)) AS td50, SUM(CAST(stats.isA2Point AS INT)) AS twoPt, SUM(CAST(stats.isAFumble AS INT)) AS Fum," + Environment.NewLine +
             "SUM(CAST(stats.isAinterception AS INT)) AS Int, SUM(CAST(stats.isASack AS INT)) AS Sack, SUM(CAST(stats.isADefensiveTD AS INT)) AS DefTD, SUM(CAST(stats.isAFumbleRecovery AS INT)) AS FumRec," + Environment.NewLine +
             "SUM(CAST(stats.isASafety AS INT)) AS Safety, SUM(CAST(stats.PAT AS INT)) AS PAT, SUM(CAST(stats.isAFG39 AS INT)) AS FG39, SUM(CAST(stats.isAFG49 AS INT)) AS FG49, SUM(CAST(stats.isAFG59 AS INT)) AS FG59," + Environment.NewLine +
             "SUM(CAST(stats.isAFG60 AS INT)) AS FG60, SUM(CAST(stats.points0 AS INT)) AS points0, SUM(CAST(stats.points7 AS INT)) AS points7, SUM(CAST(stats.points20 AS INT)) AS points20, SUM(CAST(stats.points27 AS INT))" + Environment.NewLine +
             "AS points27, SUM(CAST(stats.points34 AS INT)) AS points34, SUM(CAST(stats.points35 AS INT)) AS points35, stats.gameId, games.playoffRoundId, playerPositions.Id AS playerPositionId, players.teamId" + Environment.NewLine +
"FROM            stats INNER JOIN" + Environment.NewLine +
             "games ON stats.gameId = games.Id INNER JOIN" + Environment.NewLine +
             "players ON stats.playerId = players.Id INNER JOIN" + Environment.NewLine +
             "playerPositions ON players.playerPositionId = playerPositions.Id" + Environment.NewLine +
"WHERE(stats.gameId = " + game_Id + ")" + Environment.NewLine +
"GROUP BY stats.playerId, playerPositions.Id, stats.statisticalCategoryid, stats.statisticCategoryQuantity, stats.gameId, games.playoffRoundId, players.firstName, players.lastName, players.teamId" + Environment.NewLine +
"ORDER BY stats.playerId";

            var listOfBoxScoreStats = _context.Database.SqlQuery<boxScoreStat>(sqlText).ToList();


            var newModel = new StatEntryViewModel
            {
                gameStat = stat,
                gamePlayers = listOfPlayers,
                statCategories = listOfStatCategories,
                gameId = game_Id,
                game = currentgame,
                gamestats = listOfStats,
                boxScoreStats = listOfBoxScoreStats
            };

            return View("statEntry", newModel);
        }
        
        // GET: Stats/editStat/2
        public ActionResult deleteStat(int statId)
        {
            var gameStat = new stat();
            gameStat = _context.stats.SingleOrDefault(m => m.Id == statId);
            var gameId = gameStat.gameId;

            if (gameStat == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.stats.Remove(gameStat);
                _context.SaveChanges();
            }
            return RedirectToAction("AddStats","Stats", new { gameId = gameId});
        }
        public ActionResult selectPlayoffTeams()
        {
            var dateNowYear = DateTime.Now.Year;
            var contextDateNowYear = _context.calendarYears.SingleOrDefault(m => m.year == dateNowYear);

            var selectTeams = _context.homeTeams.ToList();
            var conferences = _context.conferences.ToList();
            var calendarYears = _context.calendarYears.ToList();
            var currentYearPlayoffTeams = _context.playoffTeams.Where(m => m.calendarYearId == contextDateNowYear.Id).ToList();

            CreateGameViewModel viewModel = new CreateGameViewModel()
            {
                teams = selectTeams,
                conferences = conferences,
                years = calendarYears,
                playoffTeams = currentYearPlayoffTeams
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult submitPlayoffTeams(CreateGameViewModel viewModel)
        {

            var playoffTeamSelection = new playoffTeam();
            playoffTeamSelection.homeTeamId = viewModel.playoffTeam.homeTeamId;
            playoffTeamSelection.playoffSeed = viewModel.playoffTeam.playoffSeed;
            playoffTeamSelection.calendarYearId = viewModel.playoffTeam.calendarYearId;
            playoffTeamSelection.conferenceId = viewModel.playoffTeam.conferenceId;

            _context.playoffTeams.Add(playoffTeamSelection);
            _context.SaveChanges();

            return RedirectToAction("selectPlayoffTeams", "Stats");
        }

        public ActionResult DeletetPlayoffTeam(int playoffTeamId)
        {
            try
            {
                var teamToDelete = new playoffTeam();
                teamToDelete = _context.playoffTeams.SingleOrDefault(m => m.Id == playoffTeamId);

                if (teamToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    _context.playoffTeams.Remove(teamToDelete);
                    _context.SaveChanges();
                }
                return RedirectToAction("selectPlayoffTeams", "Stats");
            }
            catch
            {
                return View();
            }            
        }

        public ActionResult AddPlayers(int playoffTeamId)
        {
            var currentTeamSelection = _context.playoffTeams.SingleOrDefault(m => m.Id == playoffTeamId);
            var playerPositions = _context.playerPositions.ToList();       
            var playoffTeamPlayers = _context.players.Where(m => m.playoffteamid == playoffTeamId).ToList();

            var viewmodel = new AddPlayerViewModel();
            {
                viewmodel.SelectedTeam = currentTeamSelection;
                viewmodel.playerPositions = playerPositions;
                viewmodel.playoffTeamPlayers = playoffTeamPlayers;
            }
            
            return View(viewmodel);
        }
        public ActionResult SubmitPlayer(AddPlayerViewModel viewModel)
        {
            int currentTeamId = viewModel.SelectedTeam.homeTeamId;

            var newPlayer = new player();
            {
                newPlayer.firstName = viewModel.newPlayer.firstName;
                newPlayer.lastName = viewModel.newPlayer.lastName;
                newPlayer.playerPositionid = viewModel.newPlayer.playerPositionid;
                newPlayer.teamid = viewModel.SelectedTeam.homeTeamId;
                newPlayer.calendarYearId = viewModel.SelectedTeam.calendarYearId;
                newPlayer.playoffteamid = viewModel.SelectedTeam.Id;
            }

            _context.players.Add(newPlayer);
            _context.SaveChanges();

            return RedirectToAction("addPlayers", "Stats", new { playoffTeamId = viewModel.SelectedTeam.Id });
        }
        public ActionResult DeletePlayer(int playerId, int playoffTeamId)
        {
            try
            {
                var playerToDelete = new player();
                playerToDelete = _context.players.SingleOrDefault(m => m.Id == playerId);

                if (playerToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    _context.players.Remove(playerToDelete);
                    _context.SaveChanges();
                }
                return RedirectToAction("AddPlayers", "Stats", new { playoffTeamId = playoffTeamId });
            }
            catch
            {
                return View();
            }  
        }
    }
}

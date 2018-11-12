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


        public ViewResult AddStats(int gameId)
        {
            //add viewmodel
            var listOfStatCategories = _context.statisticalCategories.ToList();
            var game_Id = gameId;
            var currentgame = _context.games.SingleOrDefault(m => m.Id == gameId);

            var sqlText = "SELECT        firstName + ' ' + lastName AS fullName, teamId, Id AS playerId" + Environment.NewLine +
"FROM            players" + Environment.NewLine +
"WHERE        (teamId = " + currentgame.homeTeamId + ") OR" + Environment.NewLine +
"                         (teamId = " + currentgame.awayTeamId + ")";

            var listOfPlayers = _context.Database.SqlQuery<playerinformation>(sqlText).ToList();

            var listOfStats = _context.stats.Where(m => m.gameId == game_Id).ToList();

            StatEntryViewModel viewModel = new StatEntryViewModel()
            {
                gamePlayers = listOfPlayers,
                statCategories = listOfStatCategories,
                gameId = gameId,
                game = currentgame,
                gamestats = listOfStats
            };

            return View("statEntry", viewModel);
        }

        // POST: Stats/Edit/id(of the game)
        [HttpPost]
        public ActionResult SaveStat(int id, StatEntryViewModel stat)
        {
            try
            {
                // TODO: Add update logic here
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

                    return RedirectToAction("EditStats");
                }
                else
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

                    var game_Id = revisedStat.gameId;

                    return RedirectToAction("AddStats", "Stats", new { gameId = game_Id });
                }

            }
            catch
            {
                return View();
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

        // GET: Stats/editStat/2
        public ActionResult editStat(int statId)
        {
            var stat = _context.stats.SingleOrDefault(m => m.Id == statId);

            var listOfStatCategories = _context.statisticalCategories.ToList();
            var game_Id = stat.gameId;
            var currentgame = _context.games.SingleOrDefault(m => m.Id == stat.gameId);

            var sqlText = "SELECT        firstName + ' ' + lastName AS fullName, teamId, Id AS playerId" + Environment.NewLine +
"FROM            players" + Environment.NewLine +
"WHERE        (teamId = " + currentgame.homeTeamId + ") OR" + Environment.NewLine +
"                         (teamId = " + currentgame.awayTeamId + ")";

            var listOfPlayers = _context.Database.SqlQuery<playerinformation>(sqlText).ToList();

            var listOfStats = _context.stats.Where(m => m.gameId == game_Id).ToList();

            var newModel = new StatEntryViewModel
            {
                gameStat = stat,
                gamePlayers = listOfPlayers,
                statCategories = listOfStatCategories,
                gameId = game_Id,
                game = currentgame,
                gamestats = listOfStats
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
            var selectTeams = _context.homeTeams.ToList();
            var conferences = _context.conferences.ToList();

            CreateGameViewModel viewModel = new CreateGameViewModel()
            {
                teams = selectTeams,
                conferences = conferences
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult submitPlayoffTeams(CreateGameViewModel viewModel)
        {

            var playoffTeamSelection = new playoffTeam();
            playoffTeamSelection.homeTeamId = viewModel.playoffTeam.homeTeamId;
            playoffTeamSelection.playoffSeed = viewModel.playoffTeam.playoffSeed;
            playoffTeamSelection.year = viewModel.playoffTeam.year;
            playoffTeamSelection.conferenceId = viewModel.playoffTeam.conferenceId;

            _context.playoffTeams.Add(playoffTeamSelection);
            _context.SaveChanges();

            return RedirectToAction("createGames", "Stats");
        }
    }
}

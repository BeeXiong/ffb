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

    public class LeaguesController : Controller
    {

        private FantasyDbContext _context;

        public LeaguesController()
        {
            _context = new FantasyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: League
        public ActionResult Index()
        {
            return View();
        }

        // GET: League/CreateLeague
        [Authorize(Roles = "User, Admin")]
        public ViewResult createLeagues()
        {
            string currentUserId = User.Identity.GetUserId();
            var currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);

            var userLeagues = _context.fantasy_Leagues.Where(m => m.userId == currentUserId).ToList();

            var viewModel = new CreateLeagueViewModel
            {
                commish = currentUser,
                commishLeagues = userLeagues
            };

            return View(viewModel);
        }

        // POST: League/createLeagues
        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public ActionResult saveLeagues(CreateLeagueViewModel submit)
        {
            try
            {
                var newleague = new fantasy_League();
                newleague.leagueName = submit.fantasy_League.leagueName;
                newleague.leaguePassword = submit.fantasy_League.leaguePassword;
                newleague.entryCode = submit.fantasy_League.entryCode;
                newleague.userId = submit.commish.Id;

                _context.fantasy_Leagues.Add(newleague);
                _context.SaveChanges();

                return RedirectToAction("createLeagues", "Leagues");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "User, Admin")]
        public ActionResult deleteLeague(int id)
        {
            try
            {
                var leagueToDelete = _context.fantasy_Leagues.SingleOrDefault(m => m.Id == id);

                if (leagueToDelete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    _context.fantasy_Leagues.Remove(leagueToDelete);
                    _context.SaveChanges();
                }

                return RedirectToAction("createLeagues","Leagues");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public ViewResult createTeams()
        {
            string currentUserId = User.Identity.GetUserId();
            var currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);
            var allLeagues = _context.fantasy_Leagues.ToList();
            var currentUserTeams = _context.fantasy_League_Details.Where(m => m.userId == currentUserId).ToList();
            var viewModel = new CreateTeamsViewModel
            {
                fantasyPlayer = currentUser,
                fantasy_Leagues = allLeagues,
                userTeams = currentUserTeams
            };

            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public ActionResult saveTeams(CreateTeamsViewModel submit)
        {
            var dateNowYear = DateTime.Now.Year;
            var contextDateNowYear = _context.calendarYears.SingleOrDefault(m => m.year == dateNowYear);

            try
            {
                var fantasy_league = _context.fantasy_Leagues.SingleOrDefault(m => m.Id == submit.fantasy_League_Detail.fantasy_LeagueId);

                if (fantasy_league.entryCode == submit.fantasy_League_Detail.fantasy_League.entryCode && fantasy_league.amountOfTeams < 6)
                {
                    fantasy_league.amountOfTeams++;
                    _context.SaveChanges();

                    var newTeam = new fantasy_Team();
                    newTeam.teamName = submit.fantasy_League_Detail.fantasy_Team.teamName;
                    newTeam.nickName = submit.fantasy_League_Detail.fantasy_Team.nickName;

                    _context.fantasy_Teams.Add(newTeam);
                    _context.SaveChanges();

                    var newTeamId = newTeam.Id;

                    var newleague = new fantasy_League_Detail();
                    newleague.fantasy_LeagueId = submit.fantasy_League_Detail.fantasy_LeagueId;
                    newleague.fantasy_TeamId = newTeamId;
                    newleague.userId = submit.fantasyPlayer.Id;
                    newleague.currentYearId = contextDateNowYear.Id;

                    _context.fantasy_League_Details.Add(newleague);
                    _context.SaveChanges();

                }
                else
                {
                    submit.fantasy_League_Error = fantasy_league;
                    TempData["submit"] = submit;
                    return RedirectToAction("createTeamsError", "Leagues");
                }


                return RedirectToAction("createTeams", "Leagues");
            }
            catch
            {
                return View();
            }
        }
        public ViewResult createTeamsError()
        {
            CreateTeamsViewModel submit = (CreateTeamsViewModel)TempData["submit"];
            return View(submit);
        }
        public ViewResult manageLeague(int id)
        {
            var currentLeagueDetails = _context.fantasy_League_Details.Where(m => m.fantasy_LeagueId == id).ToList();
            
            var leagueDetails = new CreateLeagueViewModel
            {
                leagueDetails = currentLeagueDetails
            };

            return View(leagueDetails);
        }
        public ActionResult deleteTeam(int id)
        {
            var selectedTeam = _context.fantasy_Teams.SingleOrDefault(m => m.Id == id);
            var selectedLeague = _context.fantasy_League_Details.SingleOrDefault(m => m.fantasy_TeamId == id);
            var leagueid = selectedLeague.fantasy_LeagueId;

            if (selectedTeam == null)
            {
                return HttpNotFound();
            }
            else
            {
                _context.fantasy_Teams.Remove(selectedTeam);
                _context.SaveChanges();
                var currentLeague = _context.fantasy_Leagues.SingleOrDefault(m => m.Id == leagueid);
                currentLeague.amountOfTeams--;
                _context.SaveChanges();
            }

            return RedirectToAction("manageLeague", "Leagues", new { id = leagueid });
        }
    }

}

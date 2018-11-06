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
    public class fantasyTeamController : Controller
    {
        private FantasyDbContext _context;

        public fantasyTeamController()
        {
            _context = new FantasyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Authorize(Roles ="Admin, Users")]
        public ViewResult viewTeam(int Id)
        {
            var currentTeam = _context.fantasy_Teams.Single(m => m.Id == Id);
            var teamRosterId = currentTeam.Id;


            return View();
        }



    }
}

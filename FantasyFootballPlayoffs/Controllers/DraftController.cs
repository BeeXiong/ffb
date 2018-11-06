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
    public class DraftController : Controller
    {
        private FantasyDbContext _context;

        public DraftController()
        {
            _context = new FantasyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult players(int detailsId)
        {
            var players = new List<player>();
            string currentUserId = User.Identity.GetUserId();
            var playoffTeams = _context.playoffTeams.ToList();
            var playoffPlayers = new List<player>();
            var currentleagueAndTeam = _context.fantasy_League_Details.SingleOrDefault(m => m.Id == detailsId);
            var draftedPlayers = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.fantasy_LeagueId == currentleagueAndTeam.fantasy_LeagueId).ToList();
            var currentDraftedTeam = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.Id == detailsId).Where(m => m.fantasy_League_Detail.userId == currentUserId).OrderByDescending(m => m.fantasy_Player_SlotId).ToList();
            var lastPick = new fantasy_Roster();

            try
            {
                lastPick = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.fantasy_LeagueId == currentleagueAndTeam.fantasy_LeagueId).OrderByDescending(m => m.draftPickNumber).First();
            }
            catch
            {
                lastPick = null;
            }

            foreach (playoffTeam team in playoffTeams)
            {
                players = _context.players.Where(m => m.teamid == team.homeTeamId).ToList();
                foreach (player player in players)
                {
                    playoffPlayers.Add(player);
                }
            }

            var viewModel = new playerDraftViewModel
            {
                players = playoffPlayers,
                playoffteams = playoffTeams,
                fantasyDetail = currentleagueAndTeam,
                draftedPlayers = draftedPlayers,
                currentTeam = currentDraftedTeam,
                lastPick = lastPick
            };

            return View(viewModel);
        }
        public ActionResult draftPlayer(int Id, int detailId, int draftId)
        {
            var currentleagueAndTeam = _context.fantasy_League_Details.SingleOrDefault(m => m.Id == detailId);
            var lastPick = new fantasy_Roster();
            try
            {
                lastPick = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.fantasy_LeagueId == currentleagueAndTeam.fantasy_LeagueId).OrderByDescending(m => m.draftPickNumber).First();
            }
            catch
            {
                lastPick = null;
            }

            int currentPick;

            if (lastPick == null)
            {
                currentPick = 1;
            }
            else
            {
                currentPick = lastPick.draftPickNumber + 1;
            }

            string currentUserId = User.Identity.GetUserId();
            var rosterDetailExist = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.userId == currentUserId && m.fantasy_League_Detail.Id == detailId).ToList();
            var playerToDraft = _context.players.SingleOrDefault(m => m.Id == Id);

            var slotId = 0;
            var slotPosition = -1;
            if (rosterDetailExist.Count != 0)
            {
                foreach (fantasy_Roster detail in rosterDetailExist)
                {
                    if (detail.player.playerPositionid == playerToDraft.playerPositionid)
                    {
                        slotId++; // need to deal with limits
                    }   
                }

                if (playerToDraft.playerPositionid == 1)//Qb
                {
                    if (slotId == 0)
                    {
                        slotPosition = 1;
                    }
                    else if (slotId == 1)
                    {
                        slotPosition = 2;
                    }
                }
                if (playerToDraft.playerPositionid == 2)//rb
                {
                    if (slotId == 0)
                    {
                        slotPosition = 3;
                    }
                    else if (slotId == 1)
                    {
                        slotPosition = 4;
                    }
                }
                if (playerToDraft.playerPositionid == 3)//wr
                {
                    if (slotId == 0)
                    {
                        slotPosition = 5;
                    }
                    else if (slotId == 1)
                    {
                        slotPosition = 6;
                    }
                    else if (slotId == 2)
                    {
                        slotPosition = 7;
                    }
                    else if (slotId == 3)
                    {
                        slotPosition = 8;
                    }
                }
                if (playerToDraft.playerPositionid == 4)//te
                {
                    if (slotId == 0)
                    {
                        slotPosition = 9;
                    }
                    else if (slotId == 1)
                    {
                        slotPosition = 10;
                    }
                }
                if (playerToDraft.playerPositionid == 5)//def
                {
                    if (slotId == 0)
                    {
                        slotPosition = 11;
                    }
                    else if (slotId == 1)
                    {
                        slotPosition = 12;
                    }
                }
                if (playerToDraft.playerPositionid == 19)//k
                {
                    if (slotId == 0)
                    {
                        slotPosition = 13;
                    }
                    else if (slotId == 1)
                    {
                        slotPosition = 14;
                    }
                }
            }
            else
            {
                if (playerToDraft.playerPositionid == 1)//Qb
                {
                    if (slotId == 0)
                    {
                        slotPosition = 1;
                    }
                    //else if (slotId == 1)
                    //{
                    //    slotPosition = 2;
                    //}
                }
                if (playerToDraft.playerPositionid == 2)//rb
                {
                    if (slotId == 0)
                    {
                        slotPosition = 3;
                    }
                    //else if (slotId == 1)
                    //{
                    //    slotPosition = 4;
                    //}
                }
                if (playerToDraft.playerPositionid == 3)//wr
                {
                    if (slotId == 0)
                    {
                        slotPosition = 5;
                    }
                    //else if (slotId == 1)
                    //{
                    //    slotPosition = 6;
                    //}
                    //else if (slotId == 2)
                    //{
                    //    slotPosition = 7;
                    //}
                    //else if (slotId == 3)
                    //{
                    //    slotPosition = 8;
                    //}
                }
                if (playerToDraft.playerPositionid == 4)//te
                {
                    if (slotId == 0)
                    {
                        slotPosition = 9;
                    }
                    //else if (slotId == 1)
                    //{
                    //    slotPosition = 10;
                    //}
                }
                if (playerToDraft.playerPositionid == 5)//Def
                {
                    if (slotId == 0)
                    {
                        slotPosition = 11;
                    }
                    //else if (slotId == 1)
                    //{
                    //    slotPosition = 12;
                    //}
                }
                if (playerToDraft.playerPositionid == 19)//K
                {
                    if (slotId == 0)
                    {
                        slotPosition = 13;
                    }
                    //else if (slotId == 1)
                    //{
                    //    slotPosition = 14;
                    //}
                }
            }

            var draftedPlayer = new fantasy_Roster();
            draftedPlayer.fantasy_League_DetailId = detailId;
            draftedPlayer.playerId = Id;
            draftedPlayer.sportId = 1;
            draftedPlayer.draftPickNumber = currentPick;
            draftedPlayer.fantasy_Player_SlotId = slotPosition;
            draftedPlayer.Id = draftId;

            _context.fantasy_Rosters.Add(draftedPlayer);
            _context.SaveChanges();

            //var lastDraftSubmit = _context.fantasy_Rosters.First();
            //var playerPositionId = lastDraftSubmit.player.playerPositionid;

            return RedirectToAction("players","Draft", new { detailsId = detailId });
        }
    }
}

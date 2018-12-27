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
        [Authorize(Roles = "User, Admin")]
        public ViewResult Players(int detailsId)
        {
            var players = new List<player>();
            var playoffPlayers = new List<player>();
            var currentFantasyDetail = _context.fantasy_League_Details.SingleOrDefault(m => m.Id == detailsId);
            string currentUserId = User.Identity.GetUserId();
            var playoffTeams = _context.playoffTeams.Where(m => m.calendarYearId == currentFantasyDetail.calendarYearId).ToList();
            playoffPlayers = _context.players.Where(m => m.calendarYearId == currentFantasyDetail.calendarYearId).ToList();
            var draftedPlayers = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.fantasy_LeagueId == currentFantasyDetail.fantasy_LeagueId).ToList();
            var currentDraftedTeam = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.Id == detailsId).Where(m => m.fantasy_League_Detail.userId == currentUserId).OrderByDescending(m => m.fantasy_Player_SlotId).ToList();
            var lastPick = new fantasy_Roster();

            try
            {
                lastPick = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.fantasy_LeagueId == currentFantasyDetail.fantasy_LeagueId).OrderByDescending(m => m.draftPickNumber).First();
            }
            catch
            {
                lastPick = null;
            }

            //draft order

            List<draftOrder> leagueDraftOrder = new List<draftOrder>();

            for (int i = 1; i <= 6; i++)
            {
                draftOrder draftPosition = new draftOrder();
                draftPosition.pickPosition = i;
                leagueDraftOrder.Add(draftPosition);
            }

            List<draftOrder> ascendingOrder = leagueDraftOrder.OrderBy(m => m.pickPosition).ToList();
            List<draftOrder> desendingOrder = leagueDraftOrder.OrderByDescending(m => m.pickPosition).ToList();

            List<draftOrder> completeOrder = new List<draftOrder>();

            do
            {
                completeOrder = addPickDetailAscending(ascendingOrder, completeOrder);
                completeOrder = addPickDetailDescending(desendingOrder, completeOrder);
            }
            while (completeOrder.Count <= 83);
            if(lastPick != null)
            {
                for (int i = 1; i <= lastPick.draftPickNumber; i++)
                {
                    completeOrder.RemoveAt(0);
                }
            }

            //draft order
            var viewModel = new PlayerDraftViewModel
            {
                players = playoffPlayers,
                playoffteams = playoffTeams,
                fantasyDetail = currentFantasyDetail,
                draftedPlayers = draftedPlayers,
                currentTeam = currentDraftedTeam,
                lastPick = lastPick,
                leagueDraftOrder = completeOrder
            };

            return View(viewModel);
        }

        //draft order
        public List<draftOrder> addPickDetailAscending(List<draftOrder> ascendingOrder, List<draftOrder> completeOrder)
        {
            for (int i = 0; i < ascendingOrder.Count; i++)
            {
                completeOrder.Add(ascendingOrder[i]);
            }
            return completeOrder;
        }
        public List<draftOrder> addPickDetailDescending(List<draftOrder> descendingOrder, List<draftOrder> completeOrder)
        {
            for (int i = 0; i < descendingOrder.Count; i++)
            {
                completeOrder.Add(descendingOrder[i]);
            }
            return completeOrder;
        }
        //draft order
        public int DraftPlayer(int Id, int detailId, string currentUserId)
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

            var rosterDetailExist = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.userId == currentUserId && m.fantasy_League_Detail.Id == detailId).ToList();
            var playerToDraft = _context.players.SingleOrDefault(m => m.Id == Id);

            int slotId = 0;
            int slotPosition = -1;
            if (rosterDetailExist.Count != 0)
            {
                foreach (fantasy_Roster detail in rosterDetailExist)//checks the detail and looks to see if you have players at that position
                {
                    if (detail.player.playerPositionid == playerToDraft.playerPositionid)
                    {
                        slotId++; //increase the value of the slotId if you already have a player at that position
                    }   
                }

                if (playerToDraft.playerPositionid == 1)//checks to see if player is QB
                {
                    if (slotId == 0)//compares slotId and if it's equal it will assign the player a QB Slot. If theres too many, it won't do anything
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
            else //if there are no draft picks and it's the first one, the else will occur. Checks the position and will add only to the first slot
            {
                if (playerToDraft.playerPositionid == 1)//Qb
                {
                    if (slotId == 0)
                    {
                        slotPosition = 1;
                    }
                }
                if (playerToDraft.playerPositionid == 2)//rb
                {
                    if (slotId == 0)
                    {
                        slotPosition = 3;
                    }
                }
                if (playerToDraft.playerPositionid == 3)//wr
                {
                    if (slotId == 0)
                    {
                        slotPosition = 5;
                    }
                }
                if (playerToDraft.playerPositionid == 4)//te
                {
                    if (slotId == 0)
                    {
                        slotPosition = 9;
                    }
                }
                if (playerToDraft.playerPositionid == 5)//Def
                {
                    if (slotId == 0)
                    {
                        slotPosition = 11;
                    }
                }
                if (playerToDraft.playerPositionid == 19)//K
                {
                    if (slotId == 0)
                    {
                        slotPosition = 13;
                    }
                }
            }

            var draftedPlayer = new fantasy_Roster();
            draftedPlayer.fantasy_League_DetailId = detailId;
            draftedPlayer.playerId = Id;
            draftedPlayer.sportId = 1;
            draftedPlayer.draftPickNumber = currentPick;
            draftedPlayer.fantasy_Player_SlotId = slotPosition;

            if(slotPosition != -1)//if slotPosition gets assigned a new player will be added
            {
                _context.fantasy_Rosters.Add(draftedPlayer);
                _context.SaveChanges();
            }
            //return RedirectToAction("players","Draft", new { detailsId = detailId });

            //return slotPosition; if slot position == something other than -1 I know the function completed and i can update a hidden field 
            //If it equals -1 I can send a message saying the pick was not completed.
            return slotPosition;
        }

        public ViewResult Overview(int leagueId)
        {
            var drafted_players = _context.fantasy_Rosters.Where(m => m.fantasy_League_Detail.fantasy_LeagueId == leagueId).OrderBy(m => m.draftPickNumber).ToList();
            var leagueDetailTeams = _context.fantasy_League_Details.Where(m => m.fantasy_LeagueId == leagueId).ToList();

            PlayerDraftViewModel viewModel = new PlayerDraftViewModel
            {
                draftedPlayers = drafted_players,
                fantasyDetailsTeams = leagueDetailTeams,
            };
            return View("overview", viewModel);

        }

    }
}

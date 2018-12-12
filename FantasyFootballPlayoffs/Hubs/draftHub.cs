using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using FantasyFootballPlayoffs.Controllers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FantasyFootballPlayoffs.Hubs
{
    [HubName("draftHub")]
    public class DraftHub : Hub
    {
        public async Task AddUserToChatRoom(string roomName)
        {
            await Groups.Add(Context.ConnectionId, roomName);
            Clients.Group(roomName).addNewMessageToPage("Draft HQ:   " + Context.User.Identity.Name + " has joined the Draft.");
        }

        public void Send(string name, string message, string roomName)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.Group(roomName).addNewMessageToPage(name, message);  
        }

        public void ReceiveSelection(int playerId, int detailsId, string btnId, string lastPickName, string lastPickTeam, string lastPickPosition, int lastPickNumber, List<string[]> currentTeam)
        {
            DraftController controller = new DraftController();

            string currentUserId = GetUserId();
            //controller calls draft function which returns player position or -1. 
            //That return value used to determine if the page gets updated.
            int slotPosition = controller.DraftPlayer(playerId, detailsId, currentUserId);

            if(slotPosition == -1)
            {
                string name;
                string message;

                name = "Draft HQ";
                message = "Incorrect Select Made. No Player Was Selected";
                Clients.All.addNewMessageToPage(name, message);
            }
            else
            {
                GetLastPickInfo(lastPickName, lastPickTeam, lastPickPosition, lastPickNumber);
                GetUserTeamInfo(currentTeam, slotPosition, lastPickName, lastPickTeam, lastPickNumber);

                // Call the method to deactive player who was selected
                Clients.All.deactivateSelectedPlayerBtn(btnId);
            }
        }

        private void GetLastPickInfo(string lastPickName, string lastPickTeam, string lastPickPosition, int lastPickNumber)
        {
            string userName = GetUserName();
            Clients.All.updateLastPick(lastPickName, lastPickTeam, lastPickPosition, lastPickNumber, userName);
        }

        private void GetUserTeamInfo(List<string[]> currentTeam, int slotPosition, string lastPickName, string lastPickTeam, int lastPickNumber)
        {
            //array position 0 = slot position 1 QB1
            //array position 1 = slot position 2 qb2
            //array position 2 = slot position 3 rb1
            //array position 3 = slot position 4 rb2
            //array position 4 = slot position 5 wr1
            //array position 5 = slot position 6 wr2
            //array position 6 = slot position 7 wr3
            //array position 7 = slot position 8 wr4
            //array position 8 = slot position 9 te1
            //array position 9 = slot position 10 te2
            //array position 10 = slot position 11 d1
            //array position 11 = slot position 12 d2
            //array position 12 = slot position 13 k1
            //array position 13 = slot position 14 k2

            string lastPickSlot = "";

            if(slotPosition == 1)
            {
                lastPickSlot = "QB1";
            }
            else if (slotPosition == 2)
            {
                lastPickSlot = "QB2";
            }
            else if (slotPosition == 3)
            {
                lastPickSlot = "RB1";
            }
            else if (slotPosition == 4)
            {
                lastPickSlot = "RB2";
            }
            else if (slotPosition == 5)
            {
                lastPickSlot = "WR1";
            }
            else if (slotPosition == 6)
            {
                lastPickSlot = "WR2";
            }
            else if (slotPosition == 7)
            {
                lastPickSlot = "WR3";
            }
            else if (slotPosition == 8)
            {
                lastPickSlot = "WR4";
            }
            else if (slotPosition == 9)
            {
                lastPickSlot = "TE1";
            }
            else if (slotPosition == 10)
            {
                lastPickSlot = "TE2";
            }
            else if (slotPosition == 11)
            {
                lastPickSlot = "D1";
            }
            else if (slotPosition == 12)
            {
                lastPickSlot = "D2";
            }
            else if (slotPosition == 13)
            {
                lastPickSlot = "K1";
            }
            else if (slotPosition == 14)
            {
                lastPickSlot = "K2";
            }

            string[] draftPickInfo = new string[]
            {
                lastPickSlot, lastPickName, lastPickTeam, lastPickNumber.ToString()
            };

            int playerLocationInArray = slotPosition - 1;
            currentTeam[playerLocationInArray] = draftPickInfo;

            Clients.All.updateTeamTable(currentTeam);
        }
        private string GetUserId()
        {
            string userId;
            userId = "";
            //Get the UserId
            var claimsIdentity = Context.User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                // the principal identity is a claims identity.
                // now we need to find the NameIdentifier claim
                var userIdClaim = claimsIdentity.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                if (userIdClaim != null)
                {
                    userId = userIdClaim.Value;
                }
            }
            return userId;
        }

        private string GetUserName()
        {
            //Get the username
            string name = Context.User.Identity.Name;
            return name;
        }


    }
}
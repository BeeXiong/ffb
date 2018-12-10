using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using FantasyFootballPlayoffs.Controllers;
using System.Security.Claims;

namespace FantasyFootballPlayoffs.Hubs
{
    [HubName("draftHub")]
    public class DraftHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public void ReceiveSelection(int playerId, int detailsId, string btnId)
        {
            DraftController controller = new DraftController();

            string currentUserId = GetUserId();

            controller.DraftPlayer(playerId, detailsId, currentUserId);

            // Call the method to deactive player who was selected
            Clients.All.deactivateSelectedPlayerBtn(btnId);
        }

        public void GetLastPickInfo(string lastPickName, string lastPickTeam, string lastPickPosition, int lastPickNumber)
        {
            string userName = GetUserName();
            Clients.All.updateLastPick(lastPickName, lastPickTeam, lastPickPosition, lastPickNumber, userName);
        }

        public void GetUserTeamInfo(List<string[]> currentTeam)
        {
            //add logic to update list and call back function from client
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
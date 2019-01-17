using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using FantasyFootballPlayoffs.Hubs;
using System.Threading.Tasks;

namespace FantasyFootballPlayoffs.Models
{
    public class draftTicker
    {
        private readonly static Lazy<draftTicker> _instance = new Lazy<draftTicker>(() => new draftTicker(GlobalHost.ConnectionManager.GetHubContext<DraftHub>()));

        private draftTicker(IHubContext draftHubContext)
        {
            DraftHubContext = draftHubContext;
        }

        public static draftTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private IHubContext DraftHubContext;

        public async Task AddUserToGroup(string connectionId, string roomName, string userName)
        {
            await DraftHubContext.Groups.Add(connectionId, roomName);
            DraftHubContext.Clients.Group(roomName).addNewMessageToPage("Draft HQ:   " + userName + " has joined the Draft.");
        }

        public void Send(string name, string message, string roomName)
        {
            // Call the addNewMessageToPage method to update clients.
            DraftHubContext.Clients.Group(roomName).addNewMessageToPage(name, message);
        }

    }
}
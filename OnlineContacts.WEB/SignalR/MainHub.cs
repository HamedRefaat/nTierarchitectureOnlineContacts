using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace OnlineContacts.WEB.SignalR
{
    [HubName("mainHub")]
    public class MainHub : Hub
    {
        public void LockContact(int ConnectId)
        {
            
            var id = Context.ConnectionId;

            Clients.AllExcept(id).fireLockContact(ConnectId);
        }
    }
}
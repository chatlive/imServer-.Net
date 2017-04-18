using Microsoft.AspNet.SignalR;
using SignalR_Hubs.IServerCalls;
using SignalR_MapUsers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Hubs
{
    /// <summary>
    /// ImHub
    /// </summary>
    public partial class ImHub : IServerCalls_ClientManage
    {
        public void Hello(string who, string message)
        {
            var name = LOGIN_ACCOUNT;
            //using (var db = new SignalR_MapUsersModel())
            //{
            //    var user = db.Users.Find(who);
            //    if (user == null)
            //    {
            //        Clients.Caller.showErrorMessage("Could not find that user.");
            //    }
            //    else
            //    {
            //        db.Entry(user)
            //            .Collection(u => u.Connections)
            //            .Query()
            //            .Where(c => c.Connected == true)
            //            .Load();

            //        if (user.Connections == null)
            //        {
            //            Clients.Caller.showErrorMessage("The user is no longer connected.");
            //        }
            //        else
            //        {
            //            foreach (var connection in user.Connections)
            //            {
            //                Clients.Client(connection.ConnectionID)
            //                    .broadcastMessage(name, message);
            //            }
            //        }
            //    }
            //}
            Clients.All.broadcastMessage(name, message);
            //return null;
        }

        public Task StopClient()
        {
            Clients.All.StopClient();
            return null;
        }
    }
}

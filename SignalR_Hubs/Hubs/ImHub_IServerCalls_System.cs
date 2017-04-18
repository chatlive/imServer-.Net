using Microsoft.AspNet.SignalR;
using SignalR_Hubs.IServerCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Hubs
{
    public partial class ImHub : IServerCalls_System
    {
        public Task Sys_GroupCreateByMaster()
        {
            throw new NotImplementedException();
        }

        public Task Sys_GroupDeleteByMaster()
        {
            throw new NotImplementedException();
        }

        public Task Sys_GroupExitByUser()
        {
            throw new NotImplementedException();
        }

        public Task Sys_GroupJoinByUser()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IClientCallbacks
{

    /// <summary>
    /// 客户端方法（回调）
    /// </summary>
    public interface IClientCallbacks :
        IClientCallbacks_ClientManage
        , IClientCallbacks_Chatter
        , IClientCallbacks_FriendGroup
        , IClientCallbacks_Group
        , IClientCallbacks_GroupManage
        , IClientCallbacks_History
        , IClientCallbacks_Single
        , IClientCallbacks_System
    {
    }
}

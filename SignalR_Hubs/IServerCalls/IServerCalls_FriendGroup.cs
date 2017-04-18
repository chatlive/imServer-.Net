using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IServerCalls
{

    /// <summary>
    /// 好友/群组信息(FriendGroup 简写FG_)
    /// </summary>
    public interface IServerCalls_FriendGroup
    {
        /// <summary>
        /// 获取-好友
        /// </summary>
        /// <returns></returns>
        object FG_GetFriends();
        /// <summary>
        /// 获取-群组
        /// </summary>
        /// <returns></returns>
        object FG_GetGroups();
        /// <summary>
        /// 获取-联系人
        /// </summary>
        /// <returns></returns>
        Task<object> FG_GetContacts();
    }

}

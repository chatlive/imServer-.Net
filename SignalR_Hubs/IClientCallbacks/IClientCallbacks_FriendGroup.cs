using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IClientCallbacks
{

    /// <summary>
    /// 好友/群组信息(FriendGroup 简写FG_)
    /// </summary>
    public interface IClientCallbacks_FriendGroup
    {
        /// <summary>
        /// 获取-好友
        /// </summary>
        /// <returns></returns>
        Task FG_GetFriends();
        /// <summary>
        /// 获取-群组
        /// </summary>
        /// <returns></returns>
        Task FG_GetGroups();
        /// <summary>
        /// 获取-联系人
        /// </summary>
        /// <returns></returns>
        Task FG_GetContacts();
    }

}

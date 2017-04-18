using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IClientCallbacks
{

    /// <summary>
    /// 群组管理(GroupManage 简写GM_)
    /// </summary>
    public interface IClientCallbacks_GroupManage
    {
        /// <summary>
        /// 创建群
        /// </summary>
        Task GM_Create();
        /// <summary>
        /// 解散群
        /// </summary>
        Task GM_Delete();
        /// <summary>
        /// 退出群
        /// </summary>
        Task GM_Exit();
        /// <summary>
        /// 群主-加人
        /// </summary>
        Task GM_AddUsers(object groupInfo);
        /// <summary>
        /// 群主-减人
        /// </summary>
        Task GM_RemoveUsers(object groupInfo);
        /// <summary>
        /// 获取自己加入的和创建的群组列表
        /// </summary>
        Task GM_GetGroups();
        /// <summary>
        /// 获取群组详情
        /// </summary>
        Task GM_GroupInfo();

    }

}

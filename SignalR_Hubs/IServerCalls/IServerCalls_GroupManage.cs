using SignalR_Hubs.Models.InputOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IServerCalls
{

    /// <summary>
    /// 群组管理(GroupManage 简写GM_)
    /// </summary>
    public interface IServerCalls_GroupManage
    {
        /// <summary>
        /// 群主-创建群
        /// </summary>
        object GM_Create(IGM_Create model);
        /// <summary>
        /// 群主-解散群
        /// </summary>
        Task GM_Delete();
        /// <summary>
        /// 组员-退出群
        /// </summary>
        Task GM_Exit();
        /// <summary>
        /// 群主-加人
        /// </summary>
        object GM_AddUsers(IGM_AddUsers model);
        /// <summary>
        /// 群主-减人
        /// </summary>
        object GM_RemoveUsers(IGM_RemoveUsers model);
        /// <summary>
        /// 获取自己加入的和创建的群组列表
        /// </summary>
        Task GM_GetGroups();
        /// <summary>
        /// 获取群组详情
        /// </summary>
        object GM_GroupInfo(IGM_GroupInfo model);

    }

}

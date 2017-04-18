using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IServerCalls
{

    /// <summary>
    /// 系统消息
    /// </summary>
    public interface IServerCalls_System
    {
        /// <summary>
        /// 入群通知(用户)
        /// </summary>
        /// <returns></returns>
        Task Sys_GroupJoinByUser();
        /// <summary>
        /// 退群通知(用户)
        /// 用户退群/群主删除成员
        /// </summary>
        /// <returns></returns>
        Task Sys_GroupExitByUser();
        /// <summary>
        /// 建群通知（群主）
        /// </summary>
        /// <returns></returns>
        Task Sys_GroupCreateByMaster();
        /// <summary>
        /// 解散群通知（群主）
        /// </summary>
        /// <returns></returns>
        Task Sys_GroupDeleteByMaster();
    }

}

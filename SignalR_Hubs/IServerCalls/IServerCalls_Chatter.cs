using SignalR_Hubs.Models.InputOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IServerCalls
{

    /// <summary>
    /// 会话
    /// </summary>
    public interface IServerCalls_Chatter
    {
        /// <summary>
        /// 会话-重置未读消息数
        /// </summary>
        /// <returns></returns>
        object Chatter_ResetUnreadMsg(IChatter_ResetUnreadMsg model);

        /// <summary>
        /// 获取-会话信息
        /// </summary>
        /// <returns></returns>
        object Chatter_ChatterInfo();
    }

}

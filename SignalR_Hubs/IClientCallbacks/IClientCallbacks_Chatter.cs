using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IClientCallbacks
{

    /// <summary>
    /// 会话
    /// </summary>
    public interface IClientCallbacks_Chatter
    {
        /// <summary>
        /// 会话-重置未读消息数
        /// </summary>
        /// <returns></returns>
        Task Chatter_ResetUnreadMsg();

        /// <summary>
        /// 获取-会话信息
        /// </summary>
        /// <returns></returns>
        Task Chatter_ChatterInfo();
    }

}

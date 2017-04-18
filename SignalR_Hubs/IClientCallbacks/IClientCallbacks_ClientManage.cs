using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IClientCallbacks
{
    /// <summary>
    /// 客户端管理
    /// </summary>
    public interface IClientCallbacks_ClientManage
    {
        void broadcastMessage(string name, string message);
        Task addChatMessage(string test);

        /// <summary>
        /// 展示错误消息
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        Task showErrorMessage(string error);
        /// <summary>
        /// 停止客户端连接
        /// </summary>
        Task StopClient();
        /// <summary>
        /// 你好
        /// </summary>
        Task Hello();
    }
}

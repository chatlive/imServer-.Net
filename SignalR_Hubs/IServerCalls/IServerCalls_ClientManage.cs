using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IServerCalls
{

    /// <summary>
    /// 客户端管理
    /// </summary>
    public interface IServerCalls_ClientManage
    {

        /// <summary>
        /// 停止客户端连接
        /// </summary>
        Task StopClient();
        /// <summary>
        /// 你好
        /// </summary>
        void Hello(string who, string message);

    }
}

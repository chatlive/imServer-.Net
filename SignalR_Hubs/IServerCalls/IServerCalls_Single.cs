using SignalR_Hubs.Models.InputOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IServerCalls
{

    /// <summary>
    /// 单聊
    /// </summary>
    public interface IServerCalls_Single
    {

        /// <summary>
        /// 发送-文本/表情消息
        /// </summary>
        /// <returns></returns>
        object Single_SendText(ISingle_SendText model);
        /// <summary>
        /// 发送-文件消息
        /// </summary>
        /// <returns></returns>
        object Single_SendFile(ISingle_SendText model);
        /// <summary>
        /// 发送-图片消息
        /// </summary>
        /// <returns></returns>
        object Single_SendPicture(ISingle_SendText model);
        /// <summary>
        /// 发送-已读回执
        /// </summary>
        /// <returns></returns>
        Task Single_SendHasRead();
    }

}

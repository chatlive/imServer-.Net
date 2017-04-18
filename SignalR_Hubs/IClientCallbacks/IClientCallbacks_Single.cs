using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IClientCallbacks
{

    /// <summary>
    /// 单聊
    /// </summary>
    public interface IClientCallbacks_Single
    {

        /// <summary>
        /// 发送-文本/表情消息
        /// </summary>
        /// <returns></returns>
        void Single_SendText(object msg);
        /// <summary>
        /// 发送-文件消息
        /// </summary>
        /// <returns></returns>
        Task Single_SendFile(object msg);
        /// <summary>
        /// 发送-图片消息
        /// </summary>
        /// <returns></returns>
        Task Single_SendPicture(object msg);
        /// <summary>
        /// 发送-已读回执
        /// </summary>
        /// <returns></returns>
        Task Single_SendHasRead();
    }

}

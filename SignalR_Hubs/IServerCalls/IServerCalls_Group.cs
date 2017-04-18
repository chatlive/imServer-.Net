using SignalR_Hubs.Models.InputOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IServerCalls
{

    /// <summary>
    /// 群聊
    /// </summary>
    public interface IServerCalls_Group
    {

        /// <summary>
        /// 发送-文本/表情消息
        /// </summary>
        /// <returns></returns>
        object Group_SendText(IGroup_SendText model);
        /// <summary>
        /// 发送-文件消息
        /// </summary>
        /// <returns></returns>
        object Group_SendFile(IGroup_SendText model);
        /// <summary>
        /// 发送-图片消息
        /// </summary>
        /// <returns></returns>
        object Group_SendPicture(IGroup_SendText model);
        /// <summary>
        /// 发送-已读回执
        /// </summary>
        /// <returns></returns>
        Task Group_SendHasRead();
        /// <summary>
        /// 发送-群组通知
        /// </summary>
        /// <returns></returns>
        Task Group_SendNotice();

    }

}

using ChatDB.Entity.IM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models.InputOut
{
    /// <summary>
    /// 会话-重置未读消息数
    /// 输入
    /// </summary>
    public class IChatter_ResetUnreadMsg
    {
        /// <summary>
        /// 聊天编号
        /// </summary>
        public string ChatId { get; set; }
        /// <summary>
        /// 会话类型
        /// </summary>
        public IM_ChatType SessionType { get; set; }
    }
    /// <summary>
    /// 会话-重置未读消息数
    /// 输出
    /// </summary>
    public class OChatter_ResetUnreadMsg
    {
        /// <summary>
        /// 聊天编号
        /// 对方
        /// </summary>
        public string ChatId { get; set; }
        /// <summary>
        /// 会话编号
        /// </summary>
        public string SessionId { get; set; }
        /// <summary>
        /// 会话类型
        /// </summary>
        public IM_ChatType SessionType { get; set; }
        /// <summary>
        /// 未读消息数量
        /// </summary>
        public int UnreadMsgCount { get; set; }
    }
}

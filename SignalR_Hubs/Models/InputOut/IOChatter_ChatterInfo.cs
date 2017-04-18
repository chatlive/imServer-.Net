using ChatDB.Entity.IM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models.InputOut
{
    ///// <summary>
    ///// 
    ///// 输入
    ///// </summary>
    //public class IChatter_ChatterInfo
    //{
    //}

    /// <summary>
    /// 会话
    /// 输出
    /// </summary>
    public class OChatter_ChatterInfo
    {
        public OChatter_ChatterInfo()
        {
            Messages = new HashSet<object>();
        }

        /// <summary>
        /// 聊天编号
        /// 对方
        /// </summary>
        public string ChatId { get; set; }
        /// <summary>
        /// 聊天名称
        /// 对方
        /// </summary>
        public string ChatName { get; set; }
        /// <summary>
        /// 聊天头像
        /// 对方
        /// </summary>
        public string ChatImg { get; set; }
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
        /// <summary>
        /// 会话时间
        /// </summary>
        public DateTime ChatterTime { get; set; }
        /// <summary>
        /// 聊天消息
        /// </summary>
        public ICollection<object> Messages { get; set; }
    }
}

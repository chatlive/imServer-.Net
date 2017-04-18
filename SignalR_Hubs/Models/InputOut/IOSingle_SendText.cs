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
    //public class ISingle_SendText
    //{
    //}
    ///// <summary>
    ///// 
    ///// 输出
    ///// </summary>
    //public class OSingle_SendText
    //{
    //}


    /// <summary>
    /// 发送-文本/表情消息
    /// 输入
    /// </summary>
    public class ISingle_SendText
    {
        /// <summary>
        /// 消息-客户端编号
        /// </summary>
        public string MsgClientId { get; set; }
        /// <summary>
        /// 发送者（用户编号）
        /// </summary>
        public string From_UserId { get; set; }
        /// <summary>
        /// 接收者（用户编号）
        /// </summary>
        public string To_UserId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public IM_MsgType MsgType { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgBody { get; set; }
    }
    /// <summary>
    /// 发送-文本/表情消息
    /// 输出
    /// </summary>
    public class OSingle_SendText
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 消息-客户端编号
        /// </summary>
        public string MsgClientId { get; set; }
        /// <summary>
        /// 发送者（用户编号）
        /// </summary>
        public string From_UserId { get; set; }
        /// <summary>
        /// 接收者（用户编号）
        /// </summary>
        public string To_UserId { get; set; }

        /// <summary>
        /// 消息时间
        /// </summary>
        public DateTime MsgTime { get; set; }
        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public IM_MsgType MsgType { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgBody { get; set; }
    }
}

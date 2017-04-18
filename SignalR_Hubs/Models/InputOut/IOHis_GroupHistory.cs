using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models.InputOut
{
    /// <summary>
    /// 获取-群聊记录（分页）
    /// 输入
    /// </summary>
    public class IHis_GroupHistory
    {
        /// <summary>
        /// 单聊消息编号
        /// </summary>
        public Guid? MsgId { get; set; }
        /// <summary>
        /// 聊天编号
        /// 对方
        /// </summary>
        public string ChatId { get; set; }
    }

    /// <summary>
    /// 获取-群聊记录（分页）
    /// 输出
    /// </summary>
    public class OHis_GroupHistory
    {
    }
}

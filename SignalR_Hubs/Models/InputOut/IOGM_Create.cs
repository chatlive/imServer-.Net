using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models.InputOut
{
    /// <summary>
    /// 群主-创建群
    /// 输入
    /// </summary>
    public class IGM_Create
    {
        /// <summary>
        /// 群聊编号
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// 群聊名称
        /// </summary>
        public string GroupName { get; set; }
    }
    /// <summary>
    /// 群主-创建群
    /// 输出
    /// </summary>
    public class OGM_Create
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
    }

}

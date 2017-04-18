using ChatDB.Entity.IM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models.InputOut
{
    /// <summary>
    /// 获取群组详情
    /// 输入
    /// </summary>
    public class IGM_GroupInfo
    {
        /// <summary>
        /// 群组编号
        /// </summary>
        public string GroupId { get; set; }
    }

    /// <summary>
    /// 获取群组详情
    /// 输出
    /// </summary>
    public class OGM_GroupInfo
    {
        /// <summary>
        /// 群组-职位
        /// </summary>
        public IM_GroupPosition GroupPosition { get; set; }
        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Img { get; set; }
    }

}

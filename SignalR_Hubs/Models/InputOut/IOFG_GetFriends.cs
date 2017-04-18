using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models.InputOut
{

    ///// <summary>
    ///// 获取-好友
    ///// 输入
    ///// </summary>
    //public class IFG_GetFriends
    //{
    //}

    /// <summary>
    /// 获取-好友
    /// 输出
    /// </summary>
    public class OFG_GetFriends
    {
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

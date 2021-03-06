﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models.InputOut
{

    /// <summary>
    /// 群主-减人
    /// 输入
    /// </summary>
    public class IGM_RemoveUsers
    {
        ///// <summary>
        ///// 群组唯一编号
        ///// </summary>
        //public Guid Id { get; set; }
        /// <summary>
        /// 群组编号
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// 待移除-账户名集合
        /// </summary>
        public ICollection<string> Accounts { get; set; }
    }
    /// <summary>
    /// 群主-减人
    /// 输出
    /// </summary>
    public class OGM_RemoveUsers
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

using ChatDB.Entity.IM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Models.InputOut
{

    ///// <summary>
    ///// 获取-群组
    ///// 输入
    ///// </summary>
    //public class IFG_GetGroups
    //{
    //}

    /// <summary>
    /// 获取-群组
    /// 输出
    /// </summary>
    public class OFG_GetGroups
    {
        public OFG_GetGroups()
        {
            Members = new HashSet<object>();
        }

        /// <summary>
        /// 唯一Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 群组-Id
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// 群组-名称
        /// </summary>
        public string GroupName { get; set; }
        /// <summary>
        /// 群组-职位
        /// </summary>
        public IM_GroupPosition GroupPosition { get; set; }
        /// <summary>
        /// 群组-成员
        /// </summary>
        public ICollection<object> Members { get; set; }
    }

}

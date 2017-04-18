using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IClientCallbacks
{

    /// <summary>
    /// 历史消息/消息记录查询(History 简写His)
    /// </summary>
    public interface IClientCallbacks_History
    {
        /// <summary>
        /// 获取-单聊记录（分页）
        /// </summary>
        void His_SingleHistory();
        /// <summary>
        /// 获取-群聊记录（分页）
        /// </summary>
        void His_GroupHistory();
        /// <summary>
        /// 查询-单聊记录（关键字/时间段）
        /// </summary>
        void His_QuerySingle();
        /// <summary>
        /// 查询-群聊记录（关键字/时间段）
        /// </summary>
        void His_QueryGroup();
    }


}

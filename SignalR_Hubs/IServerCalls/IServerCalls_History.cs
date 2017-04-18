using SignalR_Hubs.Models.InputOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.IServerCalls
{

    /// <summary>
    /// 历史消息/消息记录查询(History 简写His)
    /// </summary>
    public interface IServerCalls_History
    {
        /// <summary>
        /// 获取-单聊记录（分页）
        /// </summary>
        object His_SingleHistory(IHis_SingleHistory model);
        /// <summary>
        /// 获取-群聊记录（分页）
        /// </summary>
        object His_GroupHistory(IHis_GroupHistory model);
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

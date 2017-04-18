using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Common
{
    /// <summary>
    /// Hub键
    /// </summary>
    public static class HubKey
    {
        /// <summary>
        /// 客户端应用程序标识
        /// </summary>
        public const string HubKey_App = "HubKey_App";
        /// <summary>
        /// 账户标识
        /// </summary>
        public const string HubKey_Account = "HubKey_Account";

        /// <summary>
        /// SignalR用户标识（SignalR分发参数）
        /// </summary>
        /// <param name="app">App标识</param>
        /// <param name="account">账户标识</param>
        /// <returns></returns>
        public static string App__Account(string app, string account)
        {
            return app + "__" + account;
        }

    }
}

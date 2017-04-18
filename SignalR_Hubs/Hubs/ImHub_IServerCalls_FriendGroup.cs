using ChatDB.Entity;
using Microsoft.AspNet.SignalR;
using SignalR_Hubs.IServerCalls;
using SignalR_Hubs.Models;
using SignalR_Hubs.Models.InputOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Hubs
{
    public partial class ImHub : IServerCalls_FriendGroup
    {
        public Task<object> FG_GetContacts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取-好友
        /// </summary>
        /// <returns></returns>
        public object FG_GetFriends()
        {
            List<OFG_GetFriends> resFriends = null;

            using (var db = new ModelAC())
            {
                var friends = db.IM_User.Where(p => p.App_Id == APP_GUID && p.UserId != ACCOUNT).OrderBy(p => p.Name);
                resFriends = friends.Select(p => new OFG_GetFriends
                {
                    Account = p.UserId,
                    Name = p.Name,
                    Img = SITE_URL + p.PortraitUri
                }).ToList();
            }

            return CommonJson.camelObject(resFriends);
        }

        /// <summary>
        /// 获取-群组
        /// </summary>
        /// <returns></returns>
        public object FG_GetGroups()
        {
            IList<OFG_GetGroups> resGroups = Base_GetGroups();

            return CommonJson.camelObject(resGroups);
        }




    }
}

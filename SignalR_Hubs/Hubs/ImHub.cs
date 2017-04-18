using ChatDB.Entity;
using ChatDB.Entity.IM;
using Microsoft.AspNet.SignalR;
using SignalR_Hubs.Common;
using SignalR_Hubs.Models.InputOut;
using SignalR_MapUsers.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Hubs
{
    /// <summary>
    /// ImHub
    /// </summary>
    public partial class ImHub : Hub<IClientCallbacks.IClientCallbacks>
    {
        #region 基本

        /// <summary>
        /// 客户端应用程序标识GUID
        /// </summary>
        public Guid APP_GUID
        {
            get
            {
                return new Guid(APP);
            }
        }

        /// <summary>
        /// 客户端应用程序标识
        /// </summary>
        public string APP
        {
            get
            {
                return Context.Request.QueryString[HubKey.HubKey_App];
            }
        }

        /// <summary>
        /// 账户标识
        /// </summary>
        public string ACCOUNT
        {
            get
            {
                return Context.Request.QueryString[HubKey.HubKey_Account];
            }
        }

        /// <summary>
        /// 登录用户
        /// </summary>
        public IM_User LOGIN_USER
        {
            get
            {
                IM_User user;
                using (var db = new ModelAC())
                {
                    user = db.IM_User.SingleOrDefault(p => p.App_Id == APP_GUID && p.UserId == ACCOUNT);
                }
                return user;
            }
        }

        /// <summary>
        /// 登录标识
        /// </summary>
        public string LOGIN_ACCOUNT
        {
            get
            {
                return HubKey.App__Account(app: APP, account: ACCOUNT);
            }
        }

        /// <summary>
        /// 站点URL
        /// </summary>
        public string SITE_URL
        {
            get
            {
                return "Http://" + Context.Request.Url.Authority;
            }
        }

        #endregion

        public override Task OnConnected()
        {
            var name = LOGIN_ACCOUNT;
            using (var db = new SignalR_MapUsersModel())
            {
                var user = db.Users
                    .Include(u => u.Connections)
                    .SingleOrDefault(u => u.UserName == name);

                if (user == null)
                {
                    user = new User
                    {
                        UserName = name,
                        CreateTime = DateTime.Now,
                        Connections = new List<Connection>()
                    };
                    db.Users.Add(user);
                }

                user.Connections.Add(new Connection
                {
                    ConnectionID = Context.ConnectionId,
                    UserAgent = Context.Request.Headers["User-Agent"],
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    Connected = true
                });
                db.SaveChanges();
            }
            Base_Online();
            return base.OnConnected();
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        /// <summary>
        /// 检测断开原因
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            if (stopCalled)
            {
                Console.WriteLine(String.Format("Client {0} explicitly closed the connection.", Context.ConnectionId));
            }
            else
            {
                Console.WriteLine(String.Format("Client {0} timed out .", Context.ConnectionId));
            }
            using (var db = new SignalR_MapUsersModel())
            {
                var connection = db.Connections.Find(Context.ConnectionId);
                db.Connections.Remove(connection);
                //connection.Connected = false;
                //connection.UpdateTime = DateTime.Now;
                db.SaveChanges();
            }
            Base_Offline();
            return base.OnDisconnected(stopCalled);
        }


        #region 扩展

        /// <summary>
        /// 获取-App用户 在线ConnectionId集合
        /// </summary>
        /// <param name="app_accounts"></param>
        private IList<string> Base_GetConnectionIds(IList<string> app_accounts)
        {
            var resConnectionIDs = new List<string>();

            using (var db = new SignalR_MapUsersModel())
            {
                resConnectionIDs = db.Connections
                   .Where(p => p.Connected == true && app_accounts.Contains(p.User_UserName))
                   .Select(p => p.ConnectionID).ToList();
            }
            return resConnectionIDs;
        }

        /// <summary>
        /// 上线
        /// </summary>
        private void Base_Online()
        {
            var grouplist = Base_GetGroups();
            foreach (var group in grouplist)
            {
                Groups.Add(Context.ConnectionId, group.Id);
            }
        }

        /// <summary>
        /// 离线
        /// </summary>
        private void Base_Offline()
        {
            var grouplist = Base_GetGroups();
            foreach (var group in grouplist)
            {
                Groups.Remove(Context.ConnectionId, group.Id);
            }
        }

        /// <summary>
        /// 获取群组集合
        /// </summary>
        private IList<OFG_GetGroups> Base_GetGroups()
        {
            var user = LOGIN_USER;
            List<OFG_GetGroups> resGroups = null;

            using (var db = new ModelAC())
            {
                resGroups = db.Im_UserGroup
                   .Where(p => p.IM_User_Id == user.Id)
                   .Select(p => new OFG_GetGroups
                   {
                       Id = p.IM_Group_Id.ToString(),
                       GroupId = p.IM_Group.GroupId,
                       GroupName = p.IM_Group.GroupName,
                       GroupPosition = p.GroupPosition
                   }).ToList();
            }
            return resGroups;
        }

        #endregion



    }
}

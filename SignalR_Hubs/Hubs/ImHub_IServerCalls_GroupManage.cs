using ChatDB.Entity;
using ChatDB.Entity.IM;
using Microsoft.AspNet.SignalR;
using SignalR_Hubs.Common;
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
    public partial class ImHub : IServerCalls_GroupManage
    {

        /// <summary>
        /// 群主-创建群
        /// </summary>
        public object GM_Create(IGM_Create model)
        {
            var mOGM_Create = new OGM_Create();

            if (ImGroupExists(model.GroupId))
            {
                mOGM_Create.Success = false;
                mOGM_Create.Msg = "已存在该群组编号";

                return CommonJson.camelObject(mOGM_Create);
            }

            var user = LOGIN_USER;
            var group = new IM_Group();
            var mIm_UserGroup = new Im_UserGroup();
            var db_result = 0;

            using (var db = new ModelAC())
            {
                #region db
                group.App_Id = APP_GUID;
                group.GroupId = model.GroupId;
                group.GroupName = model.GroupName;

                mIm_UserGroup.IM_User_Id = user.Id;
                mIm_UserGroup.IM_Group_Id = group.Id;
                mIm_UserGroup.GroupPosition = IM_GroupPosition.Founder;

                db.IM_Group.Add(group);
                db.Im_UserGroup.Add(mIm_UserGroup);
                db_result = db.SaveChanges();
                #endregion
            }

            if (db_result > 0)
            {

                mOGM_Create.Success = true;
                mOGM_Create.Msg = "群聊创建成功!";

                //将连接添加到指定的组
                Groups.Add(Context.ConnectionId, group.Id.ToString());
                return CommonJson.camelObject(mOGM_Create);
            }
            else
            {

                mOGM_Create.Success = false;
                mOGM_Create.Msg = "服务器错误!";

                return CommonJson.camelObject(mOGM_Create);
            }

        }

        public Task GM_Delete()
        {
            throw new NotImplementedException();
        }

        public Task GM_Exit()
        {
            throw new NotImplementedException();
        }

        public Task GM_GetGroups()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取群组详情
        /// </summary>
        /// <returns></returns>
        public object GM_GroupInfo(IGM_GroupInfo model)
        {
            var group = new IM_Group();
            var resMembers = Get_GroupMembers(model.GroupId);

            return CommonJson.camelObject(resMembers);
        }

        /// <summary>
        /// 群主-加人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object GM_AddUsers(IGM_AddUsers model)
        {
            var mOGM_AddUsers = new OGM_AddUsers();
            var group = new IM_Group();
            var users_add = new List<IM_User>();

            var db_result = 0;

            using (var db = new ModelAC())
            {
                #region db
                group = db.IM_Group.SingleOrDefault(p => p.App_Id == APP_GUID && p.GroupId == model.GroupId);

                users_add = db.IM_User.Where(p => p.App_Id == APP_GUID && model.Accounts.Contains(p.UserId)).ToList();

                foreach (var user in users_add)
                {
                    var mIm_UserGroup = new Im_UserGroup();
                    mIm_UserGroup.IM_User_Id = user.Id;
                    mIm_UserGroup.IM_Group_Id = group.Id;
                    mIm_UserGroup.GroupPosition = IM_GroupPosition.Memeber;
                    db.Im_UserGroup.Add(mIm_UserGroup);
                }

                db_result = db.SaveChanges();
                #endregion
            }

            if (db_result > 0)
            {

                mOGM_AddUsers.Success = true;
                mOGM_AddUsers.Msg = "添加群成员成功!";

                #region 连接组维护
                var app_accounts = users_add.Select(p => HubKey.App__Account(app: APP, account: p.UserId)).ToList();
                var connectionIDs = Base_GetConnectionIds(app_accounts);

                foreach (var connectionId in connectionIDs)
                {
                    //将连接添加到指定的组
                    Groups.Add(connectionId, group.Id.ToString());
                }
                #endregion

                #region 更新相关群组聊表信息-发送系统通知
                Update_GM_AddUsers(group);
                #endregion

                return CommonJson.camelObject(mOGM_AddUsers);
            }
            else
            {

                mOGM_AddUsers.Success = false;
                mOGM_AddUsers.Msg = "添加群成员失败!";

                return CommonJson.camelObject(mOGM_AddUsers);
            }
        }

        /// <summary>
        /// 群主-减人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public object GM_RemoveUsers(IGM_RemoveUsers model)
        {
            var mOGM_RemoveUsers = new OGM_RemoveUsers();
            var group = new IM_Group();
            var users_add = new List<IM_User>();

            var db_result = 0;

            using (var db = new ModelAC())
            {
                #region db
                group = db.IM_Group.SingleOrDefault(p => p.App_Id == APP_GUID && p.GroupId == model.GroupId);

                users_add = db.IM_User.Where(p => p.App_Id == APP_GUID && model.Accounts.Contains(p.UserId)).ToList();

                foreach (var user in users_add)
                {
                    var mIm_UserGroup = db.Im_UserGroup
                        .SingleOrDefault(p => p.IM_Group_Id == group.Id && p.IM_User_Id == user.Id);

                    db.Im_UserGroup.Remove(mIm_UserGroup);
                }

                db_result = db.SaveChanges();
                #endregion
            }

            if (db_result > 0)
            {
                mOGM_RemoveUsers.Success = true;
                mOGM_RemoveUsers.Msg = "移除群成员成功!";

                #region 连接组维护
                var app_accounts = users_add.Select(p => HubKey.App__Account(app: APP, account: p.UserId)).ToList();
                var connectionIDs = Base_GetConnectionIds(app_accounts);

                foreach (var connectionId in connectionIDs)
                {
                    //将连接添加到指定的组
                    Groups.Remove(connectionId, group.Id.ToString());
                }
                #endregion

                #region 更新相关群组聊表信息-发送系统通知
                Update_GM_RemoveUsers(group, app_accounts);
                #endregion

                return CommonJson.camelObject(mOGM_RemoveUsers);
            }
            else
            {

                mOGM_RemoveUsers.Success = false;
                mOGM_RemoveUsers.Msg = "移除群成员失败!";

                return CommonJson.camelObject(mOGM_RemoveUsers);
            }
        }

        /// <summary>
        /// 通知→群组人员变更
        /// </summary>
        /// <param name="group"></param>
        private void Update_GM_AddUsers(IM_Group group)
        {//通知所有群组成员
            var resMembers = Get_GroupMembers(group.GroupId);
            var app_accounts = resMembers.Select(p => HubKey.App__Account(app: APP, account: p.Account)).ToList();
            var connectionIDs = Base_GetConnectionIds(app_accounts);

            foreach (var connectionId in connectionIDs)
            {
                var groupInfo = new OFG_GetGroups()
                {
                    Id = group.Id.ToString(),
                    GroupId = group.GroupId,
                    GroupName = group.GroupName,
                    GroupPosition = IM_GroupPosition.Memeber,//管理员功能暂不实现
                    Members = resMembers.ToArray<object>(),
                };
                //发送系统通知
                Clients.Client(connectionId).GM_AddUsers(CommonJson.camelObject(groupInfo));
            }
        }

        /// <summary>
        /// 通知→群组人员变更
        /// </summary>
        /// <param name="group"></param>
        /// <param name="remove_app_accounts">移除的账户</param>
        private void Update_GM_RemoveUsers(IM_Group group, IList<string> remove_app_accounts)
        {//通知所有群组成员
            var resMembers = Get_GroupMembers(group.GroupId);
            var app_accounts = resMembers.Select(p => HubKey.App__Account(app: APP, account: p.Account)).ToList();
            app_accounts.AddRange(remove_app_accounts);
            var connectionIDs = Base_GetConnectionIds(app_accounts);

            foreach (var connectionId in connectionIDs)
            {
                var groupInfo = new OFG_GetGroups()
                {
                    Id = group.Id.ToString(),
                    GroupId = group.GroupId,
                    GroupName = group.GroupName,
                    GroupPosition = IM_GroupPosition.Memeber,//管理员功能暂不实现
                    Members = resMembers.ToArray<object>(),
                };
                //发送系统通知
                Clients.Client(connectionId).GM_RemoveUsers(CommonJson.camelObject(groupInfo));
            }
        }

        /// <summary>
        /// 获取群组成员列表
        /// </summary>
        /// <param name="groupId"></param>
        private List<OGM_GroupInfo> Get_GroupMembers(string groupId)
        {
            var resMembers = new List<OGM_GroupInfo>();

            using (var db = new ModelAC())
            {
                var group = db.IM_Group.SingleOrDefault(p => p.App_Id == APP_GUID && p.GroupId == groupId);
                resMembers = db.Im_UserGroup
                      .Where(p => p.IM_Group_Id == group.Id)
                      .Select(p => new OGM_GroupInfo
                      {
                          GroupPosition = p.GroupPosition,
                          Account = p.IM_User.UserId,
                          Name = p.IM_User.Name,
                          Img = SITE_URL + p.IM_User.PortraitUri,
                      }).ToList();
            }
            return resMembers;
        }

        /// <summary>
        /// 是否存在群聊
        /// </summary>
        /// <param name="groupId">群聊编号</param>
        /// <returns></returns>
        private bool ImGroupExists(string groupId)
        {
            var db_result = 0;
            using (var db = new ModelAC())
            {
                db_result = db.IM_Group.Count(e => e.App_Id == APP_GUID && e.GroupId == groupId);
            }
            return db_result > 0;
        }

    }
}

using ChatDB.Entity;
using ChatDB.Entity.IM;
using Microsoft.AspNet.SignalR;
using SignalR_Hubs.Common;
using SignalR_Hubs.IServerCalls;
using SignalR_Hubs.Models;
using SignalR_Hubs.Models.InputOut;
using SignalR_MapUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Hubs.Hubs
{
    public partial class ImHub : IServerCalls_Group
    {
        public Task Group_SendHasRead()
        {
            throw new NotImplementedException();
        }

        public Task Group_SendNotice()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 发送-文件消息
        /// </summary>
        /// <returns></returns>
        public object Group_SendFile(IGroup_SendText model)
        {
            var user = LOGIN_USER;
            var msg = new IM_MsgGroup();
            var db_result = 0;

            using (var db = new ModelAC())
            {
                #region db
                msg.App_Id = APP_GUID;

                msg.MsgClientId = model.MsgClientId;
                msg.From_UserId = user.Id;
                msg.To_GroupId =
                    db.IM_Group.SingleOrDefault(p => p.App_Id == APP_GUID && p.GroupId == model.To_GroupId).Id;

                msg.MsgTime = DateTime.Now;
                msg.IsFullRead = false;
                msg.MsgType = model.MsgType;
                msg.MsgBody = model.MsgBody;

                db.IM_MsgGroup.Add(msg);
                db_result = db.SaveChanges();
                #endregion
            }

            var session_result = Group_updateSession(msg);

            if (db_result == 1)
            {
                var mOGroup_SendText = new OGroup_SendText()
                {
                    #region 输出
                    Id = msg.Id.ToString(),
                    MsgClientId = msg.MsgClientId,
                    From_UserId = model.From_UserId,
                    //From_UserImg = SITE_URL + user.PortraitUri,
                    To_GroupId = model.To_GroupId,
                    MsgTime = msg.MsgTime,
                    IsFullRead = msg.IsFullRead,
                    MsgType = msg.MsgType,
                    MsgBody = msg.MsgBody,
                    #endregion
                };
                var jsonResult = CommonJson.camelObject(mOGroup_SendText);

                #region 消息分发

                Clients.OthersInGroup(msg.To_GroupId.ToString()).Group_SendFile(jsonResult);
                #endregion

                return jsonResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 发送-图片消息
        /// </summary>
        /// <returns></returns>
        public object Group_SendPicture(IGroup_SendText model)
        {
            var user = LOGIN_USER;
            var msg = new IM_MsgGroup();
            var db_result = 0;

            using (var db = new ModelAC())
            {
                #region db
                msg.App_Id = APP_GUID;

                msg.MsgClientId = model.MsgClientId;
                msg.From_UserId = user.Id;
                msg.To_GroupId =
                    db.IM_Group.SingleOrDefault(p => p.App_Id == APP_GUID && p.GroupId == model.To_GroupId).Id;

                msg.MsgTime = DateTime.Now;
                msg.IsFullRead = false;
                msg.MsgType = model.MsgType;
                msg.MsgBody = model.MsgBody;

                db.IM_MsgGroup.Add(msg);
                db_result = db.SaveChanges();
                #endregion
            }

            var session_result = Group_updateSession(msg);

            if (db_result == 1)
            {
                var mOGroup_SendText = new OGroup_SendText()
                {
                    #region 输出
                    Id = msg.Id.ToString(),
                    MsgClientId = msg.MsgClientId,
                    From_UserId = model.From_UserId,
                    //From_UserImg = SITE_URL + user.PortraitUri,
                    To_GroupId = model.To_GroupId,
                    MsgTime = msg.MsgTime,
                    IsFullRead = msg.IsFullRead,
                    MsgType = msg.MsgType,
                    MsgBody = msg.MsgBody,
                    #endregion
                };
                var jsonResult = CommonJson.camelObject(mOGroup_SendText);

                #region 消息分发

                Clients.OthersInGroup(msg.To_GroupId.ToString()).Group_SendPicture(jsonResult);
                #endregion

                return jsonResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 发送-文本/表情消息
        /// </summary>
        /// <returns></returns>
        public object Group_SendText(IGroup_SendText model)
        {
            var user = LOGIN_USER;
            var msg = new IM_MsgGroup();
            var db_result = 0;

            using (var db = new ModelAC())
            {
                #region db
                msg.App_Id = APP_GUID;

                msg.MsgClientId = model.MsgClientId;
                msg.From_UserId = user.Id;
                msg.To_GroupId =
                    db.IM_Group.SingleOrDefault(p => p.App_Id == APP_GUID && p.GroupId == model.To_GroupId).Id;

                msg.MsgTime = DateTime.Now;
                msg.IsFullRead = false;
                msg.MsgType = model.MsgType;
                msg.MsgBody = model.MsgBody;

                db.IM_MsgGroup.Add(msg);
                db_result = db.SaveChanges();
                #endregion
            }

            var session_result = Group_updateSession(msg);

            if (db_result == 1)
            {
                var mOGroup_SendText = new OGroup_SendText()
                {
                    #region 输出
                    Id = msg.Id.ToString(),
                    MsgClientId = msg.MsgClientId,
                    From_UserId = model.From_UserId,
                    //From_UserImg = SITE_URL + user.PortraitUri,
                    To_GroupId = model.To_GroupId,
                    MsgTime = msg.MsgTime,
                    IsFullRead = msg.IsFullRead,
                    MsgType = msg.MsgType,
                    MsgBody = msg.MsgBody,
                    #endregion
                };
                var jsonResult = CommonJson.camelObject(mOGroup_SendText);

                #region 消息分发
                Clients.OthersInGroup(msg.To_GroupId.ToString()).Group_SendText(jsonResult);
                #endregion

                return jsonResult;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新会话
        /// 群聊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool Group_updateSession(IM_MsgGroup msg)
        {
            var user = LOGIN_USER;
            //所有群聊成员
            var allMembers = new List<Guid>();
            var db_result = 0;
            using (var db = new ModelAC())
            {
                allMembers = db.Im_UserGroup.Where(p => p.IM_Group_Id == msg.To_GroupId).Select(p => p.IM_User_Id).ToList();

                var session = db.IM_Chatter.SingleOrDefault(p =>
                p.App_Id == APP_GUID && p.ChatType == IM_ChatType.Group && p.Group_GroupId == msg.To_GroupId);

                if (session == null)
                {
                    #region 新增会话
                    var newSession = new IM_Chatter()
                    {
                        App_Id = APP_GUID,
                        ChatType = IM_ChatType.Group,
                        Single_A_UserId = null,
                        Single_B_UserId = null,
                        Group_GroupId = msg.To_GroupId,
                    };

                    newSession.IM_ChatterActors.Add(new IM_ChatterActor()
                    {//消息发送者
                        App_Id = APP_GUID,
                        ChatterId = newSession.Id,
                        UserId = msg.From_UserId,
                        Last_MsgId = msg.Id,
                        UnreadMsgCount = 0,
                        ChatterTime = DateTime.Now,
                        IsCleared = false,
                    });

                    allMembers.Remove(msg.From_UserId);
                    foreach (var memeberId in allMembers)
                    {//消息接收者
                        newSession.IM_ChatterActors.Add(new IM_ChatterActor()
                        {
                            App_Id = APP_GUID,
                            ChatterId = newSession.Id,
                            UserId = memeberId,
                            Last_MsgId = msg.Id,
                            UnreadMsgCount = 1,
                            ChatterTime = DateTime.Now,
                            IsCleared = false,
                        });
                    }

                    db.IM_Chatter.Add(newSession);
                    db_result = db.SaveChanges();
                    #endregion
                }
                else
                {
                    #region 更新会话
                    List<Guid> oldIM_ChatterActors = session.IM_ChatterActors.Select(p => p.UserId).ToList();
                    List<Guid> expectedList = allMembers.Except(oldIM_ChatterActors).ToList();

                    foreach (var toActor in session.IM_ChatterActors)
                    {//更新会话参与者
                        toActor.Last_MsgId = msg.Id;
                        if (toActor.UserId != user.Id)
                        {//消息接收者
                            toActor.UnreadMsgCount += 1;
                        }
                        toActor.ChatterTime = DateTime.Now;
                    }

                    if (expectedList.Exists(p => p == msg.From_UserId))
                    {//新增会话参与者-消息发送者
                        expectedList.Remove(msg.From_UserId);

                        session.IM_ChatterActors.Add(new IM_ChatterActor()
                        {
                            App_Id = APP_GUID,
                            ChatterId = session.Id,
                            UserId = msg.From_UserId,
                            Last_MsgId = msg.Id,
                            UnreadMsgCount = 0,
                            ChatterTime = DateTime.Now,
                            IsCleared = false,
                        });
                    }

                    foreach (var memeberId in expectedList)
                    {//新增会话参与者-消息接收者
                        session.IM_ChatterActors.Add(new IM_ChatterActor()
                        {
                            App_Id = APP_GUID,
                            ChatterId = session.Id,
                            UserId = memeberId,
                            Last_MsgId = msg.Id,
                            UnreadMsgCount = 1,
                            ChatterTime = DateTime.Now,
                            IsCleared = false,
                        });
                    }

                    db_result = db.SaveChanges();
                    #endregion
                }
            }

            return db_result > 0;
        }


    }
}

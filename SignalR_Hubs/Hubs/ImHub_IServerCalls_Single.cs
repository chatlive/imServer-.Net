using ChatDB.Entity;
using ChatDB.Entity.IM;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
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
    public partial class ImHub : IServerCalls_Single
    {
        /// <summary>
        /// 发送-文件消息
        /// </summary>
        /// <returns></returns>
        public object Single_SendFile(ISingle_SendText model)
        {
            var msg = new IM_MsgSingle();
            var db_result = 0;

            using (var db = new ModelAC())
            {
                #region db
                msg.App_Id = APP_GUID;

                msg.MsgClientId = model.MsgClientId;
                msg.From_UserId =
                    db.IM_User.SingleOrDefault(p => p.App_Id == APP_GUID && p.UserId == model.From_UserId).Id;
                msg.To_UserId =
                    db.IM_User.SingleOrDefault(p => p.App_Id == APP_GUID && p.UserId == model.To_UserId).Id;

                msg.MsgTime = DateTime.Now;
                msg.IsRead = false;
                msg.MsgType = model.MsgType;
                msg.MsgBody = model.MsgBody;

                db.IM_MsgSingle.Add(msg);
                db_result = db.SaveChanges();
                #endregion
            }

            var session_result = Single_updateSession(msg);

            if (db_result == 1)
            {
                var mOSingle_SendText = new OSingle_SendText()
                {
                    #region 输出
                    Id = msg.Id.ToString(),
                    MsgClientId = msg.MsgClientId,
                    From_UserId = model.From_UserId,
                    To_UserId = model.To_UserId,
                    MsgTime = msg.MsgTime,
                    IsRead = msg.IsRead,
                    MsgType = msg.MsgType,
                    MsgBody = msg.MsgBody,
                    #endregion
                };
                var jsonResult = CommonJson.camelObject(mOSingle_SendText);

                #region 消息分发
                string to__Account = HubKey.App__Account(app: APP, account: model.To_UserId);
                using (var db = new SignalR_MapUsersModel())
                {
                    var connections = db.Connections.Where(p => p.User_UserName == to__Account && p.Connected == true).ToList();
                    for (int i = 0; i < connections.Count(); i++)
                    {
                        Clients.Client(connections[i].ConnectionID).Single_SendFile(jsonResult);
                    }
                }
                #endregion

                return jsonResult;
            }
            else
            {
                return null;
            }
        }

        public Task Single_SendHasRead()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 发送-图片消息
        /// </summary>
        /// <returns></returns>
        public object Single_SendPicture(ISingle_SendText model)
        {
            var msg = new IM_MsgSingle();
            var db_result = 0;

            using (var db = new ModelAC())
            {
                #region db
                msg.App_Id = APP_GUID;

                msg.MsgClientId = model.MsgClientId;
                msg.From_UserId =
                    db.IM_User.SingleOrDefault(p => p.App_Id == APP_GUID && p.UserId == model.From_UserId).Id;
                msg.To_UserId =
                    db.IM_User.SingleOrDefault(p => p.App_Id == APP_GUID && p.UserId == model.To_UserId).Id;

                msg.MsgTime = DateTime.Now;
                msg.IsRead = false;
                msg.MsgType = model.MsgType;
                msg.MsgBody = model.MsgBody;

                db.IM_MsgSingle.Add(msg);
                db_result = db.SaveChanges();
                #endregion
            }

            var session_result = Single_updateSession(msg);

            if (db_result == 1)
            {
                var mOSingle_SendText = new OSingle_SendText()
                {
                    #region 输出
                    Id = msg.Id.ToString(),
                    MsgClientId = msg.MsgClientId,
                    From_UserId = model.From_UserId,
                    To_UserId = model.To_UserId,
                    MsgTime = msg.MsgTime,
                    IsRead = msg.IsRead,
                    MsgType = msg.MsgType,
                    MsgBody = msg.MsgBody,
                    #endregion
                };
                var jsonResult = CommonJson.camelObject(mOSingle_SendText);

                #region 消息分发
                string to__Account = HubKey.App__Account(app: APP, account: model.To_UserId);
                using (var db = new SignalR_MapUsersModel())
                {
                    var connections = db.Connections.Where(p => p.User_UserName == to__Account && p.Connected == true).ToList();
                    for (int i = 0; i < connections.Count(); i++)
                    {
                        Clients.Client(connections[i].ConnectionID).Single_SendPicture(jsonResult);
                    }
                }
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
        public object Single_SendText(ISingle_SendText model)
        {
            var msg = new IM_MsgSingle();
            var db_result = 0;

            using (var db = new ModelAC())
            {
                #region db
                msg.App_Id = APP_GUID;

                msg.MsgClientId = model.MsgClientId;
                msg.From_UserId =
                    db.IM_User.SingleOrDefault(p => p.App_Id == APP_GUID && p.UserId == model.From_UserId).Id;
                msg.To_UserId =
                    db.IM_User.SingleOrDefault(p => p.App_Id == APP_GUID && p.UserId == model.To_UserId).Id;

                msg.MsgTime = DateTime.Now;
                msg.IsRead = false;
                msg.MsgType = model.MsgType;
                msg.MsgBody = model.MsgBody;

                db.IM_MsgSingle.Add(msg);
                db_result = db.SaveChanges();
                #endregion
            }

            var session_result = Single_updateSession(msg);

            if (db_result == 1)
            {
                var mOSingle_SendText = new OSingle_SendText()
                {
                    #region 输出
                    Id = msg.Id.ToString(),
                    MsgClientId = msg.MsgClientId,
                    From_UserId = model.From_UserId,
                    To_UserId = model.To_UserId,
                    MsgTime = msg.MsgTime,
                    IsRead = msg.IsRead,
                    MsgType = msg.MsgType,
                    MsgBody = msg.MsgBody,
                    #endregion
                };
                var jsonResult = CommonJson.camelObject(mOSingle_SendText);

                #region 消息分发
                string to__Account = HubKey.App__Account(app: APP, account: model.To_UserId);
                using (var db = new SignalR_MapUsersModel())
                {
                    var connections = db.Connections.Where(p => p.User_UserName == to__Account && p.Connected == true).ToList();
                    for (int i = 0; i < connections.Count(); i++)
                    {
                        Clients.Client(connections[i].ConnectionID).Single_SendText(jsonResult);
                    }
                }
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
        /// 单聊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool Single_updateSession(IM_MsgSingle msg)
        {
            var user = LOGIN_USER;
            var db_result = 0;
            using (var db = new ModelAC())
            {
                var session = db.IM_Chatter.SingleOrDefault(p => p.App_Id == APP_GUID && p.ChatType == IM_ChatType.Single &&
                  ((p.Single_A_UserId == msg.From_UserId && p.Single_B_UserId == msg.To_UserId) ||
                  (p.Single_A_UserId == msg.To_UserId && p.Single_B_UserId == msg.From_UserId))
                   );
                if (session == null)
                {
                    #region 新增会话
                    var newSession = new IM_Chatter()
                    {
                        App_Id = APP_GUID,
                        ChatType = IM_ChatType.Single,
                        Single_A_UserId = msg.From_UserId,
                        Single_B_UserId = msg.To_UserId,
                        Group_GroupId = null,
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

                    newSession.IM_ChatterActors.Add(new IM_ChatterActor()
                    {//消息接收者
                        App_Id = APP_GUID,
                        ChatterId = newSession.Id,
                        UserId = msg.To_UserId,
                        Last_MsgId = msg.Id,
                        UnreadMsgCount = 1,
                        ChatterTime = DateTime.Now,
                        IsCleared = false,
                    });

                    db.IM_Chatter.Add(newSession);
                    db_result = db.SaveChanges();
                    #endregion
                }
                else
                {
                    #region 更新会话
                    foreach (var toActor in session.IM_ChatterActors)
                    {
                        toActor.Last_MsgId = msg.Id;
                        if (toActor.UserId != user.Id)
                        {//消息接收者
                            toActor.UnreadMsgCount += 1;
                        }
                        toActor.ChatterTime = DateTime.Now;
                    }
                    db_result = db.SaveChanges();
                    #endregion
                }
            }

            return db_result > 0;
        }

    }
}

using ChatDB.Entity;
using ChatDB.Entity.IM;
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
    public partial class ImHub : IServerCalls_Chatter
    {
        /// <summary>
        /// 获取-会话信息
        /// </summary>
        /// <returns></returns>
        public object Chatter_ChatterInfo()
        {
            var user = LOGIN_USER;
            List<OChatter_ChatterInfo> db_Result = new List<OChatter_ChatterInfo>();
            using (var db = new ModelAC())
            {
                List<OChatter_ChatterInfo> sessions = new List<OChatter_ChatterInfo>();
                #region 单聊会话
                var single = db.IM_ChatterActor
                            .Where(p => p.App_Id == APP_GUID && p.IM_Chatter.ChatType == IM_ChatType.Single && p.UserId == user.Id)
                            .Select(p => new OChatter_ChatterInfo
                            {
                                ChatId = p.IM_Chatter.Single_A_UserId == user.Id ? p.IM_Chatter.Single_B_IM_User.UserId : p.IM_Chatter.Single_A_IM_User.UserId,
                                ChatName = p.IM_Chatter.Single_A_UserId == user.Id ? p.IM_Chatter.Single_B_IM_User.Name : p.IM_Chatter.Single_A_IM_User.Name,
                                ChatImg = SITE_URL + p.IM_User.PortraitUri,
                                SessionId = p.ChatterId.ToString(),
                                SessionType = p.IM_Chatter.ChatType,
                                UnreadMsgCount = p.UnreadMsgCount,
                                ChatterTime = p.ChatterTime,
                                Messages = new HashSet<object>() {
                            db.IM_MsgSingle.Where(s => s.Id == p.Last_MsgId)
                            .Select(m => new OSingle_SendText {
                                Id=m.Id.ToString(),
                                MsgClientId=m.MsgClientId,
                                From_UserId=m.From_IM_User.UserId,
                                To_UserId=m.To_IM_User.UserId,
                                MsgTime=m.MsgTime,
                                IsRead=m.IsRead,
                                MsgType=m.MsgType,
                                MsgBody=m.MsgBody,
                            }).FirstOrDefault()
                                },
                            });
                #endregion
                #region 群聊会话
                var group = db.IM_ChatterActor
                            .Where(p => p.App_Id == APP_GUID && p.IM_Chatter.ChatType == IM_ChatType.Group && p.UserId == user.Id)
                            .Select(p => new OChatter_ChatterInfo
                            {
                                ChatId = p.IM_Chatter.Group_IM_Group.GroupId,
                                ChatName = p.IM_Chatter.Group_IM_Group.GroupName,
                                ChatImg = null,
                                SessionId = p.ChatterId.ToString(),
                                SessionType = p.IM_Chatter.ChatType,
                                UnreadMsgCount = p.UnreadMsgCount,
                                ChatterTime = p.ChatterTime,
                                Messages = new HashSet<object>() {
                                db.IM_MsgGroup.Where(s => s.Id == p.Last_MsgId)
                                .Select(m => new OGroup_SendText {
                                    Id=m.Id.ToString(),
                                    MsgClientId=m.MsgClientId,
                                    From_UserId=m.From_IM_User.UserId,
                                    //From_UserImg = SITE_URL + m.From_IM_User.PortraitUri,
                                    To_GroupId=m.To_IM_Group.GroupId,
                                    MsgTime=m.MsgTime,
                                    IsFullRead=m.IsFullRead,
                                    MsgType=m.MsgType,
                                    MsgBody=m.MsgBody,
                                }).FirstOrDefault()
                                    },
                            });
                #endregion
                sessions.AddRange(single);
                sessions.AddRange(group);
                db_Result = sessions.OrderByDescending(p => p.ChatterTime).ToList();
            }
            var jsonResult = CommonJson.camelObject(db_Result);
            return jsonResult;
        }

        /// <summary>
        /// 会话-重置未读消息数
        /// </summary>
        /// <returns></returns>
        public object Chatter_ResetUnreadMsg(IChatter_ResetUnreadMsg model)
        {
            var user = LOGIN_USER;
            IM_ChatterActor chatterActor = null;
            var db_result = 0;
            using (var db = new ModelAC())
            {
                if (model.SessionType == IM_ChatType.Single)
                {
                    var userB = db.IM_User.SingleOrDefault(p => p.App_Id == APP_GUID && p.UserId == model.ChatId);
                    chatterActor = db.IM_ChatterActor
                           .SingleOrDefault(p => p.App_Id == APP_GUID && p.IM_Chatter.ChatType == IM_ChatType.Single && p.UserId == user.Id &&
                           ((p.IM_Chatter.Single_A_UserId == user.Id && p.IM_Chatter.Single_B_UserId == userB.Id) ||
                           (p.IM_Chatter.Single_A_UserId == userB.Id && p.IM_Chatter.Single_B_UserId == user.Id)));

                    chatterActor.UnreadMsgCount = 0;
                    db_result = db.SaveChanges();
                }
                else if (model.SessionType == IM_ChatType.Group)
                {
                    var group = db.IM_Group.SingleOrDefault(p => p.App_Id == APP_GUID && p.GroupId == model.ChatId);
                    chatterActor = db.IM_ChatterActor
                           .SingleOrDefault(p => p.App_Id == APP_GUID && p.IM_Chatter.ChatType == IM_ChatType.Group && p.UserId == user.Id && p.IM_Chatter.Group_GroupId == group.Id);

                    chatterActor.UnreadMsgCount = 0;
                    db_result = db.SaveChanges();
                }
            }
            if (db_result == 1)
            {
                var jsonResult = CommonJson.camelObject(new OChatter_ResetUnreadMsg
                {
                    ChatId = model.ChatId,
                    SessionId = chatterActor.ChatterId.ToString(),
                    SessionType = model.SessionType,
                    UnreadMsgCount = chatterActor.UnreadMsgCount
                });
                return jsonResult;
            }
            else
            {
                return null;
            }
        }



    }
}

using ChatDB.Entity;
using ChatDB.Entity.IM;
using SignalR_Hubs.Models;
using SignalR_Hubs.Models.InputOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ChatServer.Api
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {

        /// <summary>
        /// 群组用户-列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> vGroupUser()
        {
            object db_Result = null;
            using (var db = new ModelAC())
            {
                db_Result = db.Im_UserGroup
                    .OrderBy(p => p.IM_Group_Id)
                    .ThenByDescending(p => p.CreateTime)
                    .Take(100)
                    .Select(p => new
                    {
                        Id = p.Id,
                        IM_Group_Id = p.IM_Group_Id,
                        GroupId = p.IM_Group.GroupId,
                        GroupName = p.IM_Group.GroupName,
                        IM_User_Id = p.IM_User_Id,
                        UserId = p.IM_User.UserId,
                        Name = p.IM_User.Name,
                        GroupPosition = p.GroupPosition,
                        CreateTime = p.CreateTime,
                    }).ToList();
            }

            return Ok(db_Result);
        }

        /// <summary>
        /// 单聊-消息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> vMsgSingle()
        {
            object db_Result = null;
            using (var db = new ModelAC())
            {
                db_Result = db.IM_MsgSingle
                    .OrderByDescending(p => p.MsgTime)
                    .Take(10)
                    .Select(p => new
                    {
                        Id = p.Id,
                        App_Id = p.App_Id,
                        MsgClientId = p.MsgClientId,
                        MsgTime = p.MsgTime,
                        MsgType = p.MsgType,
                        MsgBody = p.MsgBody,
                        From_UserId = p.From_IM_User.UserId,
                        From_Name = p.From_IM_User.Name,
                        To_UserId = p.To_IM_User.UserId,
                        To_Name = p.To_IM_User.Name
                    }).ToList();
            }

            return Ok(db_Result);
        }

        /// <summary>
        /// 单聊-会话信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> vChatterActorBySingle()
        {
            object db_Result = null;
            using (var db = new ModelAC())
            {
                db_Result = db.IM_ChatterActor
                    .Where(p => p.IM_Chatter.ChatType == IM_ChatType.Single)
                    .OrderBy(p => p.ChatterId)
                    .Take(10)
                    .Select(p => new
                    {
                        Id = p.Id,
                        App_Id = p.App_Id,
                        Single_A_IM_User = p.IM_Chatter.Single_A_IM_User.UserId,
                        Single_B_IM_User = p.IM_Chatter.Single_B_IM_User.UserId,
                        UserId = p.IM_User.UserId,
                        Name = p.IM_User.Name,
                        Last_MsgId = p.Last_MsgId,
                        UnreadMsgCount = p.UnreadMsgCount,
                        ChatterTime = p.ChatterTime,
                        IsCleared = p.IsCleared,
                    }).ToList();
            }

            return Ok(db_Result);
        }


        /// <summary>
        /// 单聊-会话信息
        /// 某人
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> vChatterActorBySingleUser(Guid userId)
        {
            object db_Result = null;
            using (var db = new ModelAC())
            {
                db_Result = db.IM_ChatterActor
                    .Where(p => p.IM_Chatter.ChatType == IM_ChatType.Single && p.UserId == userId)
                    .OrderBy(p => p.ChatterId)
                    .Take(10)
                    .Select(p => new
                    {
                        Id = p.Id,
                        App_Id = p.App_Id,
                        Single_A_IM_User = p.IM_Chatter.Single_A_IM_User.UserId,
                        Single_B_IM_User = p.IM_Chatter.Single_B_IM_User.UserId,
                        UserId = p.IM_User.UserId,
                        Name = p.IM_User.Name,
                        Last_MsgId = p.Last_MsgId,
                        UnreadMsgCount = p.UnreadMsgCount,
                        ChatterTime = p.ChatterTime,
                        IsCleared = p.IsCleared,
                    }).ToList();
            }

            return Ok(db_Result);
        }

        /// <summary>
        /// 会话-信息
        /// 某人
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> vSessionByUser(Guid APP_GUID, Guid userId)
        {
            List<OChatter_ChatterInfo> db_Result = new List<OChatter_ChatterInfo>();
            using (var db = new ModelAC())
            {
                List<OChatter_ChatterInfo> sessions = new List<OChatter_ChatterInfo>();
                #region 单聊会话
                var single = db.IM_ChatterActor
                            .Where(p => p.App_Id == APP_GUID && p.IM_Chatter.ChatType == IM_ChatType.Single && p.UserId == userId)
                            .Select(p => new OChatter_ChatterInfo
                            {
                                ChatId = p.IM_Chatter.Single_A_UserId == userId ? p.IM_Chatter.Single_B_IM_User.UserId : p.IM_Chatter.Single_A_IM_User.UserId,
                                ChatName = p.IM_Chatter.Single_A_UserId == userId ? p.IM_Chatter.Single_B_IM_User.Name : p.IM_Chatter.Single_A_IM_User.Name,
                                ChatImg = string.Empty + p.IM_User.PortraitUri,
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
                            .Where(p => p.App_Id == APP_GUID && p.IM_Chatter.ChatType == IM_ChatType.Group && p.UserId == userId)
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
                sessions.AddRange(single);
                sessions.AddRange(group);
                db_Result = sessions.OrderByDescending(p => p.ChatterTime).ToList();
            }
            var jsonResult = CommonJson.camelObject(db_Result);
            return Ok(jsonResult);
        }

        /// <summary>
        /// 群聊-会话信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> vChatterActorByGroup()
        {
            object db_Result = null;
            using (var db = new ModelAC())
            {
                db_Result = db.IM_ChatterActor
                    .Where(p => p.IM_Chatter.ChatType == IM_ChatType.Group)
                    .OrderBy(p => p.ChatterId)
                    .Take(10)
                    .Select(p => new
                    {
                        Id = p.Id,
                        App_Id = p.App_Id,
                        GroupId = p.IM_Chatter.Group_IM_Group.GroupId,
                        GroupName = p.IM_Chatter.Group_IM_Group.GroupName,
                        UserId = p.IM_User.UserId,
                        Name = p.IM_User.Name,
                        Last_MsgId = p.Last_MsgId,
                        UnreadMsgCount = p.UnreadMsgCount,
                        ChatterTime = p.ChatterTime,
                        IsCleared = p.IsCleared,
                    }).ToList();
            }

            return Ok(db_Result);
        }


    }
}

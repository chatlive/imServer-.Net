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
    public partial class ImHub : IServerCalls_History
    {
        public void His_QueryGroup()
        {
            throw new NotImplementedException();
        }

        public void His_QuerySingle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取-群聊记录（分页）
        /// </summary>
        public object His_GroupHistory(IHis_GroupHistory model)
        {
            var user = LOGIN_USER;
            List<OGroup_SendText> db_Result = new List<OGroup_SendText>();

            using (var db = new ModelAC())
            {
                var group = db.IM_Group.SingleOrDefault(p => p.App_Id == APP_GUID && p.GroupId == model.ChatId);

                #region 数据查询
                if (model.MsgId == null)
                {//获取最新5条消息
                    db_Result = db.IM_MsgGroup
                        .Where(p => p.To_GroupId == group.Id)
                        .OrderByDescending(p => p.SortId)
                        .Take(5)
                        .Select(p => new OGroup_SendText
                        {
                            #region 输出
                            Id = p.Id.ToString(),
                            MsgClientId = p.MsgClientId,
                            From_UserId = p.From_IM_User.UserId,
                            //From_UserImg = SITE_URL + p.From_IM_User.PortraitUri,
                            To_GroupId = group.GroupId,
                            MsgTime = p.MsgTime,
                            IsFullRead = p.IsFullRead,
                            MsgType = p.MsgType,
                            MsgBody = p.MsgBody,
                            #endregion
                        })
                        .ToList();
                }
                else
                {//获取MsgId之前5条消息
                    var msg = db.IM_MsgGroup.SingleOrDefault(p => p.App_Id == APP_GUID && p.Id == model.MsgId);
                    db_Result = db.IM_MsgGroup
                        .Where(p => p.SortId < msg.SortId)
                        .Where(p => p.To_GroupId == group.Id)
                        .OrderByDescending(p => p.SortId)
                        .Take(5)
                        .Select(p => new OGroup_SendText
                        {
                            #region 输出
                            Id = p.Id.ToString(),
                            MsgClientId = p.MsgClientId,
                            From_UserId = p.From_IM_User.UserId,
                            //From_UserImg = SITE_URL + p.From_IM_User.PortraitUri,
                            To_GroupId = group.GroupId,
                            MsgTime = p.MsgTime,
                            IsFullRead = p.IsFullRead,
                            MsgType = p.MsgType,
                            MsgBody = p.MsgBody,
                            #endregion
                        })
                        .ToList();
                }
                #endregion
            }

            var jsonResult = CommonJson.camelObject(db_Result);
            return jsonResult;
        }


        /// <summary>
        /// 获取-单聊记录（分页）
        /// </summary>
        public object His_SingleHistory(IHis_SingleHistory model)
        {
            var user = LOGIN_USER;
            List<OSingle_SendText> db_Result = new List<OSingle_SendText>();

            using (var db = new ModelAC())
            {
                var userB = db.IM_User.SingleOrDefault(p => p.App_Id == APP_GUID && p.UserId == model.ChatId);

                #region 数据查询
                if (model.MsgId == null)
                {//获取最新5条消息
                    db_Result = db.IM_MsgSingle
                        .Where(p => (p.From_UserId == user.Id && p.To_UserId == userB.Id) || (p.From_UserId == userB.Id && p.To_UserId == user.Id))
                        .OrderByDescending(p => p.SortId)
                        .Take(5)
                        .Select(p => new OSingle_SendText
                        {
                            #region 输出
                            Id = p.Id.ToString(),
                            MsgClientId = p.MsgClientId,
                            From_UserId = p.From_UserId == user.Id ? user.UserId : userB.UserId,
                            To_UserId = p.From_UserId == user.Id ? user.UserId : userB.UserId,
                            MsgTime = p.MsgTime,
                            IsRead = p.IsRead,
                            MsgType = p.MsgType,
                            MsgBody = p.MsgBody,
                            #endregion
                        })
                        .ToList();
                }
                else
                {//获取MsgId之前5条消息
                    var msg = db.IM_MsgSingle.SingleOrDefault(p => p.App_Id == APP_GUID && p.Id == model.MsgId);
                    db_Result = db.IM_MsgSingle
                        .Where(p => p.SortId < msg.SortId)
                        .Where(p => (p.From_UserId == user.Id && p.To_UserId == userB.Id) || (p.From_UserId == userB.Id && p.To_UserId == user.Id))
                        .OrderByDescending(p => p.SortId)
                        .Take(5)
                        .Select(p => new OSingle_SendText
                        {
                            #region 输出
                            Id = p.Id.ToString(),
                            MsgClientId = p.MsgClientId,
                            From_UserId = p.From_UserId == user.Id ? user.UserId : userB.UserId,
                            To_UserId = p.From_UserId == user.Id ? user.UserId : userB.UserId,
                            MsgTime = p.MsgTime,
                            IsRead = p.IsRead,
                            MsgType = p.MsgType,
                            MsgBody = p.MsgBody,
                            #endregion
                        })
                        .ToList();
                }
                #endregion
            }

            var jsonResult = CommonJson.camelObject(db_Result);
            return jsonResult;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatServer.Api
{
    using ChatDB.Entity;
    using ChatDB.Entity.IM;
    using Newtonsoft.Json;
    using System.Data.Entity;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http.Cors;
    using System.Web.Http.Description;

    #region 模型类

    /// <summary>
    /// 同步
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public object Body { get; set; }
    }

    public class I_User
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Name { get; set; }
    }

    public class Add_I
    {
        /// <summary>
        /// appKey
        /// </summary>
        public Guid appKey { get; set; }
        /// <summary>
        /// 用户集合
        /// </summary>
        public List<I_User> users { get; set; }
    }

    public class Update_I
    {
        /// <summary>
        /// appKey
        /// </summary>
        public Guid appKey { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public I_User user { get; set; }
    }

    public class Delete_I
    {
        /// <summary>
        /// appKey
        /// </summary>
        public Guid appKey { get; set; }
        /// <summary>
        /// 账户集合
        /// </summary>
        public List<string> accounts { get; set; }
    }

    #endregion

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ImUsersController : ApiController
    {
        private ModelAC db = new ModelAC();

        [HttpGet]
        public IHttpActionResult Query(Guid appKey)
        {
            IQueryable<IM_User> users = null;
            ApiResult apiResult = null;

            users = db.IM_User.Where(p => p.App_Id == appKey);

            if (users == null)
            {
                apiResult = new ApiResult() { Status = false, Msg = "暂无数据！" };
            }
            else
            {
                var userInfo = users.Select(p => new
                {
                    Account = p.UserId,
                    Name = p.Name
                });

                apiResult = new ApiResult() { Status = true, Msg = "加载完成！", Body = userInfo };
            }

            return Ok(apiResult);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add(Add_I model)
        {
            var appKey = model.appKey;
            var users = model.users;

            var db_result = 0;
            var oldList = new List<IM_User>();
            var newList = new List<IM_User>();
            ApiResult apiResult = null;

            #region 新增用户
            foreach (var user in users)
            {
                var oldUser = GetImUser(appKey, user.Account);

                if (oldUser != null)
                {
                    oldList.Add(oldUser);
                }
                else
                {
                    var newUser = new IM_User();
                    newUser.App_Id = appKey;
                    newUser.UserId = user.Account;
                    newUser.Name = user.Name;
                    newUser.PortraitUri = "/content/useravatar/public_001.png";
                    newList.Add(newUser);
                }
            }
            db.IM_User.AddRange(newList);

            db_result = await db.SaveChangesAsync();
            #endregion

            if (db_result == 0)
            {
                apiResult = new ApiResult() { Status = false, Msg = "新增账户数：0" };
            }
            else
            {
                apiResult = new ApiResult()
                {
                    Status = true,
                    Msg = "新增账户数：" + db_result,
                    Body = newList.Select(p => new I_User
                    {
                        Account = p.UserId,
                        Name = p.Name
                    })
                };
            }

            return Ok(apiResult);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Update(Update_I model)
        {
            var appKey = model.appKey;
            var user = model.user;

            var db_result = 0;
            ApiResult apiResult = null;

            #region 更新用户信息

            var oldUser = GetImUser(appKey, user.Account);

            if (oldUser != null)
            {
                oldUser.Name = user.Name;

                db.Entry(oldUser).State = EntityState.Modified;
                db_result = await db.SaveChangesAsync();
            }

            #endregion

            if (db_result == 0)
            {
                apiResult = new ApiResult() { Status = false, Msg = "账户不存在！" };
            }
            else
            {
                apiResult = new ApiResult()
                {
                    Status = true,
                    Msg = "更新完成！" + db_result,
                    Body = new I_User
                    {
                        Account = oldUser.UserId,
                        Name = oldUser.Name
                    }
                };
            }

            return Ok(apiResult);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Delete(Delete_I model)
        {
            var appKey = model.appKey;
            var accounts = model.accounts;

            var db_result = 0;
            IQueryable<IM_User> deleteUsers = null;
            ApiResult apiResult = null;

            #region 删除用户，用户相关信息删除

            deleteUsers = db.IM_User.Where(p => p.App_Id == appKey && accounts.Contains(p.UserId));

            db.IM_User.RemoveRange(deleteUsers);

            db_result = await db.SaveChangesAsync();
            #endregion

            if (db_result == 0)
            {
                apiResult = new ApiResult() { Status = false, Msg = "删除账户数：0" };
            }
            else
            {
                apiResult = new ApiResult() { Status = true, Msg = "删除账户数：" + db_result };
            }

            return Ok(apiResult);
        }

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="appKey"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        private IM_User GetImUser(Guid appKey, string account)
        {
            return db.IM_User.SingleOrDefault(p => p.App_Id == appKey && p.UserId == account);
        }

    }

}

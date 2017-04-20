using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace ChatServer.Api
{
    using ChatDB.Entity;
    using ChatDB.Entity.IM;
    using System.Threading.Tasks;
    using System.Web.Http.Cors;

    /// <summary>
    /// 登录结果
    /// </summary>
    public class LoginResult
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
        /// 用户信息
        /// </summary>
        public object User { get; set; }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChatController : ApiController
    {

        #region Appkey_Account验证接口

        [HttpGet]
        public async Task<IHttpActionResult> Login(string appKey, string account)
        {
            var user = new IM_User();

            using (var db = new ModelAC())
            {
                user = db.IM_User.SingleOrDefault(p => p.App_Id == new Guid(appKey) && p.UserId == account);
            }

            if (user != null)
            {
                var userInfo = new
                {
                    Account = user.UserId,
                    Name = user.Name,
                    Img = getSITE_URL() + "/content/useravatar/mine_001.png"
                };
                var loginResult = new LoginResult { Status = true, Msg = "验证通过.", User = userInfo };
                return Ok(loginResult);
            }
            else
            {
                var loginResult = new LoginResult { Status = false, Msg = "没有账户信息." };
                return Ok(loginResult);
            }

        }

        #endregion

        #region 图片接口
        [HttpPost]
        public HttpResponseMessage Upload_Img()
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];

            object jsonResult;
            try
            {
                string localPath = System.Web.HttpContext.Current.Server.MapPath("~/Upload_Img");

                //string localName = file.FileName;
                //改为唯一名称来代替
                string ex = Path.GetExtension(file.FileName);
                string localName = Guid.NewGuid().ToString("N") + ex;
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }
                file.SaveAs(Path.Combine(localPath, localName));

                var oHost = HttpContext.Current.Request.Url.Scheme + "://"
                    + HttpContext.Current.Request.Url.Host + ":"
                    + HttpContext.Current.Request.Url.Port;
                var oPath = "/Upload_Img/" + localName;
                var oPreviewPath = oHost + oPath;

                jsonResult = new
                {
                    status = "1",
                    msg = "数据加载成功！",
                    info = new
                    {
                        Path = oPath,
                        PreviewPath = oPreviewPath,
                        FileName = localName,
                        ExtensionName = ex
                    }
                };
            }
            catch (Exception ex)
            {
                jsonResult = new { status = "0", msg = "数据加载失败！", error = ex.Message.ToString() };
            }

            string json = JsonConvert.SerializeObject(jsonResult);
            return new HttpResponseMessage { Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json") };

        }

        #endregion

        #region 文件接口
        [HttpPost]
        public HttpResponseMessage Upload_File()
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];

            object jsonResult;
            try
            {
                string localPath = System.Web.HttpContext.Current.Server.MapPath("~/Upload_File");

                //string localName = file.FileName;
                //改为唯一名称来代替
                string ex = Path.GetExtension(file.FileName);
                string localName = Guid.NewGuid().ToString("N") + ex;
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }
                file.SaveAs(Path.Combine(localPath, localName));

                var oHost = HttpContext.Current.Request.Url.Scheme + "://"
                    + HttpContext.Current.Request.Url.Host + ":"
                    + HttpContext.Current.Request.Url.Port;
                var oPath = "/Upload_File/" + localName;
                var oPreviewPath = oHost + oPath;

                jsonResult = new
                {
                    status = "1",
                    msg = "数据加载成功！",
                    info = new
                    {
                        Path = oPath,
                        PreviewPath = oPreviewPath,
                        FileName = localName,
                        ExtensionName = ex
                    }
                };
            }
            catch (Exception ex)
            {
                jsonResult = new { status = "0", msg = "数据加载失败！", error = ex.Message.ToString() };
            }

            string json = JsonConvert.SerializeObject(jsonResult);
            return new HttpResponseMessage { Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json") };

        }

        #endregion

        private string getSITE_URL()
        {
            var url = "Http://" + HttpContext.Current.Request.Url.Authority;
            return url;
        }

    }
}

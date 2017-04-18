using BC.CommonConfig;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BcApiFrame.Log.Filter_ApiRecord
{
    /// <summary>
    /// api 接口,全局日志统计
    /// </summary>
    public class Filter_ApiRecord : ActionFilterAttribute
    {
        /// <summary>
        /// 接口调用之前
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            #region 日志内容

            //request
            string request_info = "Request信息:" + "\r\n" + actionContext.Request.ToString() + "\r\n";
            //输入参数
            string inputParam = "输入数据:" + "\r\n" + actionContext.Request.Content.ToString() + "\r\n";
            string paramInfo = "参数信息:" + "\r\n" + JsonConvert.SerializeObject(actionContext.ActionArguments);

            string content = request_info + inputParam + paramInfo;

            #endregion


            #region 日志文件名

            string controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string actionName = actionContext.ActionDescriptor.ActionName;
            string logFileName = controllerName + "_" + actionName + ".log";

            #endregion


            LogUtil.WriteLogFile(content, logFileName);
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// 接口调用之后
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            #region 日志文件名

            string controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
            string logFileName = controllerName + "_" + actionName + ".log";

            #endregion

            try
            {
                #region 日志内容
                //request
                string response_info = "Response信息:" + "\r\n" + actionExecutedContext.Response.ToString() + "\r\n";
                //输入参数
                string outputParam = "输出数据:" + "\r\n" + actionExecutedContext.Response.Content.ReadAsStringAsync().Result;
                string content = response_info + outputParam;

                #endregion

                LogUtil.WriteLogFile(content, logFileName);
            }
            catch(Exception ex)
            {
                string errorResponse = "ErrorResponse:\r\n" + actionExecutedContext.Response;
                LogUtil.WriteLogFile(errorResponse, logFileName);
                LogUtil.WriteLogFile(ex.Message, logFileName);
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
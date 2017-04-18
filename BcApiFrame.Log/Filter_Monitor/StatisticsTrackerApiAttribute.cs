using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BcApiFrame.Log.Filter_Monitor
{

    /// <summary>
    /// 统计跟踪器(api)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class StatisticsTrackerApiAttribute : ActionFilterAttribute
    {
        private readonly string Key = "_thisOnActionMonitorLog_";

        #region Action时间监控
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            MonitorLog MonLog = new MonitorLog();
            MonLog.ExecuteStartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffff", DateTimeFormatInfo.InvariantInfo));
            MonLog.ControllerName = filterContext.ControllerContext.ControllerDescriptor.ControllerName;
            MonLog.ActionName = filterContext.ActionDescriptor.ActionName;

            filterContext.Request.Properties[Key] = MonLog;

            //var stopWatch = new Stopwatch();
            //actionContext.Request.Properties[Key] = stopWatch;
            //stopWatch.Start();
        }

        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            MonitorLog MonLog = filterContext.Request.Properties[Key] as MonitorLog;
            MonLog.ExecuteEndTime = DateTime.Now;

            MonLog.ActionArgumentsParam = filterContext.ActionContext.ActionArguments;
            MonLog.FormCollections = null;//form表单提交的数据
            MonLog.QueryCollections = null;//Url 参数
            //Log4NetHelper.Monitor(MonLog.GetLoginfo(MonitorLog.MonitorType.Api));
            NLogHelper.Default.Info(MonLog.GetLoginfo(MonitorLog.MonitorType.Api));
        }

        #endregion

    }

    public class StatisticsTrackerApiErrorAttribute : ExceptionFilterAttribute
    {
        #region 错误日志

        public override void OnException(HttpActionExecutedContext filterContext)
        {

            string controllerName = filterContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            string actionName = filterContext.ActionContext.ActionDescriptor.ActionName;

            string ControllerName = string.Format("{0}Controller", controllerName);
            string ActionName = actionName;
            string ErrorMsg = string.Format("在执行 controller[{0}] 的 action[{1}] 时产生异常", ControllerName, ActionName);
            //Log4NetHelper.Error(ErrorMsg, filterContext.Exception);
            NLogHelper.Default.Error(ErrorMsg, filterContext.Exception);

            base.OnException(filterContext);
        }

        #endregion
    }

}

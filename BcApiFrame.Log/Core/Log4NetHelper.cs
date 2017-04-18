using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BcApiFrame.Log
{
    /// <summary>
    /// Log4Net 帮助器
    /// </summary>
    public static class Log4NetHelper
    {
        /// <summary>
        /// 注册 log4net
        /// </summary>
        static Log4NetHelper()
        {
            string path = Path.Combine(HttpRuntime.BinDirectory, "log4net.config");
            //注册 log4net
            log4net.Config.XmlConfigurator.Configure(
                new System.IO.FileInfo(path)
                );
        }

        static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
        static readonly log4net.ILog logmonitor = log4net.LogManager.GetLogger("logmonitor");


        public static void Error(string ErrorMsg, Exception ex = null)
        {
            if (ex != null)
            {
                logerror.Error(ErrorMsg, ex);
            }
            else
            {
                logerror.Error(ErrorMsg);
            }
        }

        public static void Info(string Msg)
        {
            loginfo.Info(Msg);
        }

        public static void Monitor(string Msg)
        {
            logmonitor.Info(Msg);
        }
    }

    public class Log4NetRegister
    {
        //public static void Run()
        //{
        //    //注册 log4net
        //    log4net.Config.XmlConfigurator.Configure(
        //        new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\App_Data\\log4net.config")
        //        );
        //}
    }

}
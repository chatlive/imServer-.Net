using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BcApiFrame.Log
{
    /// <summary>
    /// NLog 帮助器
    /// </summary>
    public class NLogHelper
    {
        NLog.Logger logger;

        private NLogHelper(NLog.Logger logger)
        {
            this.logger = logger;
        }

        public NLogHelper(string name)
                : this(NLog.LogManager.GetLogger(name))
        {
        }

        public static NLogHelper Default { get; private set; }

        static NLogHelper()
        {
            Default = new NLogHelper(NLog.LogManager.GetCurrentClassLogger());
        }

        public void Debug(string msg, params object[] args)
        {
            logger.Debug(msg, args);
        }

        public void Debug(string msg, Exception err)
        {
            logger.Debug(msg, err);
        }

        public void Info(string msg, params object[] args)
        {
            logger.Info(msg, args);
        }

        public void Info(string msg, Exception err)
        {
            logger.Info(msg, err);
        }

        public void Trace(string msg, params object[] args)
        {
            logger.Trace(msg, args);
        }

        public void Trace(string msg, Exception err)
        {
            logger.Trace(msg, err);
        }

        public void Error(string msg, params object[] args)
        {
            logger.Error(msg, args);
        }

        public void Error(string msg, Exception err)
        {
            logger.Error(msg, err);
        }

        public void Fatal(string msg, params object[] args)
        {
            logger.Fatal(msg, args);
        }

        public void Fatal(string msg, Exception err)
        {
            logger.Fatal(msg, err);
        }

        /// <summary>
        /// 本问题由于DLL间接引用丢失导致（未静态使用DLL，动态使用DLL）
        /// 即：第三方程序引用丢失Growl相关程序集
        /// </summary>
        public void Safe_DLL()
        {            
            NLog.Targets.GrowlNotify test = null;
        }
    }


}
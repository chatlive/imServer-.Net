using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BcApiFrame.Log.Filter_QueueRecord
{
    /// <summary>
    /// 把所有产生的日志信息存放到一个队列里面，然后通过新建一个线程，
    /// 不断的从这个队列里面读取异常信息，然后往日志里面写。
    /// 也就是所谓的生产者、消费者模式。
    /// </summary>
    public class QueueErrorAttribute : HandleErrorAttribute
    {
        public static Queue<Exception> ExceptionQueue = new Queue<Exception>();

        public override void OnException(ExceptionContext filterContext)
        {
            ExceptionQueue.Enqueue(filterContext.Exception);

            filterContext.HttpContext.Response.Redirect("~/Error.html");
            base.OnException(filterContext);
        }
    }


    public class QueueErrorFileLogHandle
    {
        /// <summary>
        /// 文件日志记录队列
        /// </summary>
        public static void Run()
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Logs/");

            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    if (QueueErrorAttribute.ExceptionQueue.Count > 0)
                    {
                        Exception ex = QueueErrorAttribute.ExceptionQueue.Dequeue();
                        if (ex != null)
                        {
                            NLogHelper.Default.Fatal(ex.Message);

                            #region 废弃
                            //string fileName = filePath + "Error-" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                            //if (!File.Exists(fileName))//验证路径是否存在
                            //{
                            //    File.Create(fileName);
                            //    //不存在则创建
                            //}
                            //File.AppendAllText(fileName, ex.Message); 
                            #endregion
                        }
                        else
                        {
                            Thread.Sleep(50);
                        }
                    }
                    else
                    {
                        Thread.Sleep(50);
                    }
                }
            });

        }

    }



}

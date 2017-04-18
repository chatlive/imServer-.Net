using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BC.CommonConfig
{
    /// <summary>
    /// public static class LogUtil
    /// </summary>
    public class LogUtil
    {
        /**/
        /// <summary>
        /// 读取日志文件
        /// </summary>
        /// <param name="logFileName"></param>
        /// <returns></returns>
        public static string ReadLogFile(string logFileName)
        {
            string ss = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = ss + "/LOGS/" + logFileName;
            //string path = Environment.CurrentDirectory + "\\" + logFileName;

            /**/
            ///从指定的目录以打开或者创建的形式读取日志文件
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);

            /**/
            ///定义输出字符串
            StringBuilder output = new StringBuilder();

            /**/
            ///初始化该字符串的长度为0
            output.Length = 0;

            /**/
            ///为上面创建的文件流创建读取数据流
            StreamReader read = new StreamReader(fs);

            /**/
            ///设置当前流的起始位置为文件流的起始点
            read.BaseStream.Seek(0, SeekOrigin.Begin);

            /**/
            ///读取文件
            while (read.Peek() > -1)
            {
                /**/
                ///取文件的一行内容并换行
                output.Append(read.ReadLine() + "\n");
            }

            /**/
            ///关闭释放读数据流
            read.Close();

            /**/
            ///返回读到的日志文件内容
            return output.ToString();
        }

        /**/
        /// <summary>
        /// 记录日志文件
        /// </summary>
        /// <param name="input"></param>
        /// <param name="logFileName"></param>
        public static void WriteLogFile(string input, string logFileName)
        {
            lock (typeof(LogUtil))
            {
                string ss = System.AppDomain.CurrentDomain.BaseDirectory;

                string pathPrefix = ss + "/LOGS/";
                string fname = pathPrefix + logFileName;
                /**/
                ///指定日志文件的目录            
                //string fname = Environment.CurrentDirectory + "\\" + logFileName;

                if (!Directory.Exists(pathPrefix))
                {
                    Directory.CreateDirectory(pathPrefix);
                }

                /**/
                ///定义文件信息对象
                FileInfo finfo = new FileInfo(fname);

                /**/
                ///判断文件是否存在以及是否大于2M
                if (finfo.Exists && finfo.Length > 2000000)
                {
                    /**/
                    ///删除该文件
                    finfo.Delete();
                }

                /**/
                ///创建只写文件流
                using (FileStream fs = finfo.OpenWrite())
                {
                    /**/
                    ///根据上面创建的文件流创建写数据流
                    StreamWriter w = new StreamWriter(fs);

                    /**/
                    ///设置写数据流的起始位置为文件流的末尾
                    w.BaseStream.Seek(0, SeekOrigin.End);

                    /**/
                    ///写入“Log Entry : ”
                    w.Write("\nLog Entry : ");

                    /**/
                    ///写入当前系统时间并换行
                    w.Write("{0} {1} \r\n", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString());

                    /**/
                    ///写入日志内容并换行
                    w.Write(input + "\r\n");

                    /**/
                    ///写入------------------------------------“并换行
                    w.Write("------------------------------------\r\n");

                    /**/
                    ///清空缓冲区内容，并把缓冲区内容写入基础流
                    w.Flush();

                    /**/
                    ///关闭写数据流
                    w.Close();
                }
            }
        }



    }
}

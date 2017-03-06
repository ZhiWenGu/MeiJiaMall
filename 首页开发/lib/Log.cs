using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using BLL;

namespace 首页开发
{
    
        public class Log
        {
            //在网站根目录下创建日志目录
            public static string path = HttpContext.Current.Request.PhysicalApplicationPath + "logs";
           
            /**
             * 向日志文件写入调试信息
             * @param className 类名
             * @param content 写入内容
             */
            public static void Debug(string className, string content)
            {
                if (WxPayConfig.LOG_LEVENL >= 3)
                {

                    LogServer.AddLog("DEBUG", className, content);
                    
                    WriteLog("DEBUG", className, content);
                }
            }

            /**
            * 向日志文件写入运行时信息
            * @param className 类名
            * @param content 写入内容
            */
            public static void Info(string className, string content)
            {
                if (WxPayConfig.LOG_LEVENL >= 2)
                {
                    LogServer.AddLog("INFO", className, content);
                   
                    WriteLog("INFO", className, content);
                }
            }

            /**
            * 向日志文件写入出错信息
            * @param className 类名
            * @param content 写入内容
            */
            public static void Error(string className, string content)
            {
                if (WxPayConfig.LOG_LEVENL >= 1)
                {
                    LogServer.AddLog("ERROR", className, content);
                    WriteLog("ERROR", className, content);
                }
            }

            /**
            * 实际的写日志操作
            * @param type 日志记录类型
            * @param className 类名
            * @param content 写入内容
            */
            protected static void WriteLog(string type, string className, string content)
            {
                if (!Directory.Exists(path))//如果日志目录不存在就创建
                {
                    Directory.CreateDirectory(path);
                }

                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
                string filename = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名

                //创建或打开日志文件，向日志文件末尾追加记录
                StreamWriter mySw = File.AppendText(filename);

                //向日志文件写入内容
                string write_content = time + " " + type + " " + className + ": " + content;
                mySw.WriteLine(write_content);

                //关闭日志文件
                mySw.Close();
            }
        }
}
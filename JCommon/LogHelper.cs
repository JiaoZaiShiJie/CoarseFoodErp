using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JCommon
{
    public static class LogHelper
    {
        public static void LoadUdpAppender()
        {
            log4net.Repository.Hierarchy.Hierarchy hier =
    log4net.LogManager.GetRepository() as log4net.Repository.Hierarchy.Hierarchy;
            if (hier != null)
            {
                log4net.Appender.UdpAppender udpAppender = new log4net.Appender.UdpAppender();
                udpAppender.RemoteAddress = System.Net.IPAddress.Parse("127.0.0.1");
                udpAppender.RemotePort = int.Parse("7171");
                udpAppender.Layout = new log4net.Layout.XmlLayoutSchemaLog4j();
                udpAppender.Encoding = System.Text.UTF8Encoding.UTF8;
                udpAppender.ActivateOptions();
                log4net.Config.BasicConfigurator.Configure(udpAppender);
                var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
                log4net.Config.XmlConfigurator.Configure(logCfg);
            }
        }

        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteDebug(
            Type type,
            string message,
            [CallerLineNumber] int iCallerLineNumber = 0,
            [CallerMemberName] string iCallerMemberName = "")
        {
            log4net.LogManager.GetLogger(type).DebugFormat("[方法名]:{0}, [行号]:{1}, [输出信息]:{2}", iCallerMemberName, iCallerLineNumber, message);
        }

        /// <summary>
        /// 记录异常信息
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteError(Type type, Exception ex)
        {
            log4net.LogManager.GetLogger(type).Error(ex);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="strLog"></param>
        public static void WriteLog(
            string strMsg,
            [CallerLineNumber] int iCallerLineNumber = 0,
            [CallerMemberName] string iCallerMemberName = "")
        {
            log4net.LogManager.GetLogger(typeof(LogHelper)).InfoFormat("[方法名]:{0}, [行号]:{1}, [输出信息]:{2}", iCallerMemberName, iCallerLineNumber, strMsg);
        }
    }
}

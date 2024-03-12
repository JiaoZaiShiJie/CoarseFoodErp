using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using JCommon;
using JCommon.Jot;
using CoarseFoodErp.Utils;
using DevExpress.XtraEditors;
using JBaseCommon.JBaseForm;
using CoarseFoodErp.CoarseFoodForm.SysSeting;
using DevExpress.Data.ExpressionEditor;
using System.Net.Http;
using System.Net;
using JBaseCommon.Utils;
namespace CoarseFoodErp
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static  void Main()
        {
            ///注入日志
            LogHelper.LoadUdpAppender();
            #region 加载皮肤

            DevExpress.UserSkins.BonusSkins.Register();
            string skinname = JotConfigService.GetData(E_SysKey.皮肤设置, E_SysKey_Type.皮肤名称, "WXI").ToString();
            if (!string.IsNullOrEmpty(skinname))
            {
                UserLookAndFeel.Default.SetSkinStyle(skinname);
            }
            #endregion 加载皮肤

            #region 处理程序异常


            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //处理UI线程异常
            Application.ThreadException += Application_ThreadException;

            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // 多线程异常
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            #endregion 处理程序异常

            #region 加载dev汉化

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            WindowsFormsSettings.TrackWindowsAppMode = DevExpress.Utils.DefaultBoolean.True;

            #endregion 加载dev汉化

          

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #region 处理程序异常

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception != null)
            {
                LogHelper.WriteError(typeof(Program), e.Exception);
            }

            XtraMessageBox.Show(string.Format("错误码{0}：{1}", e.Exception.HResult, e.Exception.Message), "未处理的异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                LogHelper.WriteError(typeof(Program), ex);
                XtraMessageBox.Show(string.Format("错误码{0}：{1}", ex.HResult, ex.Message), "未处理的异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            var ex = e.Exception as Exception;
            if (ex != null)
            {
                LogHelper.WriteError(typeof(Program), ex);
            }

            XtraMessageBox.Show(string.Format("错误码{0}：{1}", e.Exception.HResult, e.Exception.Message), "未处理的异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion 处理程序异常
    }
}

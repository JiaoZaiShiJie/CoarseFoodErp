using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using DevExpress.Data.ExpressionEditor;
using DevExpress.XtraEditors;
using JBaseCommon.Properties;
using JBaseCommon.Utils;
using JCommon.Jot;
using Microsoft.Win32;

namespace JBaseCommon.JBaseForm
{
    public partial class AutoUpdateForm : DevExpress.XtraEditors.XtraForm
    {

        #region 字段
        UpdateInfoEventArgs updateInfoEventArgs;




        #endregion

        #region 构造函数
        public AutoUpdateForm()
        {
            InitializeComponent();
            this.lb_CurrentVer.Parent = this.lb_UpDateVer.Parent = this.pictureEdit1;
        }
        #endregion

        #region 重写OnLoad函数
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent;
            this.sb_Cancel.Click += Sb_Cancel_Click;
            this.sb_Update.Click += Sb_Update_Click;
            this.FormClosing += AutoUpdateForm_FormClosing;
            string url = JotConfigService.GetData(E_SysKey.基础设置, E_SysKey_Type.软件升级Url).ToString();
            if (!string.IsNullOrEmpty(url))
            {
                AutoUpdater.Start(url);
            }
            else
            {
                this.MemoAdd("服务器升级地址未填写,请填写服务器升级地址");
            }

        }

        #region 窗体关闭前发生
        private void AutoUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutoUpdater.CheckForUpdateEvent -= AutoUpdater_CheckForUpdateEvent;
        }
        #endregion

        #region ico转bitmap
        public Bitmap IconToBitmap(Icon icon)
        {
            Bitmap bitmap = new Bitmap(icon.Width, icon.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawIcon(icon, 0, 0);
            }
            return bitmap;
        }
        #endregion

        #endregion

        #region 更新数据
        private  void Sb_Update_Click(object sender, EventArgs e)
        {
            if (AutoUpdater.DownloadUpdate(updateInfoEventArgs))
            {
                Application.Exit();
            }
        }
        #endregion

        #region 取消数据
        private void Sb_Cancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
        #endregion

        #region 更新数据事件
      
        private void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs args)
        {
           
            if (args.Error == null)
            {
                updateInfoEventArgs = args;
                string Content = string.Empty;
                if (args.IsUpdateAvailable)
                {
                    LoadingForm loadingForm = new LoadingForm();
                    loadingForm.SetCaption("正在获取更新信息");
                    loadingForm.Load += async (s, e1) =>
                    {
                        try
                        {
                            await Task.Delay(1000);
                            using (HttpClient httpClient = new HttpClient())
                            {
                                HttpResponseMessage response = await httpClient.GetAsync(args.ChangelogURL);
                                response.EnsureSuccessStatusCode();
                                if (response.StatusCode != HttpStatusCode.OK)
                                {
                                    memoEdit1.AppendText("以下为最新版本更新内容" + "\r\n");
                                    memoEdit1.AppendText("日志文件更新错误,请查看连接,目前状态为非200");
                                    return;
                                }
                                Content = await response.Content.ReadAsStringAsync();
                            }
                            this.lb_CurrentVer.Text = $"当前版本号:{args.InstalledVersion}";
                            this.lb_UpDateVer.Text = $"最新版本号:{args.CurrentVersion}";
                            MemoAdd("以下为最新版本更新内容" + "\r\n");
                            MemoAdd(Content);
                            if (args.Mandatory.Value)
                            {
                            }
                            else
                            {
                            }

                          
                        }
                        catch (Exception ex)
                        {
                            loadingForm.Hide();
                            XtraMessageBox.Show(this, ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            loadingForm.Close();
                        }

                    };
                    loadingForm.ShowDialog();
                }
                else
                {
                }
            }
            else
            {
                if (args.Error is WebException)
                {
                    MessageBox.Show(
                        @"There is a problem reaching update server. Please check your internet connection and try again later.",
                        @"Update Check Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(args.Error.Message,
                        args.Error.GetType().ToString(), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }


        }
        #endregion

        #region Memo追加字符串

        private void MemoAdd(string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.memoEdit1.SuspendLayout();
                    this.memoEdit1.AppendText($"{value}");
                    this.memoEdit1.SelectionStart = this.memoEdit1.Text.Length; // 将光标位置设置到文本末尾
                    this.memoEdit1.ScrollToCaret(); // 滚动到光标位置
                    this.memoEdit1.ResumeLayout(); // 恢复布局
                    this.memoEdit1.Refresh();
                }));
            }
            else
            {
                this.memoEdit1.SuspendLayout();
                this.memoEdit1.AppendText($"{value}");
                this.memoEdit1.SelectionStart = this.memoEdit1.Text.Length; // 将光标位置设置到文本末尾
                this.memoEdit1.ScrollToCaret(); // 滚动到光标位置
                this.memoEdit1.ResumeLayout(); // 恢复布局
                this.memoEdit1.Refresh();
            }
        }

        #endregion Memo追加字符串

    }
}
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

namespace JBaseCommon.JBaseForm
{
    public partial class AutoUpdateForm : DevExpress.XtraEditors.XtraForm
    {
        UpdateInfoEventArgs updateInfoEventArgs;

        #region 是否有更新
        public bool IsUpdate=false;

        public event Action<bool> IsupDateEvent;


        #endregion
        public AutoUpdateForm()
        {
            InitializeComponent();
     

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent; ;
            this.simpleButton1.Click += SimpleButton1_Click;
            AutoUpdater.Start("http://192.168.10.106/1.xml");
           
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (AutoUpdater.DownloadUpdate(updateInfoEventArgs))
            {
                Application.Exit();
            }
        }

        private async void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            if (args.Error == null)
            {
                IsUpdate = args.IsUpdateAvailable;
                IsupDateEvent?.Invoke(IsUpdate);
                if (IsUpdate)
                {
                    
                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage response = await httpClient.GetAsync(args.ChangelogURL);
                    memoEdit1.AppendText($"当前版本号:{args.CurrentVersion}最新版本号:{args.InstalledVersion}");
                    memoEdit1.AppendText("********************************************************************");
                    memoEdit1.AppendText(await response.Content.ReadAsStringAsync());
                    if (args.Mandatory.Value)
                    {
                    }
                    else
                    {
                    }
                   
                    updateInfoEventArgs = args;
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
    }
}
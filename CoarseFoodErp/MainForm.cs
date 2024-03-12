using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using CoarseFoodErp.CoarseFoodForm.UpdatePwd;
using CoarseFoodErp.Properties;
using CoarseFoodErp.Utils;
using CoarseFoodErp.Utils.Job;
using DevExpress.Data.ExpressionEditor;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Customization;
using DevExpress.XtraEditors;
using JBaseCommon;
using JBaseCommon.JBaseForm;
using JCommon;
using JCommon.Jot;

namespace CoarseFoodErp
{
    public partial class MainForm : XtraForm
    {

        #region 构造函数
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 重写加载函数

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            JotConfigService.Tracker.Track(this);
            await QuartzHelper.CreateScheduler();
            QuartzHelper.AddJob<MainFormJOb>("MainForm界面定时", "系统时间", "系统时间定时", "0/1 * * * * ? *", "MainForm", this);
            // 获取程序集的版本信息
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            bar_Version.Caption = $"Ver:{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            RegistEvent();
        }

        #endregion 重写加载函数

        #region 注册事件
        private void RegistEvent()
        {
            InitMenu();
            this.xtraTabbedMdiManager1.PageAdded += XtraTabbedMdiManager1_PageAdded;
            btn_Update.ItemClick += Btn_Update_ItemClick;
            bar_LogOut.ItemClick += Bar_LogOut_ItemClick;
        
        }
        #region 退出系统
        private void Bar_LogOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("是否确认退出系统?", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                Close();
            }
        }
        #endregion

        #region 检测更新
        private void Btn_Update_ItemClick(object sender, ItemClickEventArgs e)
        {
            AutoUpdateForm autoUpdateForm = new AutoUpdateForm();
            autoUpdateForm.Owner = this;
            autoUpdateForm.ShowDialog();
        }
        #endregion


        #endregion

        #region 初始化菜单
        private void InitMenu()
        {
            foreach (BarItem item in barManager1.Items.Cast<BarItem>())
            {
                if (item is BarLargeButtonItem || item is BarButtonItem || item is SkinDropDownButtonItem)
                {
                    item.ItemClick += Item_ItemClick;
                }
            }
        }
        private void Item_ItemClick(object sender, ItemClickEventArgs e)
        {
            ItemClick(e);
        }
        #region ItemClick方法
        private void ItemClick(ItemClickEventArgs e)
        {
            var menuItem = e.Item is BarLargeButtonItem ? (BarButtonItem)e.Item : (BarButtonItem)e.Item;
            if (menuItem.Tag == null)
            {
                return;
            }
            string formName = menuItem.Tag.ToString();

            if (formName.Length <= 0)
            {
                // 处理 formName 为空的情况，例如返回或抛出异常
                return;
            }

            int index = formName.LastIndexOf('.');
            string _formName = formName.Substring(index + 1);

            if (this.HasMdiChild(_formName) == null)
            {
                Type Dlg = Type.GetType(formName);

                if (Dlg == null)
                {
                    // 处理找不到类型的情况，例如返回或抛出异常
                    return;
                }
                BaseForm f = (BaseForm)Activator.CreateInstance(Dlg);
                if (f.IsModalForm)
                {
                    f.Owner = this;
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog(this);
                }
                else
                {
                    f.WindowState = FormWindowState.Maximized;
                    f.MdiParent = this;
                    f.FormClosed += (s, e1) =>
                    {
                        if (MdiChildren.Length == 1)
                        {
                            pic_MdiImage.Visible = true;
                        }
                    };
                    f.Show();
                }
            }
        }
        #endregion

        #endregion

        #region Mdi图片
        private void XtraTabbedMdiManager1_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (pic_MdiImage.Visible)
            {
                pic_MdiImage.Visible = false;
            }
        }
        #endregion Mdi图片

        #region 刷新定时方法

        public async Task RefreshDataAsync()
        {
            await Task.Run(() => { bar_SysTimer.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); });
        }

        #endregion 刷新定时方法
    }


    public class TabbedMdiManager : DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    {
        public TabbedMdiManager() : base()
        {
        }

        public TabbedMdiManager(IContainer container) : base(container)
        {
        }

        public Image BackImage { set; get; } = null;

        protected override void DrawNC(DevExpress.Utils.Drawing.DXPaintEventArgs e)
        {
            if (Pages.Count > 0 || BackImage == null)
            {
                base.DrawNC(e);
            }
            else
            {
                e.Graphics.DrawImage(BackImage, Bounds);
            }
        }

    }

}

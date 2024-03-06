using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoarseFoodErp.Utils.Job;
using CoarseFoodErp.Utils;
using DevExpress.XtraEditors;
using JBaseCommon;
using JCommon.Jot;
using DevExpress.XtraBars;
using JBaseCommon.JBaseForm;
using JCommon;

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
            RegistEvent();
        }

        #endregion 重写加载函数

        #region 注册事件
        private void RegistEvent()
        {
            InitMenu();
            this.xtraTabbedMdiManager1.PageAdded += XtraTabbedMdiManager1_PageAdded;
        }
        #endregion

        #region 初始化菜单
        private void InitMenu()
        {
            foreach (BarItem item in barManager1.Items.Cast<BarItem>())
            {
                if (item is BarLargeButtonItem || item is BarButtonItem || item is SkinDropDownButtonItem)
                {
                    string tag = item.Tag == null ? string.Empty : item.Tag.ToString();
                    item.ItemClick += Item_ItemClick;
                }
            }
        }
        private void Item_ItemClick(object sender, ItemClickEventArgs e)
        {
            ItemClick(e);
        }
        #region ItemClick方法
        private  void ItemClick(ItemClickEventArgs e)
        {
            var menuItem = e.Item is BarLargeButtonItem ? (BarButtonItem)e.Item : (BarButtonItem)e.Item;
            if (menuItem.Tag==null)
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
                        if (this.MdiChildren.Length == 1)
                        {
                            this.pic_MdiImage.Visible = true;
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
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using JCommon.Jot;


namespace JBaseCommon.JBaseForm
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        #region 是否模态窗体

        [Browsable(true)]
        [Description("是否模态窗体(True=ShowDialog,False=Show)"), Category("自定义"), DefaultValue(false)]
        public bool IsModalForm { get; set; }

        #endregion 是否模态窗体

        #region 构造函数

        public BaseForm()
        {
            InitializeComponent();
            SplashScreenManager.ShowForm(this, typeof(LoadingForm), true, true, false);
        }
        #endregion 构造函数

        #region 重载

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            JotConfigService.Tracker.Track(this);
            SplashScreenManager.CloseForm(false, 0, this, false);
        }

        #endregion 重载
    }
}

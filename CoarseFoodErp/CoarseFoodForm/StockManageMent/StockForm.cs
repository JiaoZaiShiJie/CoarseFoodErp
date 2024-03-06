using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JBaseCommon.JBaseForm;

namespace CoarseFoodErp.StockManageMent
{
    public partial class StockForm :BaseForm
    {

        #region 构造函数
        public StockForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 重写OnLoad
        protected override  void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion



    }
}
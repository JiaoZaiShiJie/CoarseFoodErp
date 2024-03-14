using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoarseFoodErp.Utils;
using JBaseCommon.BaseControl;
using JCommon;

namespace CoarseFoodErp.CoarseFoodControl
{
    public partial class StockControl : BaseControl
    {
        public StockControl()
        {
            InitializeComponent();
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataTable func() => SqlSugarHelper.Db.Ado.GetDataTable("select * from SysUser");
            this.InitControl(this.gc_Main, this.gv_Main, func, "KeyUser",true);
        }
    }
}

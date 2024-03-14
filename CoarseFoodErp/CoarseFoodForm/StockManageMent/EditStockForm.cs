using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JBaseCommon.JBaseForm;
using JCommon;

namespace CoarseFoodErp.CoarseFoodForm.StockManageMent
{
    public partial class EditStockForm : BaseEditForm
    {
        public EditStockForm()
        {
            InitializeComponent();
        }
        protected override void PreloadData()
        {
            if (this.Data!=null)
            {
                this.textEdit1.Text = this.Data.DataRowToString("UserName");
                this.textEdit2.Text = this.Data.DataRowToString("UserCode");
            }
        }
    }
}

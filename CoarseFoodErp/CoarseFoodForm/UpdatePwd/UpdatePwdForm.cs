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


namespace CoarseFoodErp.CoarseFoodForm.UpdatePwd
{
    public partial class UpdatePwdForm : BaseEditForm
    {

        #region 构造函数
        public UpdatePwdForm()
        {


            InitializeComponent();
        }
        #endregion

        #region 参数验证
        protected override void SetValidationRule()
        {
            this.SetNotEmptyValidationRule(this.te_Pwd);
            this.SetControlValidationRule(this.te_Pwd, this.te_Pwder);
        }
        #endregion


    }
}
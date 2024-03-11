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
using DevExpress.XtraEditors.DXErrorProvider;

namespace CoarseFoodErp
{
    public partial class testForm : DevExpress.XtraEditors.XtraForm
    {
        private CompareAgainstControlValidationRule compareAgainstControl = new CompareAgainstControlValidationRule();
        public testForm()
        {
            InitializeComponent();
            SetControlValidationRule(this.textEdit1, this.textEdit2);


        }
        #region 与其他控件比较
        public void SetControlValidationRule(Control control, Control control1)
        {
            // 与其他控件对比
            compareAgainstControl = new CompareAgainstControlValidationRule();
            compareAgainstControl.Control = control;
            compareAgainstControl.CompareControlOperator = CompareControlOperator.Equals;
            compareAgainstControl.ErrorText = "必须重复你所填的项目";
            compareAgainstControl.ErrorType = ErrorType.Warning;
            compareAgainstControl.CaseSensitive = false;
            SetValidationRule(control1, compareAgainstControl);
        }
        #endregion
    

        /// <summary>
        /// 控件设置验证规则
        /// </summary>
        /// <param name="control"></param>
        /// <param name="rule"></param>
        public void SetValidationRule(Control control, ValidationRule rule)
        {
            this.dxValidationProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            this.dxValidationProvider1.SetValidationRule(control, rule);
        }
    }
}
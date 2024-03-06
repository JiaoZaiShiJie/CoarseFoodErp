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
using DevExpress.XtraWaitForm;

namespace JBaseCommon
{
    public partial class LoadingForm : WaitForm
    {
        /// <summary>
        /// 是否改变鼠标样式
        /// </summary>
        public static bool fIsChangeCursor = true;
        public LoadingForm()
        {
            InitializeComponent();
            this.progressPanel1.AutoHeight = true;
        }

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.progressPanel1.Caption = caption;
        }

        public override void SetDescription(string description)
        {
            base.SetDescription(description + ", 请稍后 ...");
            this.progressPanel1.Description = description + ", 请稍后 ...";
        }

    }
}
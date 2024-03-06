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

namespace JBaseCommon.JBaseForm
{
    public partial class BaseEditForm : BaseForm
    {

        #region 构造函数
        public BaseEditForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RegistEvent();
        }


        #region 注册事件
        private void RegistEvent()
        {
            this.sb_Save.Click += Sb_Save_Click;
            this.sb_Cancel.Click += Sb_Cancel_Click;
        }

        #region 取消按钮
        private void Sb_Cancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        #endregion


        #region 保存按钮
        private void Sb_Save_Click(object sender, EventArgs e)
        {
            Save();

        }
        #endregion


        #region 虚方法

        #region 保存方法
        protected virtual void Save()
        {
           DialogResult dialog= XtraMessageBox.Show("保存数据成功", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                this.Close();
            }
           
        }
        #endregion

        #region 取消方法
        protected virtual void Cancel()
        {
            this.Close();
        }
        #endregion
        #endregion


        #endregion
    }
}
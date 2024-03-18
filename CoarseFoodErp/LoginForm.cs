using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoarseFoodErp.Entity.Model;
using CoarseFoodErp.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using JBaseCommon.Utils;
using JCommon;
using JCommon.Jot;

namespace CoarseFoodErp
{
    public partial class LoginForm : XtraForm
    {
        public bool Logout { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RegisterEvent();
            await GetRemoberAuto();


        }
        #region 注册事件

        private void RegisterEvent()
        {
            this.sb_Login.Click += Sb_Login_Click; ;
            this.sb_Cancel.Click += Sb_Cancel_Click; ;
            this.ck_AutoLogin.CheckedChanged += Ck_AutoLogin_CheckedChanged;
            this.labelControl3.Parent = pictureEdit1;
            this.te_Pwd.KeyDown += Te_Pwd_KeyDown;
            this.FormClosed += LoginForm_FormClosed;
        }

        #endregion RegisterEvent
        #region 关闭窗体后

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            System.Environment.Exit(0);
        }

        #endregion 关闭窗体后

        #region 回车登录

        private void Te_Pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.sb_Login.PerformClick();
            }
        }

        #endregion 回车登录

        #region 取消登录

        private void Sb_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = XtraMessageBox.Show(this, "您确定要退出程序?", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                this.sb_Login.Focus();
            }
        }

        #endregion 取消登录

        #region 登录

        private void LoginMethod()
        {
            if (string.IsNullOrEmpty(this.te_Pwd.Text) && string.IsNullOrEmpty(this.te_UserName.Text))
            {
                XtraMessageBox.Show(this, "账号和密码不能为空", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.te_UserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.te_UserName.Text))
            {
                XtraMessageBox.Show(this, "账号不能为空", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.te_UserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(this.te_Pwd.Text))
            {
                XtraMessageBox.Show(this, "密码不能为空", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.te_Pwd.Focus();
                return;
            }
            var dataCount = SqlSugarHelper.Db.Queryable<SysUser>().Where(it => it.LoginName == this.te_UserName.Text.Trim() && it.LoginPwd == this.te_Pwd.Text.Trim()).ToList();
            if (dataCount != null && dataCount.Count > 0)
            {
                if (dataCount[0].FDisabled.ToString() == "0")
                {
                    XtraMessageBox.Show(this, "该账号已被禁用,请联系超级管理员", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.te_UserName.Focus();
                    return;
                }
                MyKey.KeyUser = dataCount[0].KeyUser.ToString() ;
                MyKey.UserName = dataCount[0].UserName;
                if (!string.IsNullOrEmpty(dataCount[0].Picture))
                {
                    MyKey.image = dataCount[0].Picture.Base64ToImage();
                }
                RemoberAuto();
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                XtraMessageBox.Show(this, "账号密码错误", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.te_UserName.Focus();
                return;
            }
        }

        private void Sb_Login_Click(object sender, EventArgs e)
        {
            LoginMethod();
        }

        #endregion 登录

        #region 记住密码/自动登录设置

        private async Task GetRemoberAuto()
        {
            MyKey.RermberPwd = (bool)JotConfigService.GetData(E_SysKey.账号设置, E_SysKey_Type.记住密码, false);
            MyKey.AutoLogin = (bool)JotConfigService.GetData(E_SysKey.账号设置, E_SysKey_Type.自动登录, false);
            this.ck_AutoLogin.Checked = MyKey.AutoLogin;
            this.ck_RemberPwd.Checked = MyKey.RermberPwd;
            if (MyKey.RermberPwd)
            {
                this.te_UserName.Text = JotConfigService.GetData(E_SysKey.账号设置, E_SysKey_Type.账号, string.Empty).ToString();
                this.te_Pwd.Text = JotConfigService.GetData(E_SysKey.账号设置, E_SysKey_Type.密码, string.Empty).ToString();
                this.sb_Login.Select();
                if (MyKey.AutoLogin && !Logout)
                {
                    await Task.Delay(500);
                    LoginMethod();
                }
            }
        }

        private void RemoberAuto()
        {
            if (this.ck_RemberPwd.Checked)
            {
                JotConfigService.SetData(E_SysKey.账号设置, E_SysKey_Type.账号, this.te_UserName.Text.Trim());
                JotConfigService.SetData(E_SysKey.账号设置, E_SysKey_Type.密码, this.te_Pwd.Text.Trim());
            }
            JotConfigService.SetData(E_SysKey.账号设置, E_SysKey_Type.记住密码, this.ck_RemberPwd.Checked);
            JotConfigService.SetData(E_SysKey.账号设置, E_SysKey_Type.自动登录, this.ck_AutoLogin.Checked);
        }

        #endregion 记住密码/自动登录设置

        #region 自动登录事件

        private void Ck_AutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.ck_RemberPwd.CheckState = this.ck_AutoLogin.Checked ? CheckState.Checked : CheckState.Unchecked;
        }

        #endregion 自动登录事件

    }
}

namespace CoarseFoodErp
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.sb_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.sb_Login = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ck_AutoLogin = new DevExpress.XtraEditors.CheckEdit();
            this.ck_RemberPwd = new DevExpress.XtraEditors.CheckEdit();
            this.te_Pwd = new DevExpress.XtraEditors.TextEdit();
            this.te_UserName = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_AutoLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_RemberPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Pwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("幼圆", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.ImageOptions.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            this.labelControl3.Location = new System.Drawing.Point(473, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(235, 57);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "出入库系统 V1.0";
            // 
            // sb_Cancel
            // 
            this.sb_Cancel.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.sb_Cancel.Appearance.Options.UseFont = true;
            this.sb_Cancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_Cancel.ImageOptions.SvgImage")));
            this.sb_Cancel.Location = new System.Drawing.Point(574, 319);
            this.sb_Cancel.Name = "sb_Cancel";
            this.sb_Cancel.Size = new System.Drawing.Size(118, 47);
            this.sb_Cancel.TabIndex = 18;
            this.sb_Cancel.Text = "取消";
            // 
            // sb_Login
            // 
            this.sb_Login.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sb_Login.Appearance.Options.UseFont = true;
            this.sb_Login.ImageOptions.SvgImage = global::CoarseFoodErp.Properties.Resources.bo_customer4;
            this.sb_Login.Location = new System.Drawing.Point(441, 319);
            this.sb_Login.Name = "sb_Login";
            this.sb_Login.Size = new System.Drawing.Size(113, 47);
            this.sb_Login.TabIndex = 15;
            this.sb_Login.Text = "登录";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(418, 233);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 34);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "密码:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(417, 168);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 34);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "账号:";
            // 
            // ck_AutoLogin
            // 
            this.ck_AutoLogin.Location = new System.Drawing.Point(600, 284);
            this.ck_AutoLogin.Name = "ck_AutoLogin";
            this.ck_AutoLogin.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.ck_AutoLogin.Properties.Appearance.Options.UseBackColor = true;
            this.ck_AutoLogin.Properties.Caption = "自动登录";
            this.ck_AutoLogin.Size = new System.Drawing.Size(75, 20);
            this.ck_AutoLogin.TabIndex = 17;
            // 
            // ck_RemberPwd
            // 
            this.ck_RemberPwd.Location = new System.Drawing.Point(479, 284);
            this.ck_RemberPwd.Name = "ck_RemberPwd";
            this.ck_RemberPwd.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.ck_RemberPwd.Properties.Appearance.Options.UseBackColor = true;
            this.ck_RemberPwd.Properties.Caption = "记住密码";
            this.ck_RemberPwd.Size = new System.Drawing.Size(75, 20);
            this.ck_RemberPwd.TabIndex = 16;
            // 
            // te_Pwd
            // 
            this.te_Pwd.Location = new System.Drawing.Point(473, 233);
            this.te_Pwd.Name = "te_Pwd";
            this.te_Pwd.Properties.AutoHeight = false;
            this.te_Pwd.Properties.PasswordChar = '*';
            this.te_Pwd.Size = new System.Drawing.Size(219, 36);
            this.te_Pwd.TabIndex = 13;
            // 
            // te_UserName
            // 
            this.te_UserName.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.te_UserName.Location = new System.Drawing.Point(473, 168);
            this.te_UserName.Name = "te_UserName";
            this.te_UserName.Properties.AutoHeight = false;
            this.te_UserName.Size = new System.Drawing.Size(219, 34);
            this.te_UserName.TabIndex = 11;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.EditValue = global::CoarseFoodErp.Properties.Resources.login_bg;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(800, 450);
            this.pictureEdit1.TabIndex = 1;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sb_Cancel);
            this.Controls.Add(this.ck_AutoLogin);
            this.Controls.Add(this.ck_RemberPwd);
            this.Controls.Add(this.sb_Login);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.te_Pwd);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.te_UserName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.ck_AutoLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_RemberPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Pwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton sb_Cancel;
        private DevExpress.XtraEditors.CheckEdit ck_AutoLogin;
        private DevExpress.XtraEditors.CheckEdit ck_RemberPwd;
        private DevExpress.XtraEditors.SimpleButton sb_Login;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit te_Pwd;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit te_UserName;
    }
}
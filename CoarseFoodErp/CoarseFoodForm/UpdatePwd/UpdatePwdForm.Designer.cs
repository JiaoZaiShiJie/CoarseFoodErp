namespace CoarseFoodErp.CoarseFoodForm.UpdatePwd
{
    partial class UpdatePwdForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePwdForm));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.te_Pwder = new DevExpress.XtraEditors.TextEdit();
            this.te_Pwd = new DevExpress.XtraEditors.TextEdit();
            this.lb_pwder = new DevExpress.XtraEditors.LabelControl();
            this.lb_pwd = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_Pwder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Pwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sb_Cancel
            // 
            this.sb_Cancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_Cancel.ImageOptions.SvgImage")));
            this.sb_Cancel.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_Cancel.Location = new System.Drawing.Point(213, 17);
            // 
            // sb_Save
            // 
            this.sb_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_Save.ImageOptions.SvgImage")));
            this.sb_Save.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_Save.Location = new System.Drawing.Point(109, 17);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.te_Pwder);
            this.panelControl2.Controls.Add(this.te_Pwd);
            this.panelControl2.Controls.Add(this.lb_pwder);
            this.panelControl2.Controls.Add(this.lb_pwd);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(410, 176);
            this.panelControl2.TabIndex = 2;
            // 
            // te_Pwder
            // 
            this.te_Pwder.Location = new System.Drawing.Point(177, 85);
            this.te_Pwder.Name = "te_Pwder";
            this.te_Pwder.Properties.PasswordChar = '*';
            this.te_Pwder.Size = new System.Drawing.Size(122, 20);
            this.te_Pwder.TabIndex = 3;
            // 
            // te_Pwd
            // 
            this.te_Pwd.Location = new System.Drawing.Point(177, 43);
            this.te_Pwd.Name = "te_Pwd";
            this.te_Pwd.Properties.PasswordChar = '*';
            this.te_Pwd.Size = new System.Drawing.Size(122, 20);
            this.te_Pwd.TabIndex = 2;
            // 
            // lb_pwder
            // 
            this.lb_pwder.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_pwder.Location = new System.Drawing.Point(112, 88);
            this.lb_pwder.Name = "lb_pwder";
            this.lb_pwder.Size = new System.Drawing.Size(48, 14);
            this.lb_pwder.TabIndex = 1;
            this.lb_pwder.Text = "重复密码";
            // 
            // lb_pwd
            // 
            this.lb_pwd.Location = new System.Drawing.Point(132, 50);
            this.lb_pwd.Name = "lb_pwd";
            this.lb_pwd.Size = new System.Drawing.Size(28, 14);
            this.lb_pwd.TabIndex = 0;
            this.lb_pwd.Text = "密码:";
            // 
            // UpdatePwdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 244);
            this.Controls.Add(this.panelControl2);
            this.Name = "UpdatePwdForm";
            this.Text = "修改密码";
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.te_Pwder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.te_Pwd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit te_Pwder;
        private DevExpress.XtraEditors.TextEdit te_Pwd;
        private DevExpress.XtraEditors.LabelControl lb_pwder;
        private DevExpress.XtraEditors.LabelControl lb_pwd;
    }
}
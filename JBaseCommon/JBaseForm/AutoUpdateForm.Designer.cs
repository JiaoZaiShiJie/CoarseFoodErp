namespace JBaseCommon.JBaseForm
{
    partial class AutoUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoUpdateForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sb_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.sb_Update = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.lb_CurrentVer = new DevExpress.XtraEditors.LabelControl();
            this.lb_UpDateVer = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sb_Cancel);
            this.panelControl1.Controls.Add(this.sb_Update);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 331);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(662, 71);
            this.panelControl1.TabIndex = 0;
            // 
            // sb_Cancel
            // 
            this.sb_Cancel.ImageOptions.SvgImage = global::JBaseCommon.Properties.Resources.close;
            this.sb_Cancel.Location = new System.Drawing.Point(352, 16);
            this.sb_Cancel.Name = "sb_Cancel";
            this.sb_Cancel.Size = new System.Drawing.Size(116, 43);
            this.sb_Cancel.TabIndex = 1;
            this.sb_Cancel.Text = "取消";
            // 
            // sb_Update
            // 
            this.sb_Update.ImageOptions.SvgImage = global::JBaseCommon.Properties.Resources.previous;
            this.sb_Update.Location = new System.Drawing.Point(194, 16);
            this.sb_Update.Name = "sb_Update";
            this.sb_Update.Size = new System.Drawing.Size(116, 43);
            this.sb_Update.TabIndex = 0;
            this.sb_Update.Text = "更新";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.lb_UpDateVer);
            this.panelControl3.Controls.Add(this.lb_CurrentVer);
            this.panelControl3.Controls.Add(this.pictureEdit1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(662, 173);
            this.panelControl3.TabIndex = 4;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(2, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Size = new System.Drawing.Size(658, 169);
            this.pictureEdit1.TabIndex = 6;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.memoEdit1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 173);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(662, 158);
            this.panelControl2.TabIndex = 5;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.Location = new System.Drawing.Point(2, 2);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memoEdit1.Properties.Appearance.Options.UseFont = true;
            this.memoEdit1.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.memoEdit1.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.memoEdit1.Properties.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Size = new System.Drawing.Size(658, 154);
            this.memoEdit1.TabIndex = 2;
            // 
            // lb_CurrentVer
            // 
            this.lb_CurrentVer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lb_CurrentVer.Appearance.Font = new System.Drawing.Font("华文彩云", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_CurrentVer.Appearance.Options.UseBackColor = true;
            this.lb_CurrentVer.Appearance.Options.UseFont = true;
            this.lb_CurrentVer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_CurrentVer.Location = new System.Drawing.Point(4, 61);
            this.lb_CurrentVer.Name = "lb_CurrentVer";
            this.lb_CurrentVer.Size = new System.Drawing.Size(197, 52);
            this.lb_CurrentVer.TabIndex = 7;
            this.lb_CurrentVer.Text = "当前版本号:";
            // 
            // lb_UpDateVer
            // 
            this.lb_UpDateVer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lb_UpDateVer.Appearance.Font = new System.Drawing.Font("华文彩云", 15F);
            this.lb_UpDateVer.Appearance.Options.UseBackColor = true;
            this.lb_UpDateVer.Appearance.Options.UseFont = true;
            this.lb_UpDateVer.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lb_UpDateVer.Location = new System.Drawing.Point(449, 61);
            this.lb_UpDateVer.Name = "lb_UpDateVer";
            this.lb_UpDateVer.Size = new System.Drawing.Size(210, 52);
            this.lb_UpDateVer.TabIndex = 8;
            this.lb_UpDateVer.Text = "当前版本号:";
            // 
            // AutoUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 402);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.DoubleBuffered = true;
            this.IconOptions.SvgImage = global::JBaseCommon.Properties.Resources.charttype_spline3d;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动更新";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton sb_Cancel;
        private DevExpress.XtraEditors.SimpleButton sb_Update;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LabelControl lb_UpDateVer;
        private DevExpress.XtraEditors.LabelControl lb_CurrentVer;
    }
}
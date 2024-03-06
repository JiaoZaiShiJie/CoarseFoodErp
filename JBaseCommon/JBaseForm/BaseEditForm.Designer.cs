namespace JBaseCommon.JBaseForm
{
    partial class BaseEditForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEditForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.sb_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.sb_Save = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sb_Cancel);
            this.panelControl1.Controls.Add(this.sb_Save);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 306);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(618, 68);
            this.panelControl1.TabIndex = 1;
            // 
            // sb_Cancel
            // 
            this.sb_Cancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_Cancel.ImageOptions.SvgImage")));
            this.sb_Cancel.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_Cancel.Location = new System.Drawing.Point(304, 17);
            this.sb_Cancel.Name = "sb_Cancel";
            this.sb_Cancel.Size = new System.Drawing.Size(88, 39);
            this.sb_Cancel.TabIndex = 1;
            this.sb_Cancel.Text = "取消(&Esc)";
            // 
            // sb_Save
            // 
            this.sb_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_Save.ImageOptions.SvgImage")));
            this.sb_Save.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_Save.Location = new System.Drawing.Point(200, 17);
            this.sb_Save.Name = "sb_Save";
            this.sb_Save.Size = new System.Drawing.Size(88, 39);
            this.sb_Save.TabIndex = 0;
            this.sb_Save.Text = "保存(&S)";
            // 
            // BaseEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 374);
            this.Controls.Add(this.panelControl1);
            this.IsModalForm = true;
            this.MaximizeBox = false;
            this.Name = "BaseEditForm";
            this.Text = "BaseEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        protected DevExpress.XtraEditors.SimpleButton sb_Cancel;
        protected DevExpress.XtraEditors.SimpleButton sb_Save;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}
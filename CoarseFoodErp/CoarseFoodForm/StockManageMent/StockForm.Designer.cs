namespace CoarseFoodErp.StockManageMent
{
    partial class StockForm
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
            JBaseCommon.Utils.ButtonVisible buttonVisible1 = new JBaseCommon.Utils.ButtonVisible();
            this.uc_StockControl = new CoarseFoodErp.CoarseFoodControl.StockControl();
            this.SuspendLayout();
            // 
            // uc_StockControl
            // 
            buttonVisible1.IsShowAddButton = true;
            buttonVisible1.IsShowDeleteButton = true;
            buttonVisible1.IsShowEditButton = true;
            buttonVisible1.IsShowExportButton = true;
            buttonVisible1.IsShowFirstButton = true;
            buttonVisible1.IsShowLastButton = true;
            buttonVisible1.IsShowNextButton = true;
            buttonVisible1.IsShowPrevButton = true;
            buttonVisible1.IsShowRefreshButton = true;
            buttonVisible1.IsShowSelectButton = false;
            this.uc_StockControl.ButtonVisible = buttonVisible1;
            this.uc_StockControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_StockControl.GridRefsh = JBaseCommon.Utils.CustomGridRefshEnum.末行;
            this.uc_StockControl.HideContextMenu = false;
            this.uc_StockControl.Location = new System.Drawing.Point(0, 0);
            this.uc_StockControl.Margin = new System.Windows.Forms.Padding(4);
            this.uc_StockControl.Name = "uc_StockControl";
            this.uc_StockControl.PanelFirstVisible = false;
            this.uc_StockControl.Size = new System.Drawing.Size(933, 525);
            this.uc_StockControl.TabIndex = 0;
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.uc_StockControl);
            this.Name = "StockForm";
            this.Text = "粮情监控";
            this.ResumeLayout(false);

        }

        #endregion

        private CoarseFoodControl.StockControl stockControl1;
        private CoarseFoodControl.StockControl uc_StockControl;
    }
}
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
            this.stockControl1 = new CoarseFoodErp.CoarseFoodControl.StockControl();
            this.SuspendLayout();
            // 
            // stockControl1
            // 
            this.stockControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockControl1.Location = new System.Drawing.Point(0, 0);
            this.stockControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stockControl1.Name = "stockControl1";
            this.stockControl1.Size = new System.Drawing.Size(933, 525);
            this.stockControl1.TabIndex = 0;
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 525);
            this.Controls.Add(this.stockControl1);
            this.Name = "StockForm";
            this.Text = "粮情监控";
            this.ResumeLayout(false);

        }

        #endregion

        private CoarseFoodControl.StockControl stockControl1;
    }
}
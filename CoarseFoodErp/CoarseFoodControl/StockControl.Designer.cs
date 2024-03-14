namespace CoarseFoodErp.CoarseFoodControl
{
    partial class StockControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gc_Main = new DevExpress.XtraGrid.GridControl();
            this.gv_Main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panel_First)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Main)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_First
            // 
            this.panel_First.Location = new System.Drawing.Point(0, 44);
            this.panel_First.Size = new System.Drawing.Size(872, 63);
            // 
            // gc_Main
            // 
            this.gc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Main.Location = new System.Drawing.Point(0, 107);
            this.gc_Main.MainView = this.gv_Main;
            this.gc_Main.Name = "gc_Main";
            this.gc_Main.Size = new System.Drawing.Size(872, 394);
            this.gc_Main.TabIndex = 3;
            this.gc_Main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Main});
            // 
            // gv_Main
            // 
            this.gv_Main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gv_Main.GridControl = this.gc_Main;
            this.gv_Main.Name = "gv_Main";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "主键key";
            this.gridColumn1.FieldName = "KeyUser";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // StockControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gc_Main);
            this.Name = "StockControl";
            this.Size = new System.Drawing.Size(872, 501);
            this.Controls.SetChildIndex(this.panel_First, 0);
            this.Controls.SetChildIndex(this.gc_Main, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panel_First)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc_Main;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Main;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}

namespace JBaseCommon.BaseControl
{
    partial class BaseControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseControl));
            this.panel_First = new DevExpress.XtraEditors.PanelControl();
            this.pan_Top = new DevExpress.XtraEditors.PanelControl();
            this.pan_ExportExcel = new DevExpress.XtraEditors.PanelControl();
            this.sb_ExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.pan_Refresh = new DevExpress.XtraEditors.PanelControl();
            this.sb_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.pan_Delete = new DevExpress.XtraEditors.PanelControl();
            this.sb_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.pan_Edit = new DevExpress.XtraEditors.PanelControl();
            this.sb_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.pan_Add = new DevExpress.XtraEditors.PanelControl();
            this.sb_Add = new DevExpress.XtraEditors.SimpleButton();
            this.pan_MoveLast = new DevExpress.XtraEditors.PanelControl();
            this.sb_MoveLast = new DevExpress.XtraEditors.SimpleButton();
            this.pan_MoveNext = new DevExpress.XtraEditors.PanelControl();
            this.sb_MoveNext = new DevExpress.XtraEditors.SimpleButton();
            this.pan_MovePrev = new DevExpress.XtraEditors.PanelControl();
            this.sb_MovePrev = new DevExpress.XtraEditors.SimpleButton();
            this.pan_MoveFirst = new DevExpress.XtraEditors.PanelControl();
            this.sb_MoveFirst = new DevExpress.XtraEditors.SimpleButton();
            this.cms_Tools = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panel_First)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pan_Top)).BeginInit();
            this.pan_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pan_ExportExcel)).BeginInit();
            this.pan_ExportExcel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pan_Refresh)).BeginInit();
            this.pan_Refresh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pan_Delete)).BeginInit();
            this.pan_Delete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pan_Edit)).BeginInit();
            this.pan_Edit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pan_Add)).BeginInit();
            this.pan_Add.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pan_MoveLast)).BeginInit();
            this.pan_MoveLast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pan_MoveNext)).BeginInit();
            this.pan_MoveNext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pan_MovePrev)).BeginInit();
            this.pan_MovePrev.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pan_MoveFirst)).BeginInit();
            this.pan_MoveFirst.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_First
            // 
            this.panel_First.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_First.Location = new System.Drawing.Point(0, 0);
            this.panel_First.Name = "panel_First";
            this.panel_First.Size = new System.Drawing.Size(744, 63);
            this.panel_First.TabIndex = 1;
            // 
            // pan_Top
            // 
            this.pan_Top.Controls.Add(this.pan_ExportExcel);
            this.pan_Top.Controls.Add(this.pan_Refresh);
            this.pan_Top.Controls.Add(this.pan_Delete);
            this.pan_Top.Controls.Add(this.pan_Edit);
            this.pan_Top.Controls.Add(this.pan_Add);
            this.pan_Top.Controls.Add(this.pan_MoveLast);
            this.pan_Top.Controls.Add(this.pan_MoveNext);
            this.pan_Top.Controls.Add(this.pan_MovePrev);
            this.pan_Top.Controls.Add(this.pan_MoveFirst);
            this.pan_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_Top.Location = new System.Drawing.Point(0, 63);
            this.pan_Top.Name = "pan_Top";
            this.pan_Top.Size = new System.Drawing.Size(744, 44);
            this.pan_Top.TabIndex = 2;
            // 
            // pan_ExportExcel
            // 
            this.pan_ExportExcel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pan_ExportExcel.Controls.Add(this.sb_ExportExcel);
            this.pan_ExportExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_ExportExcel.Location = new System.Drawing.Point(605, 2);
            this.pan_ExportExcel.Name = "pan_ExportExcel";
            this.pan_ExportExcel.Size = new System.Drawing.Size(76, 40);
            this.pan_ExportExcel.TabIndex = 16;
            // 
            // sb_ExportExcel
            // 
            this.sb_ExportExcel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sb_ExportExcel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_ExportExcel.ImageOptions.SvgImage")));
            this.sb_ExportExcel.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_ExportExcel.Location = new System.Drawing.Point(0, 0);
            this.sb_ExportExcel.Name = "sb_ExportExcel";
            this.sb_ExportExcel.Size = new System.Drawing.Size(70, 40);
            this.sb_ExportExcel.TabIndex = 4;
            this.sb_ExportExcel.Text = "导出";
            // 
            // pan_Refresh
            // 
            this.pan_Refresh.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pan_Refresh.Controls.Add(this.sb_Refresh);
            this.pan_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_Refresh.Location = new System.Drawing.Point(530, 2);
            this.pan_Refresh.Name = "pan_Refresh";
            this.pan_Refresh.Size = new System.Drawing.Size(75, 40);
            this.pan_Refresh.TabIndex = 15;
            // 
            // sb_Refresh
            // 
            this.sb_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.sb_Refresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_Refresh.ImageOptions.SvgImage")));
            this.sb_Refresh.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_Refresh.Location = new System.Drawing.Point(0, 0);
            this.sb_Refresh.Name = "sb_Refresh";
            this.sb_Refresh.Size = new System.Drawing.Size(70, 40);
            this.sb_Refresh.TabIndex = 3;
            this.sb_Refresh.Text = "刷新";
            // 
            // pan_Delete
            // 
            this.pan_Delete.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pan_Delete.Controls.Add(this.sb_Delete);
            this.pan_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_Delete.Location = new System.Drawing.Point(454, 2);
            this.pan_Delete.Name = "pan_Delete";
            this.pan_Delete.Size = new System.Drawing.Size(76, 40);
            this.pan_Delete.TabIndex = 13;
            this.pan_Delete.Visible = false;
            // 
            // sb_Delete
            // 
            this.sb_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sb_Delete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_Delete.ImageOptions.SvgImage")));
            this.sb_Delete.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_Delete.Location = new System.Drawing.Point(0, 0);
            this.sb_Delete.Name = "sb_Delete";
            this.sb_Delete.Size = new System.Drawing.Size(70, 40);
            this.sb_Delete.TabIndex = 4;
            this.sb_Delete.Text = "删除";
            // 
            // pan_Edit
            // 
            this.pan_Edit.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pan_Edit.Controls.Add(this.sb_Edit);
            this.pan_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_Edit.Location = new System.Drawing.Point(378, 2);
            this.pan_Edit.Name = "pan_Edit";
            this.pan_Edit.Size = new System.Drawing.Size(76, 40);
            this.pan_Edit.TabIndex = 12;
            // 
            // sb_Edit
            // 
            this.sb_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.sb_Edit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_Edit.ImageOptions.SvgImage")));
            this.sb_Edit.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_Edit.Location = new System.Drawing.Point(0, 0);
            this.sb_Edit.Name = "sb_Edit";
            this.sb_Edit.Size = new System.Drawing.Size(70, 40);
            this.sb_Edit.TabIndex = 4;
            this.sb_Edit.Text = "编辑";
            // 
            // pan_Add
            // 
            this.pan_Add.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pan_Add.Controls.Add(this.sb_Add);
            this.pan_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_Add.Location = new System.Drawing.Point(302, 2);
            this.pan_Add.Name = "pan_Add";
            this.pan_Add.Size = new System.Drawing.Size(76, 40);
            this.pan_Add.TabIndex = 11;
            // 
            // sb_Add
            // 
            this.sb_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.sb_Add.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_Add.ImageOptions.SvgImage")));
            this.sb_Add.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_Add.Location = new System.Drawing.Point(0, 0);
            this.sb_Add.Name = "sb_Add";
            this.sb_Add.Size = new System.Drawing.Size(70, 40);
            this.sb_Add.TabIndex = 4;
            this.sb_Add.Text = "增加";
            // 
            // pan_MoveLast
            // 
            this.pan_MoveLast.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pan_MoveLast.Controls.Add(this.sb_MoveLast);
            this.pan_MoveLast.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_MoveLast.Location = new System.Drawing.Point(226, 2);
            this.pan_MoveLast.Name = "pan_MoveLast";
            this.pan_MoveLast.Size = new System.Drawing.Size(76, 40);
            this.pan_MoveLast.TabIndex = 8;
            // 
            // sb_MoveLast
            // 
            this.sb_MoveLast.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_MoveLast.ImageOptions.SvgImage")));
            this.sb_MoveLast.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_MoveLast.Location = new System.Drawing.Point(0, 0);
            this.sb_MoveLast.Name = "sb_MoveLast";
            this.sb_MoveLast.Size = new System.Drawing.Size(70, 40);
            this.sb_MoveLast.TabIndex = 5;
            this.sb_MoveLast.Text = "末条";
            // 
            // pan_MoveNext
            // 
            this.pan_MoveNext.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pan_MoveNext.Controls.Add(this.sb_MoveNext);
            this.pan_MoveNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_MoveNext.Location = new System.Drawing.Point(151, 2);
            this.pan_MoveNext.Name = "pan_MoveNext";
            this.pan_MoveNext.Size = new System.Drawing.Size(75, 40);
            this.pan_MoveNext.TabIndex = 7;
            // 
            // sb_MoveNext
            // 
            this.sb_MoveNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.sb_MoveNext.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_MoveNext.ImageOptions.SvgImage")));
            this.sb_MoveNext.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_MoveNext.Location = new System.Drawing.Point(0, 0);
            this.sb_MoveNext.Name = "sb_MoveNext";
            this.sb_MoveNext.Size = new System.Drawing.Size(70, 40);
            this.sb_MoveNext.TabIndex = 2;
            this.sb_MoveNext.Text = "下一条";
            // 
            // pan_MovePrev
            // 
            this.pan_MovePrev.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pan_MovePrev.Controls.Add(this.sb_MovePrev);
            this.pan_MovePrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_MovePrev.Location = new System.Drawing.Point(76, 2);
            this.pan_MovePrev.Name = "pan_MovePrev";
            this.pan_MovePrev.Size = new System.Drawing.Size(75, 40);
            this.pan_MovePrev.TabIndex = 6;
            this.pan_MovePrev.Visible = false;
            // 
            // sb_MovePrev
            // 
            this.sb_MovePrev.Dock = System.Windows.Forms.DockStyle.Left;
            this.sb_MovePrev.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_MovePrev.ImageOptions.SvgImage")));
            this.sb_MovePrev.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_MovePrev.Location = new System.Drawing.Point(0, 0);
            this.sb_MovePrev.Name = "sb_MovePrev";
            this.sb_MovePrev.Size = new System.Drawing.Size(70, 40);
            this.sb_MovePrev.TabIndex = 1;
            this.sb_MovePrev.Text = "上一条";
            // 
            // pan_MoveFirst
            // 
            this.pan_MoveFirst.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pan_MoveFirst.Controls.Add(this.sb_MoveFirst);
            this.pan_MoveFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_MoveFirst.Location = new System.Drawing.Point(2, 2);
            this.pan_MoveFirst.Name = "pan_MoveFirst";
            this.pan_MoveFirst.Size = new System.Drawing.Size(74, 40);
            this.pan_MoveFirst.TabIndex = 0;
            // 
            // sb_MoveFirst
            // 
            this.sb_MoveFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.sb_MoveFirst.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("sb_MoveFirst.ImageOptions.SvgImage")));
            this.sb_MoveFirst.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.sb_MoveFirst.Location = new System.Drawing.Point(0, 0);
            this.sb_MoveFirst.Name = "sb_MoveFirst";
            this.sb_MoveFirst.Size = new System.Drawing.Size(70, 40);
            this.sb_MoveFirst.TabIndex = 0;
            this.sb_MoveFirst.Text = "首条";
            // 
            // cms_Tools
            // 
            this.cms_Tools.Name = "cms_Tools";
            this.cms_Tools.Size = new System.Drawing.Size(61, 4);
            // 
            // BaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pan_Top);
            this.Controls.Add(this.panel_First);
            this.DoubleBuffered = true;
            this.Name = "BaseControl";
            this.Size = new System.Drawing.Size(744, 495);
            ((System.ComponentModel.ISupportInitialize)(this.panel_First)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pan_Top)).EndInit();
            this.pan_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pan_ExportExcel)).EndInit();
            this.pan_ExportExcel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pan_Refresh)).EndInit();
            this.pan_Refresh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pan_Delete)).EndInit();
            this.pan_Delete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pan_Edit)).EndInit();
            this.pan_Edit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pan_Add)).EndInit();
            this.pan_Add.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pan_MoveLast)).EndInit();
            this.pan_MoveLast.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pan_MoveNext)).EndInit();
            this.pan_MoveNext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pan_MovePrev)).EndInit();
            this.pan_MovePrev.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pan_MoveFirst)).EndInit();
            this.pan_MoveFirst.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraEditors.PanelControl panel_First;
        private DevExpress.XtraEditors.PanelControl pan_Top;
        private DevExpress.XtraEditors.PanelControl pan_ExportExcel;
        private DevExpress.XtraEditors.SimpleButton sb_ExportExcel;
        private DevExpress.XtraEditors.PanelControl pan_Refresh;
        private DevExpress.XtraEditors.SimpleButton sb_Refresh;
        private DevExpress.XtraEditors.PanelControl pan_Delete;
        private DevExpress.XtraEditors.SimpleButton sb_Delete;
        private DevExpress.XtraEditors.PanelControl pan_Edit;
        private DevExpress.XtraEditors.SimpleButton sb_Edit;
        private DevExpress.XtraEditors.PanelControl pan_Add;
        private DevExpress.XtraEditors.SimpleButton sb_Add;
        private DevExpress.XtraEditors.PanelControl pan_MoveLast;
        private DevExpress.XtraEditors.SimpleButton sb_MoveLast;
        private DevExpress.XtraEditors.PanelControl pan_MoveNext;
        private DevExpress.XtraEditors.SimpleButton sb_MoveNext;
        private DevExpress.XtraEditors.PanelControl pan_MovePrev;
        private DevExpress.XtraEditors.SimpleButton sb_MovePrev;
        private DevExpress.XtraEditors.PanelControl pan_MoveFirst;
        private DevExpress.XtraEditors.SimpleButton sb_MoveFirst;
        private System.Windows.Forms.ContextMenuStrip cms_Tools;
    }
}

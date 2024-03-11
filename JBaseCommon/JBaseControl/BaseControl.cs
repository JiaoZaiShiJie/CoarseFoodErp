using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using JBaseCommon.Utils;

namespace JBaseCommon.BaseControl
{
    public partial class BaseControl : UserControl
    {
        #region 重写DesignModel
        protected new bool DesignMode
        {
            get
            {
                bool returnFlag = false;
#if DEBUG
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    returnFlag = true;
                else if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper().Equals("DEVENV"))
                    returnFlag = true;
#endif
                return returnFlag;
            }
        }
        #endregion

        #region 属性

        #region GridControl And GridView

        private GridControl fGridControl;
        private GridView fGridView;

        #endregion GridControl And GridView

        #region 表数据

        private DataTable fTableData;

        [Browsable(false)]
        public DataTable TableData
        {
            get { return fTableData; }
        }

        #endregion 表数据

        #region 是否显示自动过滤行

        private bool isShowAutoFilterRow = true;

        [DefaultValue(true), Description("用于是否显示自动过滤行")]
        public bool IsShowAutoFilterRow
        {
            get
            {
                return isShowAutoFilterRow;
            }

            set
            {
                isShowAutoFilterRow = value;
                if (fGridView != null)
                {
                    fGridView.OptionsView.ShowAutoFilterRow = isShowAutoFilterRow;
                }
            }
        }

        #endregion 是否显示自动过滤行

        #region 选中行

        [Browsable(false)]
        [DefaultValue(false), Description("用于获取选中行的数据")]
        public DataRow SelectRow
        { get { return fGridView.GetFocusedDataRow(); } }

        #endregion 选中行

        #region 已选行(显示选择列时可多选)

        /// <summary>
        /// 已选行(显示选择列时可多选)
        /// </summary>
        [Browsable(false)]
        public List<DataRow> SelectedRows
        {
            get
            {
                return fGridView.GetSelectedRows()
             .Select(index => fGridView.GetDataRow(index))
             .ToList();
            }
        }

        #endregion 已选行(显示选择列时可多选)

        #region Fun

        public Delegate GlobalQueryFunc;

        #endregion Fun

        #region 主键key名称

        /// <summary>
        /// 主键key名称
        /// </summary>
        private string key;

        #endregion 主键key名称

        #region 主键key值

        private string masterkey;

        public string MasterKey
        {
            get { return masterkey; }
        }

        #endregion 主键key值

        #region 是否显示按钮

        private ButtonVisible fButtonVisible = new ButtonVisible();

        [Browsable(true)]
        [Description("是否显示按钮控件")]
        public ButtonVisible ButtonVisible
        {
            get { return fButtonVisible; }
            set
            {
                fButtonVisible = value;
                SetButtonVisible(fButtonVisible);
            }
        }

        #endregion 是否显示按钮

        #region Gridview刷新选中模式

        [Description("设置刷新选中三种模式"), DefaultValue("首行")]
        public CustomGridRefshEnum GridRefsh { get; set; }

        #endregion Gridview刷新选中模式

        #region 是否触发了表格的改变行焦点事件

        private bool fFocusChanged = false;

        #endregion 是否触发了表格的改变行焦点事件

        #region 表单窗体类型

        private Type fFormType;

        #endregion 表单窗体类型

        #region 表单窗体名称

        private string fFormTitle;

        #endregion 表单窗体名称

        #region 表单选中参数

        private Dictionary<string, object> fFormParamters;

        #endregion 表单选中参数

        #region 选中Data

        private DataRow Data { get; set; }

        #endregion 选中Data

        #endregion 属性

        #region 面板显示

        [Browsable(true)]
        [Description("是否显示面板")]
        public bool PanelFirstVisible { get => panel_First.Visible; set => panel_First.Visible = value; }

        #endregion 面板显示

        #region 构造函数
        public BaseControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 是否显示按钮

        public void SetButtonVisible(ButtonVisible buttonVisible)
        {
            pan_ExportExcel.Visible = buttonVisible.IsShowExportButton;
            pan_MoveFirst.Visible = buttonVisible.IsShowFirstButton;
            pan_MoveLast.Visible = buttonVisible.IsShowLastButton;
            pan_MoveNext.Visible = buttonVisible.IsShowNextButton;
            pan_MovePrev.Visible = buttonVisible.IsShowPrevButton;
            pan_Refresh.Visible = buttonVisible.IsShowRefreshButton;
            pan_Add.Visible = buttonVisible.IsShowAddButton;
            pan_Delete.Visible = buttonVisible.IsShowDeleteButton;
            pan_Edit.Visible = buttonVisible.IsShowEditButton;
        }

        #endregion 是否显示按钮

    }
}

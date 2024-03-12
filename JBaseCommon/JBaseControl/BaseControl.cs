using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using JBaseCommon.Utils;

namespace JBaseCommon.BaseControl
{
    public partial class BaseControl : UserControl
    {

        #region 字段
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

        #region 隐藏右键菜单
        [Browsable(true)]
        [Description("是否右键菜单")]
        public bool HideContextMenu { get; set; }
        #endregion
        #endregion

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

        #region 公开方法
        //#region 初始化

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    if (!DesignMode)
        //    {
        //        //GridLocationMode(GlobalQueryFunc.DynamicInvoke());
        //        //GetDataAsync();
        //    }
        //}

        //public void InitControl<T>(BindingInfo<T> bindingInfo)
        //{

        //    fGridControl = bindingInfo.GridControl;
        //    fGridView = bindingInfo.GridView;
        //    TableProperty(bindingInfo.HasCheckboxColumn);
        //    EventRegister();
        //    this.key = bindingInfo.KeyField;
        //    GlobalQueryFunc = bindingInfo.DataLoader;

        //}

        //#endregion 初始化

        #region 窗体初始化

        public void InitForm(Type editForm, string text)
        {
            fFormTitle = text;
            fFormType = editForm;
        }

        #endregion 窗体初始化

     

        #region 刷新数据

        public void RefreshData(object iDataSource)
        {
            fTableData = GlobalQueryFunc.DynamicInvoke() as DataTable;
           // GridLocationMode(fTableData);
        }

        #endregion 刷新数据

        #region 导出表格

        public void ExportToExcel()
        {
            if (fGridView.RowCount > 0)
            {
                string name = string.Empty;
                if (ParentForm != null)
                {
                    name = ParentForm.Text + "_";
                }
                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                path = Path.Combine(path, $"{name}_{DateTime.Now:yyyyMMddHHmmss}.xls");
                DevExpress.XtraPrinting.XlsExportOptionsEx options = new DevExpress.XtraPrinting.XlsExportOptionsEx
                {
                    ShowGridLines = true,
                    TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value,
                    ExportType = DevExpress.Export.ExportType.Default
                };
                fGridView.ExportToXls(path, options);
                XtraMessageBox.Show(this, "导出Excel成功,请在桌面查看！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show(this, "不能导出空数据!", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion 导出表格
        #endregion

        #region 私有方法
        #region 首条

        private void MoveFirst()
        {
            fGridView.MoveFirst();
        }

        #endregion 首条

        #region 末条

        private void MoveLast()
        {
            fGridView.MoveLast();
        }

        #endregion 末条

        #region 上一条

        private void MovePrev()
        {
            fGridView.MovePrev();
        }

        #endregion 上一条

        #region 下一条

        private void MoveNext()
        {
            fGridView.MoveNext();
        }

        #endregion 下一条
        #endregion
    }
}

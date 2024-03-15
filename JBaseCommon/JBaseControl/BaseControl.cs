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
using DevExpress.Data;
using DevExpress.XtraBars.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using JBaseCommon.JBaseForm;
using JBaseCommon.Utils;
using JCommon;

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
        public Delegate GlobalDelFunc;

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
        private CustomGridRefshEnum gridRefshEnum;
        [Description("设置刷新选中三种模式"), DefaultValue("首行")]
        public CustomGridRefshEnum GridRefsh { 
            get { return gridRefshEnum; }
            set { gridRefshEnum = value; }
        }

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
        #region 初始化

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
              
                GetDataAsync();
            }
        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <param name="gridControl">gc</param>
        /// <param name="gridView">gv</param>
        /// <param name="keyFiled">主键名称</param>
        /// <param name="checkBox">是否多选框</param>
        public void InitControl<T>(GridControl gridControl,GridView gridView,Func<T> action,Func<string,bool> delefunc,string keyFiled,bool CheckboxColumn=false)
        {
            fGridControl = gridControl;
            fGridView = gridView;
            RegistEvent();
            TableProperty(CheckboxColumn);
            this.key = keyFiled;
            GlobalQueryFunc = action;
            GlobalDelFunc = delefunc;
            BindData(GlobalQueryFunc.DynamicInvoke());

        }

        #endregion 初始化

        #region 表格属性配置
        /// <summary>
        /// 表格属性配置
        /// </summary>
        /// <param name="IsCheckColum">是否显示多选框</param>
        private void TableProperty(bool IsCheckColum)
        {
            if (HideContextMenu)
            {
                fGridControl.ContextMenuStrip = cms_Tools;
            }
            fGridView.OptionsBehavior.Editable = false;
            fGridView.OptionsBehavior.ReadOnly = true;
            fGridView.OptionsPrint.AutoWidth = false;
            fGridView.OptionsView.EnableAppearanceEvenRow = true;
            fGridView.OptionsView.ShowAutoFilterRow = isShowAutoFilterRow;
            fGridView.OptionsView.ShowGroupPanel = false;
            fGridView.OptionsView.ColumnAutoWidth = false;
            fGridView.HorzScrollStep = 100;
            fGridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            fGridView.OptionsView.ShowIndicator = true;
            fGridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            fGridView.OptionsView.EnableAppearanceEvenRow = true;                                            //启用偶数行背景色
            fGridView.OptionsView.EnableAppearanceOddRow = true;                                             //启用奇数行背景色

            fGridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(230, 230, 250, 254);      //设置偶数行背景色
            fGridView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(150, 199, 237, 204);       //设置奇数行背景色

            fGridView.IndicatorWidth = 65;
            if (IsCheckColum)
            {
                fGridView.OptionsSelection.MultiSelect = true;
                fGridView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            }
        }
        #endregion

        #region 窗体初始化

        public void InitForm(Type editForm, string text)
        {
            fFormTitle = text;
            fFormType = editForm;
        }

        #endregion 窗体初始化

        #region 绑定数据
        private void BindData(object iDataSource)
        {
            fGridControl.BeginUpdate();
            fGridControl.DataSource = iDataSource;
            fGridControl.EndUpdate();
            GridLocationMode();
        }

        public void BinData(DataTable fTableData)
        {
            fGridControl.BeginUpdate();
            fGridControl.DataSource = fTableData;
            fGridControl.EndUpdate();
            GridLocationMode();
        }
        #endregion


        #region 刷新数据

        public void RefreshData()
        {
            fTableData = GlobalQueryFunc.DynamicInvoke() as DataTable;
            BinData(fTableData);
        }

        #endregion 刷新数据

        #region 注册事件
        private void RegistEvent()
        {
            this.fGridView.CustomDrawRowIndicator += FGridView_CustomDrawRowIndicator1;
            this.sb_MoveFirst.Click += Sb_MoveFirst_Click;
            this.sb_MoveLast.Click += Sb_MoveLast_Click;
            this.sb_MoveNext.Click += Sb_MoveNext_Click;
            this.sb_MovePrev.Click += Sb_MovePrev_Click;
            this.sb_Refresh.Click += Sb_Refresh_Click;
            this.sb_Add.Click += Sb_Add_Click;
            this.sb_Delete.Click += Sb_Delete_Click;
            this.sb_Edit.Click += Sb_Edit_Click;
            this.sb_ExportExcel.Click += Sb_ExportExcel_Click;
            this.fGridView.FocusedRowChanged += FGridView_FocusedRowChanged1;
            fGridControl.DataSourceChanged += FGridControl_DataSourceChanged;
            this.fGridView.MouseDown += FGridView_MouseDown;
        }

      











        #endregion





        #endregion




        #region 虚方法

        #region 绑定数据/获取数据
        protected virtual void BindDataAsync()
        {
        }

        protected virtual void GetDataAsync()
        {
        }
        #endregion

        #region 清除表单数据
        /// <summary>
        /// 清除表单数据
        /// </summary>
        protected virtual void ClearData()
        {

        }
        #endregion

        #region 删除方法
        protected virtual bool DeleteData()
        {
            return (bool)GlobalDelFunc.DynamicInvoke(masterkey);
        }
        #endregion


        #endregion 虚方法

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

        #region 删除
        private void DeleteRow()
        {
            if (Data == null && !string.IsNullOrEmpty(MasterKey))
            {
                XtraMessageBox.Show(this, "请先选中一条数据", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DeleteData())
            {
                XtraMessageBox.Show(this, "删除失败", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.fGridView.DeleteRow(this.fGridView.GetFocusedDataSourceRowIndex());
                this.fGridView.RefreshData();
                XtraMessageBox.Show(this, "删除成功", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        #endregion

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

        #region 导出表格

        private void ExportToExcel()
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

        #region GridView定位模式(默认.尾部.选中行)

        private void GridLocationMode()
        {
            switch (GridRefsh)
            {
                case CustomGridRefshEnum.首行:
                    fGridView.FocusedRowHandle = 0;
                    break;

                case CustomGridRefshEnum.刷新选中行:
                    fGridView.FocusedRowHandle = fGridView.GetRowHandle(fGridView.GetFocusedDataSourceRowIndex()); ;
                    break;

                case CustomGridRefshEnum.末行:
                    fGridView.FocusedRowHandle = fGridView.RowCount > 0 ? fGridView.RowCount - 1 : 0;
                    break;
            }
            fGridView.TopRowIndex = fGridView.GetVisibleRowHandle(fGridView.FocusedRowHandle);
        }

        #endregion GridView定位模式(默认.尾部.选中行)

        #region 窗体增改方法

        #region AddEdit方法

        private void AddEdit(bool IsAdd)
        {
            if (IsAdd && AddClick != null)
            {
                AddClick?.Invoke(this, null);
            }
            else if (!IsAdd && EditClick != null)
            {
                EditClick?.Invoke(this, null);
            }

            if (fFormType != null)
            {
                using (var addForm = Activator.CreateInstance(fFormType) as BaseEditForm)
                {
                    addForm.Text = (IsAdd ? "新增" : "编辑") + fFormTitle;
                    addForm.Owner = FindForm();
                    addForm.Data = IsAdd ? null : Data;
                    addForm.IsAdd = IsAdd;
                    addForm.SaveDataEvent += () =>
                    {
                        this.RefreshData();
                    };
                    addForm.ShowDialog();

                }
            }
        }

        #endregion AddEdit方法

        #endregion 窗体增删改方法

        #endregion

        #region 事件

        #region 上一条
        private void Sb_MovePrev_Click(object sender, EventArgs e)
        {
            MovePrev();
        }
        #endregion

        #region 下一条
        private void Sb_MoveNext_Click(object sender, EventArgs e)
        {
            MoveNext();
        }
        #endregion

        #region 末条
        private void Sb_MoveLast_Click(object sender, EventArgs e)
        {
            MoveLast();
        }
        #endregion

        #region 首条
        private void Sb_MoveFirst_Click(object sender, EventArgs e)
        {
            MoveFirst();
        }
        #endregion

        #region 编辑事件
        private void Sb_Edit_Click(object sender, EventArgs e)
        {
            AddEdit(false);
        }

        #endregion

        #region 增加事件
        private void Sb_Add_Click(object sender, EventArgs e)
        {
            AddEdit(true);
        }
        #endregion

        #region 删除事件
        private void Sb_Delete_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }


        #endregion

        #region 刷新
        private void Sb_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        #endregion

        #region 导出
        private void Sb_ExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        #endregion

      

        #region 显示行号
        private void FGridView_CustomDrawRowIndicator1(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion

        #region 选中行
        private void FGridView_FocusedRowChanged1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            fFocusChanged = true;
            OnSelectChanged(key);
        }
        private void OnSelectChanged(string key)
        {
            Data = fGridView.GetFocusedDataRow();
            if (Data != null)
            {
                masterkey = Data.DataRowToString(key);
                Console.WriteLine(masterkey);
            }
        }

        #endregion 选中行

        #region 数据源绑定改变事件
        private void FGridControl_DataSourceChanged(object sender, EventArgs e)
        {
            if (!fFocusChanged)
            {
                OnSelectChanged(key);
            }
            else
            {
                fFocusChanged = false;
            }
        }
        #endregion

        #region 自定义委托事件

        #region 选中行改变

        public event SelectionChangedEventHandler SelectChanged;

        #endregion 选中行改变

        #region 选中行

        /// <param name="key">主键key</param>
        public delegate void SelectRowDelegate(string key);

        public event SelectRowDelegate SelectRowEvent;

        #endregion 选中行

        #region 增加事件

        public event EventHandler AddClick;

        #endregion 增加事件

        #region 编辑事件

        public event EventHandler EditClick;

        #endregion 编辑

        #region 删除事件

        // public event GlobalQueryFunc DeleteClick;

        #endregion 删除

        #endregion 自定义委托事件


        #region 双击事件
        private void FGridView_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = fGridView.CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                // 判断光标是否在行范围内
                if (hInfo.InRow && hInfo.RowHandle >= 0)
                {
                    if (ButtonVisible.IsShowEditButton)
                    {
                        AddEdit(false);
                    }
                }
            }
        }
        #endregion
        #endregion


    }
}

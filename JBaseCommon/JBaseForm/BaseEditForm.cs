using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using JCommon;

namespace JBaseCommon.JBaseForm
{
    public partial class BaseEditForm : BaseForm
    {
        #region 字段
        #region 自定义事件
        public event Action SaveDataEvent;
        #endregion

        #region 验证规则
        /// <summary>
        /// 必填项规则
        /// </summary>
        private ConditionValidationRule notEmptyValidationRule = new ConditionValidationRule();


        /// <summary>
        /// 最小值规则
        /// </summary>
        private ConditionValidationRule minValueValidationRule = new ConditionValidationRule();

        /// <summary>
        /// 默认启用
        /// </summary>
        private ConditionValidationRule mile = new ConditionValidationRule();


        /// <summary>
        /// 数值范围
        /// </summary>
        private ConditionValidationRule rangeValidationRule = new ConditionValidationRule();

        /// <summary>
        /// 与其他控件比较
        /// </summary>
        private CompareAgainstControlValidationRule compareAgainstControl = new CompareAgainstControlValidationRule();
        #endregion

        #region 预加载数据

        private Dictionary<string, object> preLoadData;

        /// <summary>
        /// 预加载数据
        /// </summary>
        [Browsable(false)]
        public Dictionary<string, object> PreLoadData
        {
            get
            {
                return this.preLoadData;
            }

            set
            {
                this.preLoadData = value;
            }
        }

        #endregion 预加载数据

        #region 选中Data

        public DataRow Data { get; set; }

        #endregion 选中Data

        #region 表格全部数据DataTable
        public DataTable GetDataTable { get; set; }
        #endregion

        #region 是否新增模式
        public bool IsAdd { get; set; }
        #endregion
       
        #endregion
        #region 构造函数
        public BaseEditForm()
        {
            InitializeComponent();
            RegistEvent();
        }
        #endregion

        #region 重写加载函数
        protected override void OnLoad(EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            try
            {
                InitValidationRules();
                if (this.Visible)
                {
                    this.SetValidationRule();
                }
                PreloadData();
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(this.GetType(), ex);
            }
        }
        #endregion




        #region 注册事件
        private void RegistEvent()
        {
            this.sb_Save.Click += Sb_Save_Click;
            this.sb_Cancel.Click += Sb_Cancel_Click;
        }

        #region 取消按钮
        private void Sb_Cancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        #endregion


        #region 保存按钮
        private void Sb_Save_Click(object sender, EventArgs e)
        {
            Save();

        }
        #endregion


        #region 虚方法

        #region 保存方法
        protected virtual void Save()
        {
           DialogResult dialog= XtraMessageBox.Show("保存数据成功", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialog == DialogResult.OK)
            {
                SaveDataEvent?.Invoke();
                this.Close();
            }
           
        }
        #endregion

        #region 取消方法
        protected virtual void Cancel()
        {
            this.Close();
        }
        #endregion

        #region 抽象预加载数据
        protected virtual void PreloadData()
        {

        }
        #endregion

        #endregion

        #region 控件设置验证规则

        private void InitValidationRules()
        {
            // 必填项
            this.notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            this.notEmptyValidationRule.ErrorText = "此项为必填项";
            this.notEmptyValidationRule.ErrorType = ErrorType.Information;

            this.minValueValidationRule.ConditionOperator = ConditionOperator.GreaterOrEqual;
            this.minValueValidationRule.Value1 = 0;
            this.minValueValidationRule.ErrorText = "此项必须大于等于0";

            ////// 数值范围
            rangeValidationRule.ConditionOperator = ConditionOperator.Between;
            rangeValidationRule.Value1 = 1;
            rangeValidationRule.Value2 = 100;
            rangeValidationRule.ErrorType = ErrorType.Warning;
            rangeValidationRule.ErrorText = $"请输入{rangeValidationRule.Value1}到{rangeValidationRule.Value2}之间的数值";

            ////// 包含某字符
            ////ConditionValidationRule containsValidationRule = new ConditionValidationRule();
            ////containsValidationRule.ConditionOperator = ConditionOperator.Contains;
            ////containsValidationRule.Value1 = '@';
            ////containsValidationRule.ErrorText = "Please enter a valid email";
            ////containsValidationRule.ErrorType = ErrorType.Warning;
            ////// </containsTextEdit>


        }

        #region 与其他控件比较
        public void SetControlValidationRule(Control control, Control control1)
        {
            // 与其他控件对比
            compareAgainstControl = new CompareAgainstControlValidationRule();
            compareAgainstControl.Control = control;
            compareAgainstControl.CompareControlOperator = CompareControlOperator.Equals;
            compareAgainstControl.ErrorText = "必须重复你所填的项目";
            compareAgainstControl.ErrorType = ErrorType.Warning;
            compareAgainstControl.CaseSensitive = false;
            SetValidationRule(control1, compareAgainstControl);
        }
        #endregion

        #region 设置必填项目
        public void SetNotEmptyValidationRule(Control control)
        {
            this.SetValidationRule(control, this.notEmptyValidationRule);
        }
        #endregion

        #region 设置最小值
        public void SetMinValueValidationRule(Control control)
        {
            notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            this.SetValidationRule(control, this.minValueValidationRule);
        }
        #endregion

        #region 设置数值范围
        public void SetMinValueBetweenMaxValidationRule(Control control)
        {
            rangeValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
            this.SetValidationRule(control, this.rangeValidationRule);
        }
        #endregion

        #region 控件设置验证规则
        public void SetValidationRule(Control control, ValidationRule rule)
        {
            this.dxValidationProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            this.dxValidationProvider1.SetValidationRule(control, rule);
        }
        #endregion

        #endregion

        #region 设置控件验证规则
        protected virtual void SetValidationRule()
        {
        }
        #endregion


        #endregion
    }
}
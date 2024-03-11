using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBaseCommon.Utils
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ButtonVisible
    {
        #region 选择按钮是否可见

        private bool isShowSelectButton = false;

        /// <summary>
        /// 选择按钮是否可见,双击行时,选择改行数据
        /// </summary>
        public bool IsShowSelectButton
        {
            get { return isShowSelectButton; }
            set
            {
                isShowSelectButton = value;
                if (this.IsShowEditButton == this.isShowSelectButton)
                {
                    this.IsShowEditButton = !this.isShowSelectButton;
                }
            }
        }

        #endregion 选择按钮是否可见

        #region 新增按钮是否可见

        private bool isShowAddButton = true;

        [Description("是否显示新增按钮控件")]
        public bool IsShowAddButton
        {
            get { return isShowAddButton; }
            set
            {
                isShowAddButton = value;
            }
        }

        #endregion 新增按钮是否可见

        #region 编辑按钮是否可见

        private bool isShowEditButton = true;

        /// <summary>
        /// 编辑按钮是否可见,双击行时,打开编辑窗体
        /// </summary>

        [Description("是否显示编辑按钮控件")]
        public bool IsShowEditButton
        {
            get { return isShowEditButton; }
            set
            {
                isShowEditButton = value;
                if (this.IsShowSelectButton == this.isShowEditButton)
                {
                    this.IsShowSelectButton = !this.isShowEditButton;
                }
            }
        }

        #endregion 编辑按钮是否可见

        #region 删除按钮是否可见

        private bool isShowDeleteButton = true;

        [Description("是否显示删除按钮控件")]
        public bool IsShowDeleteButton
        {
            get { return isShowDeleteButton; }
            set { isShowDeleteButton = value; }
        }

        #endregion 删除按钮是否可见

        #region 刷新按钮是否可见

        private bool isShowRefreshButton = true;

        /// <summary>
        /// 刷新按钮是否可见
        /// </summary>
        [Description("是否显示刷新按钮控件")]
        public bool IsShowRefreshButton
        {
            get { return isShowRefreshButton; }
            set { isShowRefreshButton = value; }
        }

        #endregion 刷新按钮是否可见

        #region 导出按钮是否可见

        private bool isShowExportButton = true;

        /// <summary>
        /// 导出按钮是否可见
        /// </summary>
        [Description("是否显示导出按钮控件")]
        public bool IsShowExportButton
        {
            get { return isShowExportButton; }
            set
            {
                isShowExportButton = value;
            }
        }

        #endregion 导出按钮是否可见

        #region 首条按钮是否可见

        private bool isShowFirstButton = true;

        /// <summary>
        /// 首条按钮是否可见
        /// </summary>
        [Description("是否显示首条按钮控件")]
        public bool IsShowFirstButton
        {
            get { return isShowFirstButton; }
            set { isShowFirstButton = value; }
        }

        #endregion 首条按钮是否可见

        #region 上条按钮是否可见

        private bool isShowPrevButton = true;

        /// <summary>
        /// 上条按钮是否可见
        /// </summary>

        [Description("是否显示上一条按钮控件")]
        public bool IsShowPrevButton
        {
            get { return isShowPrevButton; }
            set { isShowPrevButton = value; }
        }

        #endregion 上条按钮是否可见

        #region 下条按钮是否可见

        private bool isShowNextButton = true;

        /// <summary>
        /// 下条按钮是否可见
        /// </summary>
        [Description("是否显示下一条按钮控件")]
        public bool IsShowNextButton
        {
            get { return isShowNextButton; }
            set { isShowNextButton = value; }
        }

        #endregion 下条按钮是否可见

        #region 末条按钮是否可见

        private bool isShowLastButton = true;

        /// <summary>
        /// 末条按钮是否可见
        /// </summary>
        [Description("是否显示末条按钮控件")]
        public bool IsShowLastButton
        {
            get { return isShowLastButton; }
            set { isShowLastButton = value; }
        }

        #endregion 末条按钮是否可见
    }

    public enum CustomGridRefshEnum
    {
        首行,
        刷新选中行,
        末行
    }
}

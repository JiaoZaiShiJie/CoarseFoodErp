using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace CoarseFoodErp.Entity.Model
{
    /// <summary>
    /// 用户表
    ///</summary>
    [SugarTable("SysUser")]
    public class SysUser
    {
        /// <summary>
        /// 表主键 
        /// 默认值: (newsequentialid())
        ///</summary>
        [SugarColumn(ColumnName = "KeyUser")]
        public Guid? KeyUser { get; set; }
        /// <summary>
        /// 自增字段 
        ///</summary>
        [SugarColumn(ColumnName = "Id_User", IsPrimaryKey = true)]
        public int IdUser { get; set; }
        /// <summary>
        /// 唯一值:用户代码 
        ///</summary>
        [SugarColumn(ColumnName = "UserCode")]
        public string UserCode { get; set; }
        /// <summary>
        /// 用户名称 
        ///</summary>
        [SugarColumn(ColumnName = "UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// 工号 
        ///</summary>
        [SugarColumn(ColumnName = "WorkNo")]
        public string WorkNo { get; set; }
        /// <summary>
        /// 姓名拼音码,用于快速检索 
        ///</summary>
        [SugarColumn(ColumnName = "InputCode")]
        public string InputCode { get; set; }
        /// <summary>
        /// 手机号 
        ///</summary>
        [SugarColumn(ColumnName = "LinkTel")]
        public string LinkTel { get; set; }
        /// <summary>
        /// 登陆账号 
        ///</summary>
        [SugarColumn(ColumnName = "LoginName")]
        public string LoginName { get; set; }
        /// <summary>
        /// 登陆密码,加密算法 
        ///</summary>
        [SugarColumn(ColumnName = "LoginPwd")]
        public string LoginPwd { get; set; }
        /// <summary>
        /// 照片 
        ///</summary>
        [SugarColumn(ColumnName = "Picture")]
        public string Picture { get; set; }
        /// <summary>
        /// 签名招聘 
        ///</summary>
        [SugarColumn(ColumnName = "Signture")]
        public string Signture { get; set; }
        /// <summary>
        /// 是否禁用 
        ///</summary>
        [SugarColumn(ColumnName = "F_Disabled")]
        public bool? FDisabled { get; set; }
        /// <summary>
        /// 排序 
        ///</summary>
        [SugarColumn(ColumnName = "DispOrder")]
        public string DispOrder { get; set; }
        /// <summary>
        /// 备注 
        ///</summary>
        [SugarColumn(ColumnName = "Note")]
        public string Note { get; set; }
        /// <summary>
        /// 备注 冗余字段 
        ///</summary>
        [SugarColumn(ColumnName = "NoteOne")]
        public string NoteOne { get; set; }
        /// <summary>
        /// 冗余字段 
        ///</summary>
        [SugarColumn(ColumnName = "NoteTwo")]
        public string NoteTwo { get; set; }
        /// <summary>
        /// 创建时间 
        ///</summary>
        [SugarColumn(ColumnName = "CreateTime")]
        public string CreateTime { get; set; }
    }
}

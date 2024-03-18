﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBaseCommon.Utils
{
    #region 父级
    public enum E_SysKey
    {
        皮肤设置,
        基础设置,
        账号设置
    }
    #endregion

    #region 子级
    public enum E_SysKey_Type
    {
        皮肤名称,
        软件升级Url,
        账号,
        密码,
        记住密码,
        自动登录
          
    }
    #endregion
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace CoarseFoodErp.Utils
{
    public class DbContextHelper
    {
        public static SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig()
        {
            ConnectionString = @"DataSource=" + Path.Combine(Environment.CurrentDirectory, "SerialPortDB.db"),
            DbType = DbType.Sqlite,
            IsAutoCloseConnection = true
        },
 db =>
 {
     
     db.Aop.OnLogExecuting = (sql, pars) =>
     {
     };
 });
    }
}

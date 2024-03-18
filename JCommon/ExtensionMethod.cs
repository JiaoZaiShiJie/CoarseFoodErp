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

namespace JCommon
{
    #region DataRow的扩展方法

    /// <summary>
    /// DataRow的扩展方法
    /// </summary>
    public static class DataRowExtensionMethods
    {
        /// <summary>
        /// 把DataRow中的某一列值转换为布尔类型
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static bool DataRowToBool(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return false;
            }

            if (row.IsNull(columnName))
            {
                return false;
            }

            if (bool.TryParse(row[columnName].ToString(), out bool result))
            {
                return result;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Int转BOOL类型   0:True  1:False
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool DataRowIntToRow(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return false;
            }

            if (row.IsNull(columnName))
            {
                return false;
            }
            if (row[columnName].ToString() == "1")
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 把DataRow中的某一列值转换为布尔类型
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static bool? DataRowToBoolNull(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return null;
            }

            if (row.IsNull(columnName))
            {
                return null;
            }

            if (bool.TryParse(row[columnName].ToString(), out bool result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 把DataRow中的某一列值转换为CheckState类型
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static CheckState DataRowToCheckState(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return CheckState.Indeterminate;
            }

            if (row.IsNull(columnName))
            {
                return CheckState.Indeterminate;
            }

            bool result;
            if (bool.TryParse(row[columnName].ToString(), out result))
            {
                return result ? CheckState.Checked : CheckState.Unchecked;
            }
            else
            {
                return CheckState.Indeterminate;
            }
        }

        /// <summary>
        /// 把DataRow中的某一列值转换为日期
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static DateTime DataRowToDate(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return DateTime.Now.Date;
            }

            if (row.IsNull(columnName))
            {
                return DateTime.Now.Date;
            }

            DateTime result;
            if (DateTime.TryParse(row[columnName].ToString(), out result))
            {
                return result.Date;
            }
            else
            {
                return DateTime.Now.Date;
            }
        }

        /// <summary>
        /// 把DataRow中的某一列值转换为日期
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static DateTime? DataRowToDateNull(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return null;
            }

            if (row.IsNull(columnName))
            {
                return null;
            }

            DateTime result;
            if (DateTime.TryParse(row[columnName].ToString(), out result))
            {
                return result.Date;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 把DataRow中的某一列值转换为时间
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static DateTime DataRowToDateTime(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return DateTime.Now;
            }

            if (row.IsNull(columnName))
            {
                return DateTime.Now;
            }

            DateTime result;
            if (DateTime.TryParse(row[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 把DataRow中的某一列值转换为时间
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static DateTime? DataRowToDateTimeNull(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return null;
            }

            if (row.IsNull(columnName))
            {
                return null;
            }

            if (DateTime.TryParse(row[columnName].ToString(), out DateTime result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 把DataRow中的某一列值转换为十进制数
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static decimal DataRowToDecimal(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return 0M;
            }

            if (row.IsNull(columnName))
            {
                return 0M;
            }

            decimal result;
            if (decimal.TryParse(row[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return 0M;
            }
        }

        /// <summary>
        /// 把DataRow中的某一列值转换为十进制数
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns>可能为空</returns>
        public static decimal? DataRowToDecimalNull(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return null;
            }

            if (row.IsNull(columnName))
            {
                return null;
            }

            if (decimal.TryParse(row[columnName].ToString(), out decimal result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 把DataRow转换为数据字典
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static Dictionary<string, object> DataRowToDictionary(this DataRow row)
        {
            if (row.Table.Columns.Count > 0)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                for (int i = 0; i < row.Table.Columns.Count; i++)
                {
                    var columnName = row.Table.Columns[i].ColumnName;
                    dic.Add(columnName, row[columnName]);
                }

                return dic;
            }

            return null;
        }

        /// <summary>
        /// 把DataRow中的某一列值转换为字符串
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="columnName">列名</param>
        /// <returns></returns>
        public static string DataRowToString(this DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
            {
                return string.Empty;
            }

            if (row.IsNull(columnName))
            {
                return string.Empty;
            }

            return row[columnName].ToString();
        }
    }

    #endregion DataRow的扩展方法

    #region Form的扩展方法

    public static class FormExtensionMethods
    {
        /// <summary>
        /// 判断Mdi窗体是否已打开
        /// </summary>
        /// <param name="mdiFormName">Mdi窗口名称</param>
        /// <returns></returns>
        public static Form HasMdiChild(this Form form, string mdiFormName)
        {
            int i;

            // 依次检测当前窗体的子窗体
            for (i = 0; i < form.MdiChildren.Length; i++)
            {
                // 判断当前子窗体的Text属性值是否与传入的字符串值相同
                if (form.MdiChildren[i].Name == mdiFormName)
                {
                    // 如果值相同则表示此子窗体为想要调用的子窗体，激活此子窗体并返回true值
                    form.MdiChildren[i].Activate();

                    return form.MdiChildren[i];
                }
            }

            // 如果没有相同的值则表示要调用的子窗体还没有被打开，返回false值
            return null;
        }
    }

    #endregion Form的扩展方法

    #region List To Table
    public static class ListExtensions
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
    #endregion

    #region 枚举转换
    public static class ObjectExtensions
    {
        /// <summary>
        /// 枚举转换
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this object obj)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), obj.ToString());
        }

    }
    #endregion

    #region 合格率
    public static class PercentPass
    {
        /// <summary>
        /// 合格率/不合格率
        /// </summary>
        public static string ToPercent(this double num, double countnum)
        {
            return $"{Math.Round(num / countnum * 100, 2)}%";
        }

    }
    #endregion

    #region 跨线程操作
    public static class InvokeExMethods
    {
        public static void InvokeEx(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public static void BeginInvokeEx(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
    }

    #endregion

    #region 大小端转换
    public static class SizeSideConventExmethod
    {
        /// <summary>
        /// 大小端转换
        /// </summary>
        /// <param name="value"></param>
        public static string SizeSideConvent(this string value)
        {
            string[] parts = value.Split(';');

            string hexString = "";

            foreach (string part in parts)
            {
                short x = short.Parse(part);

                byte[] bytes = BitConverter.GetBytes(x);

                hexString += "0x" + bytes[0].ToString("X2");// + bytes[1].ToString("X2");
            }

            return hexString;

        }
    }
    #endregion

    #region Base64ToImage

    public static class BaseConventImageExmethod
    {
        public static Image Base64ToImage(this string base64String)
        {
            // 去除Base64前缀（如果存在）
            base64String = RemoveBase64Header(base64String);

            // 将Base64字符串解码为字节数组
            byte[] imageBytes = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(imageBytes))
            {
                // 从内存流创建Image对象
                return Image.FromStream(ms);
            }
        }
        private static string RemoveBase64Header(string base64String)
        {
            if (base64String.StartsWith("data:image/"))
            {
                int commaIndex = base64String.IndexOf(",");
                if (commaIndex > 0)
                {
                    base64String = base64String.Substring(commaIndex + 1);
                }
            }
            return base64String;
        }
    }
  
    #endregion


}

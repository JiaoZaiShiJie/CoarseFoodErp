using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jot;

namespace JCommon.Jot
{
    public static class JotConfigService
    {
        #region 字段

        /// <summary>
        /// 配置文件保存路径
        /// </summary>
        private static readonly string ConfigFileSavePath = System.IO.Directory.GetCurrentDirectory();

        public static Tracker Tracker = new Tracker(new JsonDataStore(ConfigFileSavePath));

        #endregion 字段

        #region 属性是否存在

        /// <summary>
        /// 属性是否存在
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="id">属性所属分类</param>
        /// <returns></returns>
        private static bool Exists(string id, string propertyName)
        {
            if (!System.IO.Directory.Exists(ConfigFileSavePath))
            {
                return false;
            }
            var dic = Tracker.Store.GetData(id);
            if (dic != null)
            {
                return dic.ContainsKey(propertyName) && dic[propertyName] != null;
            }

            return false;
        }

        /// <summary>
        /// 属性是否存在
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="id">属性所属分类</param>
        /// <returns></returns>
        public static bool Exists(Enum id, Enum propertyName)
        {
            return Exists(id.ToString(), propertyName.ToString());
        }

        #endregion 属性是否存在

        #region 获取已保存的数据

        /// <summary>
        /// 获取已保存的数据
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="id">属性所属分类</param>
        /// <returns></returns>
        public static object GetData(string id, string propertyName, object defaultValue = null)
        {
            if (!System.IO.Directory.Exists(ConfigFileSavePath))
            {
                return defaultValue;
            }

            IDictionary<string, object> Data = new Dictionary<string, object>();
            var dic = Tracker.Store.GetData(id);
            if (dic != null)
            {
                if (dic.ContainsKey(propertyName) && dic[propertyName] != null)
                {
                    return dic[propertyName];
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// 获取已保存的数据
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="id">属性所属分类</param>
        /// <returns></returns>
        public static object GetData(Enum id, Enum propertyName, object defaultValue = null)
        {
            return GetData(id.ToString(), propertyName.ToString(), defaultValue);
        }

        #endregion 获取已保存的数据

        #region 保存数据

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="id">属性所属分类</param>
        public static void SetData(string id, string propertyName, object value)
        {
            try
            {
                IDictionary<string, object> dic = Tracker.Store.GetData(id);
                if (dic.ContainsKey(propertyName))
                {
                    dic[propertyName] = value;
                }
                else
                {
                    dic.Add(propertyName, value);
                }

                Tracker.Store.SetData(id, dic);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(typeof(JotConfigService), ex);
                throw ex;
            }
        }

        #region 保存数据

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="id">属性所属分类</param>
        public static void SetData(Enum id, Enum propertyName, object value)
        {
            SetData(id.ToString(), propertyName.ToString(), value);
        }

        #endregion 保存数据

        #endregion 保存数据

        #region 根据文件名称删除数据

        /// <summary>
        /// 根据文件名称删除数据 (注意 删除的属性的名称 也就是一个.data的文件)
        /// </summary>
        /// <param name="id"></param>
        public static void ClearData(Enum id)
        {
            Tracker.Store.ClearData(id.ToString());
        }

        #endregion 根据文件名称删除数据

        #region 清空所有持久化数据

        public static void ClearDataAll()
        {
            Tracker.Store.ClearAll();
        }

        #endregion 清空所有持久化数据
    }
}

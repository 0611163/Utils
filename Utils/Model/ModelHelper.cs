using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Utils
{
    /// <summary>
    /// 有继承关系的实体类转换
    /// </summary>
    public static class ModelHelper
    {
        private static object _lock = new object();

        #region Model转换
        /// <summary>
        /// Model转换
        /// </summary>
        public static T Convert<T>(this object obj) where T : new()
        {
            if (obj == null) return default(T);
            Type sourceType = obj.GetType();
            Type targetType = typeof(T);
            T t = new T();

            List<PropertyInfo> sourcePropertyInfoArr = GetEntityPropertiesByCache(sourceType);
            List<PropertyInfo> targetPropertyInfoArr = GetEntityPropertiesByCache(targetType);
            Dictionary<string, PropertyInfo> dictTargetPropertyInfo = targetPropertyInfoArr.ToLookup(a => a.Name).ToDictionary(a => a.Key, b => b.First());

            if (sourcePropertyInfoArr != null)
            {
                foreach (PropertyInfo sourcePropertyInfo in sourcePropertyInfoArr)
                {
                    PropertyInfo targetPropertyInfo = null;
                    if (dictTargetPropertyInfo.TryGetValue(sourcePropertyInfo.Name, out targetPropertyInfo))
                    {
                        targetPropertyInfo.SetValue(t, sourcePropertyInfo.GetValue(obj, null), null);
                    }
                }
            }
            return t;
        }
        #endregion

        #region 获取实体类属性
        /// <summary>
        /// 获取实体类属性
        /// </summary>
        private static List<PropertyInfo> GetEntityPropertiesByCache(Type baseType)
        {
            lock (_lock)
            {
                List<PropertyInfo> result = null;
                string cacheKey = "ModelHelper.Convert.PropertyInfo." + baseType.FullName;
                object cacheValue = MemoryCacheUtil.GetValue(cacheKey);
                if (cacheValue != null)
                {
                    result = cacheValue as List<PropertyInfo>;
                }
                else
                {
                    result = GetEntityProperties(baseType);
                    MemoryCacheUtil.SetValue(cacheKey, result);
                }
                return result;
            }
        }

        /// <summary>
        /// 获取实体类属性
        /// </summary>
        private static List<PropertyInfo> GetEntityProperties(Type type)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            PropertyInfo[] propertyInfoList = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfoList)
            {
                if (propertyInfo.GetCustomAttributes(typeof(EdmRelationshipNavigationPropertyAttribute), false).Length == 0
                    && propertyInfo.GetCustomAttributes(typeof(BrowsableAttribute), false).Length == 0)
                {
                    result.Add(propertyInfo);
                }
            }
            return result;
        }
        #endregion

    }
}

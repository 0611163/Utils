using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Utils
{
    /// <summary>
    /// 服务帮助类
    /// </summary>
    public partial class ServiceHelper
    {
        #region 变量
        /// <summary>
        /// 对象集合
        /// </summary>
        private static ConcurrentDictionary<Type, object> _dict = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// 实现接口的类集合
        /// </summary>
        private static ConcurrentDictionary<string, List<Type>> _dictInterfaceClassList = new ConcurrentDictionary<string, List<Type>>();
        #endregion

        #region Get 获取对象
        /// <summary>
        /// 获取对象
        /// </summary>
        public static T Get<T>() where T : new()
        {
            Type type = typeof(T);
            object obj = _dict.GetOrAdd(type, (key) => new T());

            return (T)obj;
        }
        #endregion

        #region Get 通过Func获取对象
        /// <summary>
        /// 获取对象
        /// </summary>
        public static T Get<T>(Func<T> func)
        {
            Type type = typeof(T);
            object obj = _dict.GetOrAdd(type, (key) => func());

            return (T)obj;
        }
        #endregion

        #region RegisterAssembly 注册程序集
        /// <summary>
        /// 注册程序集
        /// </summary>
        /// <param name="assemblyString">程序集名称的长格式</param>
        public static void RegisterAssembly(string assemblyString)
        {
            LogTimeUtil logTimeUtil = new LogTimeUtil();
            Assembly assembly = Assembly.Load(assemblyString);
            Type[] typeArr = assembly.GetTypes();

            foreach (Type type in typeArr)
            {
                Type[] interfaceTypeArr = type.GetInterfaces();

                foreach (Type interfaceType in interfaceTypeArr)
                {
                    if (interfaceType.FullName != null)
                    {
                        List<Type> classTypeList = _dictInterfaceClassList.GetOrAdd(interfaceType.FullName, new List<Type>());
                        classTypeList.Add(type);
                    }
                }
            }
            logTimeUtil.LogTime("ServiceHelper.RegisterAssembly 注册程序集 " + assemblyString + " 耗时");
        }
        #endregion

        #region Resove<T> 实例化接口
        /// <summary>
        /// 实例化接口
        /// </summary>
        public static T Resove<T>()
        {
            Type interfaceType = typeof(T);

            object obj = _dict.GetOrAdd(interfaceType, (key) =>
            {
                object result = null;

                List<Type> classTypeList;
                if (_dictInterfaceClassList.TryGetValue(interfaceType.FullName, out classTypeList))
                {
                    Type classType = classTypeList.Find(clsType =>
                    {
                        if (clsType.GetCustomAttributes(typeof(ServiceRegisterAttribute), false).Length > 0)
                        {
                            return true;
                        }
                        return false;
                    });
                    result = Activator.CreateInstance(classType);
                }

                return result;
            });

            return (T)obj;
        }
        #endregion

    }
}
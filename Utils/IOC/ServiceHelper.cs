using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
        /// 接口的对象集合
        /// </summary>
        private static ConcurrentDictionary<Type, object> _dict = new ConcurrentDictionary<Type, object>();
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
        /// <param name="type">程序集中的一个类型</param>
        public static void RegisterAssembly(Type type)
        {
            RegisterAssembly(Assembly.GetAssembly(type).FullName);
        }

        /// <summary>
        /// 注册程序集
        /// </summary>
        /// <param name="assemblyString">程序集名称的长格式</param>
        public static void RegisterAssembly(string assemblyString)
        {
            LogTimeUtil logTimeUtil = new LogTimeUtil();
            Assembly assembly = Assembly.Load(assemblyString);
            Type[] typeArr = assembly.GetTypes();
            string iServiceInterfaceName = typeof(IService).FullName;

            foreach (Type type in typeArr)
            {
                Type typeIService = type.GetInterface(iServiceInterfaceName);
                if (typeIService != null)
                {
                    Type[] interfaceTypeArr = type.GetInterfaces();
                    object obj = Activator.CreateInstance(type);

                    foreach (Type interfaceType in interfaceTypeArr)
                    {
                        if (interfaceType != typeof(IService))
                        {
                            _dict.GetOrAdd(interfaceType, obj);
                        }
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

            object obj = null;
            _dict.TryGetValue(interfaceType, out obj);

            return (T)obj;
        }
        #endregion

        #region 启动所有服务
        /// <summary>
        /// 启动所有服务
        /// </summary>
        public static Task StartAllService()
        {
            return Task.Run(() =>
            {
                List<Task> taskList = new List<Task>();
                foreach (object o in _dict.Values.Distinct())
                {
                    Task task = Task.Factory.StartNew(obj =>
                    {
                        IService service = obj as IService;

                        try
                        {
                            service.OnStart();
                            LogUtil.Log("服务 " + obj.GetType().FullName + " 已启动");
                        }
                        catch (Exception ex)
                        {
                            LogUtil.Error(ex, "服务 " + obj.GetType().FullName + " 启动失败");
                        }
                    }, o);
                    taskList.Add(task);
                }
                Task.WaitAll(taskList.ToArray());
            });
        }
        #endregion

        #region 停止所有服务
        /// <summary>
        /// 停止所有服务
        /// </summary>
        public static Task StopAllService()
        {
            return Task.Run(() =>
            {
                List<Task> taskList = new List<Task>();
                foreach (object o in _dict.Values.Distinct())
                {
                    Task task = Task.Factory.StartNew(obj =>
                    {
                        IService service = obj as IService;

                        try
                        {
                            service.OnStop();
                            LogUtil.Log("服务 " + obj.GetType().FullName + " 已停止").Wait();
                        }
                        catch (Exception ex)
                        {
                            LogUtil.Error(ex, "服务 " + obj.GetType().FullName + " 停止失败").Wait();
                        }
                    }, o);
                    taskList.Add(task);
                }
                Task.WaitAll(taskList.ToArray());
            });
        }
        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// 服务抽象类
    /// </summary>
    public abstract class AbstractService : IService
    {
        /// <summary>
        /// 服务启动
        /// </summary>
        public virtual void OnStart() { }

        /// <summary>
        /// 服务停止
        /// </summary>
        public virtual void OnStop() { }
    }
}

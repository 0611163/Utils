using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// 标识该类为服务
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceRegisterAttribute : Attribute
    {
    }
}

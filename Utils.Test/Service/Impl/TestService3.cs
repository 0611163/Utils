using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Test
{
    /// <summary>
    /// 只是一个普通类，没有继承接口和AbstractService
    /// </summary>
    public class TestService3
    {
        public string GetVal3(string value)
        {
            return "value：" + value;
        }
    }
}

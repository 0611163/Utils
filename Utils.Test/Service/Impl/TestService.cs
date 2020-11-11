using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Test
{
    [ServiceRegister]
    public class TestService : ITestService
    {
        public TestService()
        {
            LogUtil.Log("实例化TestService");
        }

        public string Get(string value)
        {
            return "value：" + value;
        }
    }
}

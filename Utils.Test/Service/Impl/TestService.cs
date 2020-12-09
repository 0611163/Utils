using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils.Test
{
    public class TestService : AbstractService, ITestService
    {
        public TestService()
        {
            LogUtil.Log("实例化 TestService");
        }

        /// <summary>
        /// 服务启动
        /// </summary>
        public override void OnStart()
        {
            LogUtil.Log("TestService OnStart");
        }

        // <summary>
        // 服务停止
        // </summary>
        public override void OnStop()
        {
            LogUtil.Log("TestService OnStop").Wait();
        }

        public string Get(string value)
        {
            return "value：" + value;
        }
    }
}

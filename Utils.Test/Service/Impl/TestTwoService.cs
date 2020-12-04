using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Test.Service.Impl
{
    public class TestTwoService : AbstractService, ITestTwoService
    {
        public TestTwoService()
        {
            LogUtil.Log("实例化 TestTwoService");
        }

        /// <summary>
        /// 服务启动
        /// </summary>
        public override void OnStart()
        {
            LogUtil.Log("TestTwoService OnStart");
        }

        // <summary>
        // 服务停止
        // </summary>
        public override void OnStop()
        {
            LogUtil.Log("TestTwoService OnStop").Wait();
        }

        public string GetVal(string value)
        {
            return "value：" + value;
        }
    }
}

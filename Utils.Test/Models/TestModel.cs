using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    public class TestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public TestModel(int data)
        {
            Id = data.ToString();
            Name = "名称：" + data.ToString();
            Code = "编码" + data.ToString();
        }
    }
}

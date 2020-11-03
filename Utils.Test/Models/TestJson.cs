using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestJson
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<PointInfo> LsPoint { get; set; }

        public TestJson()
        {
            ID = Guid.NewGuid().ToString();
            Name = "测试";
            LsPoint = new List<Models.PointInfo>();
            PointInfo point = new PointInfo("1", 117.3, 31.8);
            LsPoint.Add(point);
            point = new PointInfo("1", 117.31, 31.8);
            LsPoint.Add(point);
            point = new PointInfo("1", 117.31, 31.81);
            LsPoint.Add(point);
            point = new PointInfo("1", 117.3, 31.81);
            LsPoint.Add(point);
        }
    }

    public class PointInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string Index { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public double Lng { get; set; }

        public PointInfo(string index, double lng, double lat)
        {
            Index = index;
            Lng = lng;
            Lat = lat;
        }
    }
}

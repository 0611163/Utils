//using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Models
{
    [Serializable]
    //[ProtoContract]
    public class PtCameraInfo2
    {
        //[ProtoMember(1)]
        public string ID { get; set; }
        //[ProtoMember(2)]
        public string CAMERA_NAME { get; set; }
        //[ProtoMember(3)]
        public string CAMERA_NO { get; set; }
        //[ProtoMember(4)]
        public string LATITUDE { get; set; }
        //[ProtoMember(5)]
        public string LONGITUDE { get; set; }
        //[ProtoMember(6)]
        public string CAMERA_STATE { get; set; }
        //[ProtoMember(7)]
        public string ADDRESS { get; set; }
        //[ProtoMember(8)]
        public decimal? CAMERA_TYPE { get; set; }
        //[ProtoMember(9)]
        public decimal? ORG_ID { get; set; }
        //[ProtoMember(10)]
        public string CAMERA_DIRECTION { get; set; }
        //[ProtoMember(11)]
        public string SHORT_MSG { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.ID + "}{");
            sb.Append(this.CAMERA_NAME + "}{");
            sb.Append(this.CAMERA_NO + "}{");
            sb.Append(this.LATITUDE + "}{");
            sb.Append(this.LONGITUDE + "}{");
            sb.Append(this.CAMERA_STATE + "}{");
            sb.Append(this.ADDRESS + "}{");
            sb.Append(this.CAMERA_TYPE + "}{");
            sb.Append(this.ORG_ID + "}{");
            sb.Append(this.CAMERA_DIRECTION + "}{");
            sb.Append(this.SHORT_MSG + "}{");
            return sb.ToString();
        }

        public static PtCameraInfo2 FromString(string value)
        {
            PtCameraInfo2 info = new PtCameraInfo2();
            string[] strArr = value.Split(new string[] { "}{" }, StringSplitOptions.RemoveEmptyEntries);
            info.ID = strArr[0];
            info.CAMERA_NAME = strArr[1];
            info.CAMERA_NO = strArr[2];
            info.LATITUDE = strArr[3];
            info.LONGITUDE = strArr[4];
            info.CAMERA_STATE = strArr[5];
            info.ADDRESS = strArr[6];
            info.CAMERA_TYPE = StringUtil.ConvertToDecimal(strArr[7]);
            info.ORG_ID = StringUtil.ConvertToDecimal(strArr[8]);
            info.CAMERA_DIRECTION = strArr[9];
            info.SHORT_MSG = strArr[10];
            return info;
        }
    }
}

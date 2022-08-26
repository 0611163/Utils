//using ProtoBuf;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using Utils;

namespace Models
{
    [Serializable]
    //[DataContract(IsReference = true)] //导致ProtoBuf序列化报错
    //[ProtoContract]
    public partial class PtCameraInfo : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);

        private string _BDV_PRODUCT_ID;

        private string _ID;

        private string _CAMERA_NO;

        private string _CAMERA_NAME;

        private System.Nullable<decimal> _ORG_ID;

        private System.Nullable<decimal> _OLD_ORG_ID;

        private string _ADDRESS;

        private string _LONGITUDE;

        private string _LATITUDE;

        private string _RESOLUTION;

        private string _CAMERA_DIRECTION;

        private string _INSTALL_WAY;

        private string _LINEAR_WAY;

        private System.Nullable<decimal> _SHOW_LEVEL;

        private System.Nullable<decimal> _CAMERA_TYPE;

        private string _SN;

        private string _CAMERA_STATE;

        private System.Nullable<decimal> _IS_HAVE_CONSOLE;

        private decimal _IS_DEL;

        private decimal _CAMERA_USE;

        private string _SHORT_MSG;

        private string _PLATFORM_PRODUCT_ID;

        private string _MEMBERBAR_CODE;
        //add
        private string _CameraModel;

        private string _Camera_Ip;

        private string _Manufacturer;

        private string _Supplier;

        private DateTime? _AddTime;

        private DateTime? _ModifyTime;

        private System.Nullable<decimal> _AddId;

        private System.Nullable<decimal> _ModifyId;

        private string _UserName;

        private string _Password;

        private string _LENS_PARAM;

        private string _Install_Way;

        private String _WatchUnits;

        private string _IS_WIFI;

        private int _BuildPeriod;

        private int _KeyUnit;

        private string _Street;

        private int _CAMERA_FUN_TYPE;

        private int _IMPORT_WATCH;

        private string _PROTOCOL_TYPE;

        private string _ANALYSIS_NO;

        private string _CAMERA_BELONGS_ID;

        private string _CAMERA_BELONGS_PK;

        private string _WATCH_SPEC_LOCATION;

        private string _POSITION_TYPE;

        private string _ROAD_DIRECTION;

        private string _INDUSTRY_OWN;

        private string _FEN_JU;

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion

        public new const string PlatformName = "CameraInfo";

        public PtCameraInfo()
        {
            OnCreated();
        }


        /// <summary>
        /// There are no comments for BDV_PRODUCT_ID in the schema.
        /// </summary>
        [DataMember(Order = 1)]
        public virtual string BDV_PRODUCT_ID
        {
            get
            {
                return this._BDV_PRODUCT_ID;
            }
            set
            {
                if (this._BDV_PRODUCT_ID != value)
                {
                    this.SendPropertyChanging();
                    this._BDV_PRODUCT_ID = value;
                    this.SendPropertyChanged("BDV_PRODUCT_ID");
                }
            }
        }

        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        [DataMember(Order = 2)]
        //[ProtoMember(1)]
        public virtual string ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if (this._ID != value)
                {
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                }
            }
        }


        /// <summary>
        /// There are no comments for CAMERA_NO in the schema.
        /// </summary>
        [DataMember(Order = 3)]
        //[ProtoMember(2)]
        public virtual string CAMERA_NO
        {
            get
            {
                return this._CAMERA_NO;
            }
            set
            {
                if (this._CAMERA_NO != value)
                {
                    this.SendPropertyChanging();
                    this._CAMERA_NO = value;
                    this.SendPropertyChanged("CAMERA_NO");
                }
            }
        }

        /// <summary>
        /// There are no comments for CAMERA_NAME in the schema.
        /// </summary>
        [DataMember(Order = 4)]
        //[ProtoMember(3)]
        public virtual string CAMERA_NAME
        {
            get
            {
                return this._CAMERA_NAME;
            }
            set
            {
                if (this._CAMERA_NAME != value)
                {
                    this.SendPropertyChanging();
                    this._CAMERA_NAME = value;
                    this.SendPropertyChanged("CAMERA_NAME");
                }
            }
        }

        /// <summary>
        /// There are no comments for ORG_ID in the schema.
        /// </summary>
        [DataMember(Order = 5)]
        //[ProtoMember(4)]
        public virtual System.Nullable<decimal> ORG_ID
        {
            get
            {
                return this._ORG_ID;
            }
            set
            {
                if (this._ORG_ID != value)
                {
                    this.SendPropertyChanging();
                    this._ORG_ID = value;
                    this.SendPropertyChanged("ORG_ID");
                }
            }
        }


        /// <summary>
        /// There are no comments for ADDRESS in the schema.
        /// </summary>
        [DataMember(Order = 6)]
        //[ProtoMember(5)]
        public virtual string ADDRESS
        {
            get
            {
                return this._ADDRESS;
            }
            set
            {
                if (this._ADDRESS != value)
                {
                    this.SendPropertyChanging();
                    this._ADDRESS = value;
                    this.SendPropertyChanged("ADDRESS");
                }
            }
        }


        /// <summary>
        /// There are no comments for LONGITUDE in the schema.
        /// </summary>
        [DataMember(Order = 7)]
        //[ProtoMember(6)]
        public virtual string LONGITUDE
        {
            get
            {
                return this._LONGITUDE;
            }
            set
            {
                if (this._LONGITUDE != value)
                {
                    this.SendPropertyChanging();
                    this._LONGITUDE = value;
                    this.SendPropertyChanged("LONGITUDE");
                }
            }
        }

        /// <summary>
        /// There are no comments for LATITUDE in the schema.
        /// </summary>
        [DataMember(Order = 8)]
        //[ProtoMember(7)]
        public virtual string LATITUDE
        {
            get
            {
                return this._LATITUDE;
            }
            set
            {
                if (this._LATITUDE != value)
                {
                    this.SendPropertyChanging();
                    this._LATITUDE = value;
                    this.SendPropertyChanged("LATITUDE");
                }
            }
        }

        /// <summary>
        /// There are no comments for RESOLUTION in the schema.
        /// </summary>
        [DataMember(Order = 9)]
        public virtual string RESOLUTION
        {
            get
            {
                return this._RESOLUTION;
            }
            set
            {
                if (this._RESOLUTION != value)
                {
                    this.SendPropertyChanging();
                    this._RESOLUTION = value;
                    this.SendPropertyChanged("RESOLUTION");
                }
            }
        }

        /// <summary>
        /// There are no comments for CAMERA_DIRECTION in the schema.
        /// </summary>
        [DataMember(Order = 10)]
        //[ProtoMember(8)]
        public virtual string CAMERA_DIRECTION
        {
            get
            {
                return this._CAMERA_DIRECTION;
            }
            set
            {
                if (this._CAMERA_DIRECTION != value)
                {
                    this.SendPropertyChanging();
                    this._CAMERA_DIRECTION = value;
                    this.SendPropertyChanged("CAMERA_DIRECTION");
                }
            }
        }

        /// <summary>
        /// There are no comments for INSTALL_WAY in the schema.
        /// </summary>
        [DataMember(Order = 11)]
        public virtual string INSTALL_WAY
        {
            get
            {
                return this._INSTALL_WAY;
            }
            set
            {
                if (this._INSTALL_WAY != value)
                {
                    this.SendPropertyChanging();
                    this._INSTALL_WAY = value;
                    this.SendPropertyChanged("INSTALL_WAY");
                }
            }
        }

        /// <summary>
        /// There are no comments for LINEAR_WAY in the schema.
        /// </summary>
        [DataMember(Order = 12)]
        public virtual string LINEAR_WAY
        {
            get
            {
                return this._LINEAR_WAY;
            }
            set
            {
                if (this._LINEAR_WAY != value)
                {
                    this.SendPropertyChanging();
                    this._LINEAR_WAY = value;
                    this.SendPropertyChanged("LINEAR_WAY");
                }
            }
        }

        /// <summary>
        /// There are no comments for SHOW_LEVEL in the schema.
        /// </summary>
        [DataMember(Order = 13)]
        public virtual System.Nullable<decimal> SHOW_LEVEL
        {
            get
            {
                return this._SHOW_LEVEL;
            }
            set
            {
                if (this._SHOW_LEVEL != value)
                {
                    this.SendPropertyChanging();
                    this._SHOW_LEVEL = value;
                    this.SendPropertyChanged("SHOW_LEVEL");
                }
            }
        }


        /// <summary>
        /// There are no comments for CAMERA_TYPE in the schema.
        /// </summary>
        [DataMember(Order = 14)]
        //[ProtoMember(9)]
        public virtual System.Nullable<decimal> CAMERA_TYPE
        {
            get
            {
                return this._CAMERA_TYPE;
            }
            set
            {
                if (this._CAMERA_TYPE != value)
                {
                    this.SendPropertyChanging();
                    this._CAMERA_TYPE = value;
                    this.SendPropertyChanged("CAMERA_TYPE");
                }
            }
        }


        /// <summary>
        /// There are no comments for SN in the schema.
        /// </summary>
        [DataMember(Order = 15)]
        public virtual string SN
        {
            get
            {
                return this._SN;
            }
            set
            {
                if (this._SN != value)
                {
                    this.SendPropertyChanging();
                    this._SN = value;
                    this.SendPropertyChanged("SN");
                }
            }
        }

        /// <summary>
        /// There are no comments for CAMERA_STATE in the schema.
        /// </summary>
        [DataMember(Order = 16)]
        //[ProtoMember(10)]
        public virtual string CAMERA_STATE
        {
            get
            {
                return this._CAMERA_STATE;
            }
            set
            {
                if (this._CAMERA_STATE != value)
                {
                    this.SendPropertyChanging();
                    this._CAMERA_STATE = value;
                    this.SendPropertyChanged("CAMERA_STATE");
                    //this.SendPropertyChanged(this);
                }
            }
        }

        /// <summary>
        /// There are no comments for IS_HAVE_CONSOLE in the schema.
        /// </summary>
        [DataMember(Order = 17)]
        public virtual System.Nullable<decimal> IS_HAVE_CONSOLE
        {
            get
            {
                return this._IS_HAVE_CONSOLE;
            }
            set
            {
                if (this._IS_HAVE_CONSOLE != value)
                {
                    this.SendPropertyChanging();
                    this._IS_HAVE_CONSOLE = value;
                    this.SendPropertyChanged("IS_HAVE_CONSOLE");
                }
            }
        }


        /// <summary>
        /// There are no comments for IS_DEL in the schema.
        /// </summary>
        [DataMember(Order = 18)]
        public virtual decimal IS_DEL
        {
            get
            {
                return this._IS_DEL;
            }
            set
            {
                if (this._IS_DEL != value)
                {
                    this.SendPropertyChanging();
                    this._IS_DEL = value;
                    this.SendPropertyChanged("IS_DEL");
                }
            }
        }


        /// <summary>
        /// There are no comments for IS_DEL in the schema.
        /// </summary>
        [DataMember(Order = 18)]
        public virtual decimal CAMERA_USE
        {
            get
            {
                return this._CAMERA_USE;
            }
            set
            {
                if (this._CAMERA_USE != value)
                {
                    this.SendPropertyChanging();
                    this._CAMERA_USE = value;
                    this.SendPropertyChanged("CAMERA_USE");
                }
            }
        }

        [DataMember(Order = 19)]
        //[ProtoMember(11)]
        public virtual string SHORT_MSG
        {
            get
            {
                return this._SHORT_MSG;
            }
            set
            {
                if (this._SHORT_MSG != value)
                {
                    this.SendPropertyChanging();
                    this._SHORT_MSG = value;
                    this.SendPropertyChanged("SHORT_MSG");
                }
            }
        }

        [DataMember(Order = 20)]
        public virtual string PLATFORM_PRODUCT_ID
        {
            get
            {
                return this._PLATFORM_PRODUCT_ID;
            }
            set
            {
                if (this._PLATFORM_PRODUCT_ID != value)
                {
                    this.SendPropertyChanging();
                    this._PLATFORM_PRODUCT_ID = value;
                    this.SendPropertyChanged("PLATFORM_PRODUCT_ID");
                }
            }
        }

        [DataMember(Order = 21)]
        public virtual string MEMBERBAR_CODE
        {
            get
            {
                return this._MEMBERBAR_CODE;
            }
            set
            {
                if (this._MEMBERBAR_CODE != value)
                {
                    this.SendPropertyChanging();
                    this._MEMBERBAR_CODE = value;
                    this.SendPropertyChanged("MEMBERBAR_CODE");
                }
            }
        }

        /// <summary>
        /// 设备型号
        /// </summary>
        [DataMember(Order = 22)]
        public virtual string CameraModel
        {
            get
            {
                return this._CameraModel;
            }
            set
            {
                if (this._CameraModel != value)
                {
                    this.SendPropertyChanging();
                    this._CameraModel = value;
                    this.SendPropertyChanged("CameraModel");
                }
            }
        }

        /// <summary>
        /// 设备ip
        /// </summary>
        [DataMember(Order = 23)]
        public virtual string Camera_Ip
        {
            get
            {
                return this._Camera_Ip;
            }
            set
            {
                if (this._Camera_Ip != value)
                {
                    this.SendPropertyChanging();
                    this._Camera_Ip = value;
                    this.SendPropertyChanged("Camera_Ip");
                }
            }
        }

        /// <summary>
        ///生产商
        /// </summary>
        [DataMember(Order = 24)]
        public virtual string Manufacturer
        {
            get
            {
                return this._Manufacturer;
            }
            set
            {
                if (this._Manufacturer != value)
                {
                    this.SendPropertyChanging();
                    this._Manufacturer = value;
                    this.SendPropertyChanged("Manufacturer");
                }
            }
        }

        /// <summary>
        ///供应商
        /// </summary>
        [DataMember(Order = 25)]
        public virtual string Supplier
        {
            get
            {
                return this._Supplier;
            }
            set
            {
                if (this._Supplier != value)
                {
                    this.SendPropertyChanging();
                    this._Supplier = value;
                    this.SendPropertyChanged("Supplier");
                }
            }
        }


        /// <summary>
        ///添加时间
        /// </summary>
        [DataMember(Order = 26)]
        public virtual DateTime? AddTime
        {
            get
            {
                return this._AddTime;
            }
            set
            {
                if (this._AddTime != value)
                {
                    this.SendPropertyChanging();
                    this._AddTime = value;
                    this.SendPropertyChanged("AddTime");
                }
            }
        }
        /// <summary>
        ///添加时间
        /// </summary>
        [DataMember(Order = 27)]
        public virtual DateTime? ModifyTime
        {
            get
            {
                return this._ModifyTime;
            }
            set
            {
                if (this._ModifyTime != value)
                {
                    this.SendPropertyChanging();
                    this._ModifyTime = value;
                    this.SendPropertyChanged("ModifyTime");
                }
            }
        }

        /// <summary>
        /// 添加人
        /// </summary>
        [DataMember(Order = 28)]
        public virtual System.Nullable<decimal> AddId
        {
            get
            {
                return this._AddId;
            }
            set
            {
                if (this._AddId != value)
                {
                    this.SendPropertyChanging();
                    this._AddId = value;
                    this.SendPropertyChanged("AddId");
                }
            }
        }

        /// <summary>
        /// 修改人
        /// </summary>
        [DataMember(Order = 29)]
        public virtual System.Nullable<decimal> ModifyId
        {
            get
            {
                return this._ModifyId;
            }
            set
            {
                if (this._ModifyId != value)
                {
                    this.SendPropertyChanging();
                    this._ModifyId = value;
                    this.SendPropertyChanged("ModifyId");
                }
            }
        }

        /// <summary>
        ///用户名
        /// </summary>
        [DataMember(Order = 30)]
        public virtual string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                if (this._UserName != value)
                {
                    this.SendPropertyChanging();
                    this._UserName = value;
                    this.SendPropertyChanged("UserName");
                }
            }
        }

        /// <summary>
        ///摄像机密码
        /// </summary>
        [DataMember(Order = 31)]
        public virtual string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                if (this._Password != value)
                {
                    this.SendPropertyChanging();
                    this._Password = value;
                    this.SendPropertyChanged("Password");
                }
            }
        }
        /// <summary>
        ///镜头参数
        /// </summary>
        [DataMember(Order = 32)]
        public virtual string LENS_PARAM
        {
            get
            {
                return this._LENS_PARAM;
            }
            set
            {
                if (this._LENS_PARAM != value)
                {
                    this.SendPropertyChanging();
                    this._LENS_PARAM = value;
                    this.SendPropertyChanged("LENS_PARAM");
                }
            }
        }


        /// <summary>
        ///安装方式
        /// </summary>
        [DataMember(Order = 33)]
        public virtual string Install_Way
        {
            get
            {
                return this._Install_Way;
            }
            set
            {
                if (this._Install_Way != value)
                {
                    this.SendPropertyChanging();
                    this._Install_Way = value;
                    this.SendPropertyChanged("Install_Way");
                }
            }
        }


        /// <summary>
        ///重点单位
        /// </summary>
        [DataMember(Order = 34)]
        public virtual string WatchUnits
        {
            get
            {
                return this._WatchUnits;
            }
            set
            {
                if (this._WatchUnits != value)
                {
                    this.SendPropertyChanging();
                    this._WatchUnits = value;
                    this.SendPropertyChanged("WatchUnits");
                }
            }
        }

        /// <summary>
        /// WIFI探针
        /// </summary>
        [DataMember(Order = 35)]
        public virtual string IS_WIFI
        {
            get
            {
                return this._IS_WIFI;
            }
            set
            {
                if (this._IS_WIFI != value)
                {
                    this.SendPropertyChanging();
                    this._IS_WIFI = value;
                    this.SendPropertyChanged("IS_WIFI");
                }
            }
        }

        /// <summary>
        /// 0全部 1 2 6
        /// </summary>
        [DataMember(Order = 36)]
        public virtual int BuildPeriod
        {
            get
            {
                return this._BuildPeriod;
            }
            set
            {
                if (this._BuildPeriod != value)
                {
                    this.SendPropertyChanging();
                    this._BuildPeriod = value;
                    this.SendPropertyChanged("BuildPeriod");
                }
            }
        }

        /// <summary>
        /// 重点单位
        /// </summary>
        [DataMember(Order = 37)]
        public virtual int KeyUnit
        {
            get
            {
                return this._KeyUnit;
            }
            set
            {
                if (this._KeyUnit != value)
                {
                    this.SendPropertyChanging();
                    this._KeyUnit = value;
                    this.SendPropertyChanged("KeyUnit");
                }
            }
        }

        /// <summary>
        /// 重点街道
        /// </summary>
        [DataMember(Order = 38)]
        public virtual string Street
        {
            get
            {
                return this._Street;
            }
            set
            {
                if (this._Street != value)
                {
                    this.SendPropertyChanging();
                    this._Street = value;
                    this.SendPropertyChanged("Street");
                }
            }
        }

        /// <summary>
        /// 1、 车辆卡口； 2、 人员卡口；3、 微卡口；4、WIFI采集；5、综合治理枪；6、 综合治理球； 7、人脸摄像机（后智能）；8、虚拟卡口；9、高点监控（球）；10、高点监控（枪）；11、视频结构化（后智能）；99、其他。可以多选，各参数以“ /” 分隔（：CAMERA_USE）
        /// </summary>
        [DataMember(Order = 39)]
        public virtual int CAMERA_FUN_TYPE
        {
            get
            {
                return this._CAMERA_FUN_TYPE;
            }
            set
            {
                if (this._CAMERA_FUN_TYPE != value)
                {
                    this.SendPropertyChanging();
                    this._CAMERA_FUN_TYPE = value;
                    this.SendPropertyChanged("CAMERA_FUN_TYPE");
                }
            }
        }

        /// <summary>
        /// 1、第一道防控圈；2、第二道防控圈；3、第三道防空圈；4、第四道防控圈；5、第五道防控圈；6、第六道防控圈；99、其他（：）
        /// </summary>
        [DataMember(Order = 40)]
        public virtual int IMPORT_WATCH
        {
            get
            {
                return this._IMPORT_WATCH;
            }
            set
            {
                if (this._IMPORT_WATCH != value)
                {
                    this.SendPropertyChanging();
                    this._IMPORT_WATCH = value;
                    this.SendPropertyChanged("IMPORT_WATCH");
                }
            }
        }

        /// <summary>
        /// There are no comments for ORG_ID in the schema.
        /// </summary>
        [DataMember(Order = 41)]
        public virtual System.Nullable<decimal> OLD_ORG_ID
        {
            get
            {
                return this._OLD_ORG_ID;
            }
            set
            {
                if (this._OLD_ORG_ID != value)
                {
                    this.SendPropertyChanging();
                    this._OLD_ORG_ID = value;
                    this.SendPropertyChanged("OLD_ORG_ID");
                }
            }
        }

        /// <summary>
        /// There are no comments for PROTOCOL_TYPE in the schema.
        /// </summary>
        [DataMember(Order = 3)]
        public virtual string PROTOCOL_TYPE
        {
            get
            {
                return this._PROTOCOL_TYPE;
            }
            set
            {
                if (this._PROTOCOL_TYPE != value)
                {
                    this.SendPropertyChanging();
                    this._PROTOCOL_TYPE = value;
                    this.SendPropertyChanged("PROTOCOL_TYPE");
                }
            }
        }


        [DataMember(Order = 42)]
        public virtual string ANALYSIS_NO
        {
            get
            {
                return this._ANALYSIS_NO;
            }
            set
            {
                if (this._ANALYSIS_NO != value)
                {
                    this.SendPropertyChanging();
                    this._ANALYSIS_NO = value;
                    this.SendPropertyChanged("ANALYSIS_NO");
                }
            }
        }
        [DataMember(Order = 43)]
        public virtual string CAMERA_BELONGS_ID
        {
            get
            {
                return this._CAMERA_BELONGS_ID;
            }
            set
            {
                if (this._CAMERA_BELONGS_ID != value)
                {
                    this.SendPropertyChanging();
                    this._CAMERA_BELONGS_ID = value;
                    this.SendPropertyChanged("CAMERA_BELONGS_ID");
                }
            }
        }
        [DataMember(Order = 44)]
        public virtual string CAMERA_BELONGS_PK
        {
            get
            {
                return this._CAMERA_BELONGS_PK;
            }
            set
            {
                if (this._CAMERA_BELONGS_PK != value)
                {
                    this.SendPropertyChanging();
                    this._CAMERA_BELONGS_PK = value;
                    this.SendPropertyChanged("CAMERA_BELONGS_PK");
                }
            }
        }

        /// <summary>
        /// 照射位置
        /// </summary>
        [DataMember(Order = 47)]
        public virtual string WATCH_SPEC_LOCATION
        {
            get
            {
                return this._WATCH_SPEC_LOCATION;
            }
            set
            {
                if (this._WATCH_SPEC_LOCATION != value)
                {
                    this.SendPropertyChanging();
                    this._WATCH_SPEC_LOCATION = value;
                    this.SendPropertyChanged("WATCH_SPEC_LOCATION");
                }
            }
        }

        /// <summary>
        /// 位置类型
        /// </summary>
        [DataMember(Order = 48)]
        public virtual string POSITION_TYPE
        {
            get
            {
                return this._POSITION_TYPE;
            }
            set
            {
                if (this._POSITION_TYPE != value)
                {
                    this.SendPropertyChanging();
                    this._POSITION_TYPE = value;
                    this.SendPropertyChanged("POSITION_TYPE");
                }
            }
        }

        /// <summary>
        /// 所在道路位置
        /// </summary>
        [DataMember(Order = 49)]
        public virtual string ROAD_DIRECTION
        {
            get
            {
                return this._ROAD_DIRECTION;
            }
            set
            {
                if (this._ROAD_DIRECTION != value)
                {
                    this.SendPropertyChanging();
                    this._ROAD_DIRECTION = value;
                    this.SendPropertyChanged("ROAD_DIRECTION");
                }
            }
        }

        /// <summary>
        /// 所属行业
        /// </summary>
        [DataMember(Order = 50)]
        public virtual string INDUSTRY_OWN
        {
            get
            {
                return this._INDUSTRY_OWN;
            }
            set
            {
                if (this._INDUSTRY_OWN != value)
                {
                    this.SendPropertyChanging();
                    this._INDUSTRY_OWN = value;
                    this.SendPropertyChanged("INDUSTRY_OWN");
                }
            }
        }

        //FEN_JU
        [DataMember(Order = 51)]
        public virtual string FEN_JU
        {
            get
            {
                return this._FEN_JU;
            }
            set
            {
                if (this._FEN_JU != value)
                {
                    this.SendPropertyChanging();
                    this._FEN_JU = value;
                    this.SendPropertyChanged("FEN_JU");
                }
            }
        }

        /// <summary>
        /// 实体属性名。
        /// </summary>
        public static class Fields
        {
            public const string BDV_PRODUCT_ID = "BDV_PRODUCT_ID";

            public const string ID = "ID";

            public const string CAMERA_NO = "CAMERA_NO";

            public const string CAMERA_NAME = "CAMERA_NAME";

            public const string ORG_ID = "ORG_ID";

            public const string OLD_ORG_ID = "OLD_ORG_ID";

            public const string ADDRESS = "ADDRESS";

            public const string LONGITUDE = "LONGITUDE";

            public const string LATITUDE = "LATITUDE";

            public const string RESOLUTION = "RESOLUTION";

            public const string CAMERA_DIRECTION = "CAMERA_DIRECTION";

            public const string INSTALL_WAY = "INSTALL_WAY";

            public const string LINEAR_WAY = "LINEAR_WAY";

            public const string SHOW_LEVEL = "SHOW_LEVEL";

            public const string CAMERA_TYPE = "CAMERA_TYPE";

            public const string SN = "SN";

            public const string CAMERA_STATE = "CAMERA_STATE";

            public const string IS_HAVE_CONSOLE = "IS_HAVE_CONSOLE";

            public const string IS_DEL = "IS_DEL";

            public const string CAMERA_USE = "CAMERA_USE";

            public const string SHORT_MSG = "SHORT_MSG";

            public const string PLATFORM_PRODUCT_ID = "PLATFORM_PRODUCT_ID";

            public const string MEMBERBAR_CODE = "MEMBERBAR_CODE";

            //add
            public const string CameraModel = "CameraModel";

            public const string Camera_Ip = "Camera_Ip";

            public const string Manufacturer = "Manufacturer";

            public const string Supplier = "Supplier";

            public const string AddTime = "AddTime";

            public const string ModifyTime = "ModifyTime";

            public const string AddId = "AddId";

            public const string ModifyId = "ModifyId";

            public const string UserName = "UserName";

            public const string Password = "Password";

            public const string LENS_PARAM = "LENS_PARAM";

            public const string Install_Way = "Install_Way";

            public const string WatchUnits = "WatchUnits";

            public const string IS_WIFI = "IS_WIFI";

            public const string BuildPeriod = "BuildPeriod";

            public const string KeyUnit = "KeyUnit";

            public const string Street = "Street";

            public const string CAMERA_FUN_TYPE = "CAMERA_FUN_TYPE";

            public const string IMPORT_WATCH = "IMPORT_WATCH";

            public const string WATCH_SPEC_LOCATION = "WATCH_SPEC_LOCATION";

            public const string POSITION_TYPE = "POSITION_TYPE";

            public const string ROAD_DIRECTION = "ROAD_DIRECTION";

            public const string INDUSTRY_OWN = "INDUSTRY_OWN";

            public const string KeyUnitEx = "KeyUnitEx";

            public const string FEN_JU = "FEN_JU";

        }


        public virtual event PropertyChangingEventHandler PropertyChanging;

        public virtual event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName)
        {
            var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

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

        public static PtCameraInfo FromString(string value)
        {
            PtCameraInfo info = new PtCameraInfo();
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

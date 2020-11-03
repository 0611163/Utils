using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// IP帮助类
    /// </summary>
    public class IPHelper
    {
        #region 获取本机IP
        /// <summary>
        /// 获取本机IP
        /// </summary>
        public static string GetLocalIP()
        {
            List<string> listIP = new List<string>();
            ManagementClass mcNetworkAdapterConfig = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc_NetworkAdapterConfig = mcNetworkAdapterConfig.GetInstances();
            foreach (ManagementObject mo in moc_NetworkAdapterConfig)
            {
                string mServiceName = mo["ServiceName"] as string;

                //过滤非真实的网卡
                if (!(bool)mo["IPEnabled"])
                { continue; }
                if (mServiceName.ToLower().Contains("vmnetadapter")
                 || mServiceName.ToLower().Contains("ppoe")
                 || mServiceName.ToLower().Contains("bthpan")
                 || mServiceName.ToLower().Contains("tapvpn")
                 || mServiceName.ToLower().Contains("ndisip")
                 || mServiceName.ToLower().Contains("sinforvnic"))
                { continue; }

                //bool mDHCPEnabled = (bool)mo["IPEnabled"];//是否开启了DHCP
                //string mCaption = mo["Caption"] as string;
                //string mMACAddress = mo["MACAddress"] as string;
                string[] mIPAddress = mo["IPAddress"] as string[];
                //string[] mIPSubnet = mo["IPSubnet"] as string[];
                //string[] mDefaultIPGateway = mo["DefaultIPGateway"] as string[];
                //string[] mDNSServerSearchOrder = mo["DNSServerSearchOrder"] as string[];

                if (mIPAddress != null)
                {
                    Regex regex = new Regex(@"\d\.");
                    foreach (string ip in mIPAddress)
                    {
                        if (ip != "0.0.0.0" && regex.IsMatch(ip))
                        {
                            listIP.Add(ip);
                        }
                    }
                }
                mo.Dispose();
            }
            moc_NetworkAdapterConfig.Dispose();
            mcNetworkAdapterConfig.Dispose();

            if (listIP.Count > 0)
            {
                return listIP[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 获取本机的MAC
        /// <summary>
        /// 获取本机的MAC
        /// </summary>
        public static string GetLocalMAC()
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_NetWorkAdapterConfiguration");

                string strFirstHardDiskID = null;
                foreach (ManagementObject mo in mos.Get())
                {
                    try
                    {
                        string mServiceName = mo["ServiceName"] as string;

                        //过滤非真实的网卡
                        if (!(bool)mo["IPEnabled"])
                        { continue; }
                        if (mServiceName.ToLower().Contains("vmnetadapter")
                         || mServiceName.ToLower().Contains("ppoe")
                         || mServiceName.ToLower().Contains("bthpan")
                         || mServiceName.ToLower().Contains("tapvpn")
                         || mServiceName.ToLower().Contains("ndisip")
                         || mServiceName.ToLower().Contains("sinforvnic"))
                        { continue; }

                        if (mo["IPEnabled"].ToString().ToLower() == "true")
                        {
                            strFirstHardDiskID = mo["MacAddress"].ToString().Trim();
                            break;
                        }
                        else
                        {
                            strFirstHardDiskID = "";
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                return strFirstHardDiskID;
            }
            catch
            {
                return "";
            }
        }
        #endregion

    }
}

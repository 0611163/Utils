using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    /// <summary>
    /// 时间工具类
    /// </summary>
    public class DateTimeHelper
    {
        #region 获取时间戳
        /// <summary> 
        /// 获取时间戳 
        /// </summary>  
        public static string GetTimeStamp(DateTime dateTime)
        {
            DateTime dtStart = new DateTime(1970, 1, 1, 8, 0, 0);
            return Convert.ToInt64(dateTime.Subtract(dtStart).TotalMilliseconds).ToString();
        }
        #endregion

        #region 根据时间戳获取时间
        /// <summary> 
        /// 根据时间戳获取时间 
        /// </summary>  
        public static DateTime TimeStampToDateTime(string timeStamp)
        {
            DateTime dtStart = new DateTime(1970, 1, 1, 8, 0, 0);
            return dtStart.AddMilliseconds(Convert.ToInt64(timeStamp));
        }
        #endregion

        #region 本周开始时间
        /// <summary>
        /// 本周开始时间
        /// </summary>
        public static DateTime GetCurrentWeekStart()
        {
            DateTime now = DateTime.Now;
            int day = Convert.ToInt32(now.DayOfWeek.ToString("d"));
            return now.AddDays(1 - day).Date;
        }
        #endregion

        #region 本周结束时间
        /// <summary>
        /// 本周结束时间
        /// </summary>
        public static DateTime GetCurrentWeekEnd()
        {
            return GetCurrentWeekStart().AddDays(7).AddSeconds(-1);
        }
        #endregion

        #region 本月开始时间
        /// <summary>
        /// 本月开始时间
        /// </summary>
        public static DateTime GetCurrentMonthStart()
        {
            DateTime now = DateTime.Now;
            return now.AddDays(1 - now.Day).Date;
        }
        #endregion

        #region 本月结束时间
        /// <summary>
        /// 本月结束时间
        /// </summary>
        public static DateTime GetCurrentMonthEnd()
        {
            return GetCurrentWeekStart().AddMonths(1).AddSeconds(-1);
        }
        #endregion

        #region 本季度开始时间
        /// <summary>
        /// 本季度开始时间
        /// </summary>
        public static DateTime GetCurrentQuarterStart()
        {
            DateTime now = DateTime.Now;
            return now.AddMonths(0 - (now.Month - 1) % 3).AddDays(1 - now.Day).Date;
        }
        #endregion

        #region 本季度结束时间
        /// <summary>
        /// 本季度结束时间
        /// </summary>
        public static DateTime GetCurrentQuarterthEnd()
        {
            return GetCurrentWeekStart().AddMonths(3).AddSeconds(-1);
        }
        #endregion

        #region 本年开始时间
        /// <summary>
        /// 本年开始时间
        /// </summary>
        public static DateTime GetCurrentYearStart()
        {
            return new DateTime(DateTime.Now.Year, 1, 1);
        }
        #endregion

        #region 本年结束时间
        /// <summary>
        /// 本年结束时间
        /// </summary>
        public static DateTime GetCurrentYearEnd()
        {
            return new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils
{
    /// <summary>
    /// String工具类
    /// </summary>
    public class StringUtil
    {
        #region 删除特殊字符，这些特殊字符使字符串转json失败
        /// <summary>
        ///  删除特殊字符，这些特殊字符使字符串转json失败
        /// </summary>
        /// <param name="str">需要删除特殊字符的字符串</param>
        /// <returns></returns>
        public static string RemoveSpecialCharacter(string str)
        {
            try
            {
                if (str != null)
                {
                    return
                        str.Replace("\r", "")
                            .Replace("\n", "")
                            .Replace("\t", "")
                            .Replace("	", "")
                            .Replace("	", "")
                            .Replace(":", "：")
                            .Replace("\\", "、")
                            .Replace("\"", "“")
                            .Replace(".", "。")
                            .Replace(",", "，");
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 删除特殊字符
        /// <summary>
        /// 删除特殊字符
        /// </summary>
        public static string RemoveInvalidChars(string str)
        {
            if (str != null)
            {
                char[] invalidCharArr = System.IO.Path.GetInvalidFileNameChars();

                string strReg = string.Join("|", invalidCharArr).Replace("\\", "\\\\");

                Regex regex = new Regex("[" + strReg + "]");

                return regex.Replace(str, string.Empty);
            }
            return null;
        }
        #endregion

        #region string转DateTime
        /// <summary>
        /// string转DateTime
        /// </summary>
        public static DateTime ConvertToDateTime(string value)
        {
            DateTime result = DateTime.MinValue;

            if (!string.IsNullOrWhiteSpace(value))
            {
                DateTime dt;
                if (DateTime.TryParse(value, out dt))
                {
                    result = dt;
                }
            }

            return result;
        }
        #endregion

        #region string转decimal
        /// <summary>
        /// string转decimal
        /// </summary>
        public static decimal ConvertToDecimal(string value)
        {
            decimal result = 0;

            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.Trim().Replace(" ", string.Empty);

                decimal.TryParse(value, out result);
            }

            return result;
        }
        #endregion

        #region string转double
        /// <summary>
        /// string转double
        /// </summary>
        public static double ConvertToDouble(string value)
        {
            double result = 0;

            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.Trim().Replace(" ", string.Empty);

                double.TryParse(value, out result);
            }

            return result;
        }
        #endregion

        #region string转long
        /// <summary>
        /// string转long
        /// </summary>
        public static long ConvertToInt64(string value)
        {
            long result = 0;

            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.Trim().Replace(" ", string.Empty);

                long.TryParse(value, out result);
            }

            return result;
        }
        #endregion

        #region string转int
        /// <summary>
        /// string转int
        /// </summary>
        public static int ConvertToInt32(string value)
        {
            int result = 0;

            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.Trim().Replace(" ", string.Empty);

                int.TryParse(value, out result);
            }

            return result;
        }
        #endregion

        #region object转string
        /// <summary>
        /// object转string
        /// </summary>
        public static string ConvertObjToString(object value)
        {
            string result = null;

            if (value != null)
            {
                result = value.ToString();
            }

            return result;
        }
        #endregion

        #region string转DateTime?
        /// <summary>
        /// string转DateTime?
        /// </summary>
        public static DateTime? ConvertToNullableDateTime(string value)
        {
            DateTime? result = null;

            if (!string.IsNullOrWhiteSpace(value))
            {
                DateTime dt;
                if (DateTime.TryParse(value, out dt))
                {
                    result = dt;
                }
            }

            return result;
        }
        #endregion

        #region string转decimal?
        /// <summary>
        /// string转decimal?
        /// </summary>
        public static decimal? ConvertToNullableDecimal(string value)
        {
            decimal? result = null;

            if (!string.IsNullOrWhiteSpace(value))
            {
                decimal d;
                if (decimal.TryParse(value, out d))
                {
                    result = d;
                }
            }

            return result;
        }
        #endregion

        #region string转double?
        /// <summary>
        /// string转double?
        /// </summary>
        public static double? ConvertToNullableDouble(string value)
        {
            double? result = null;

            if (!string.IsNullOrWhiteSpace(value))
            {
                double d;
                if (double.TryParse(value, out d))
                {
                    result = d;
                }
            }

            return result;
        }
        #endregion

        #region string转long?
        /// <summary>
        /// string转long?
        /// </summary>
        public static long? ConvertToNullableInt64(string value)
        {
            long? result = null;

            if (!string.IsNullOrWhiteSpace(value))
            {
                long d;
                if (long.TryParse(value, out d))
                {
                    result = d;
                }
            }

            return result;
        }
        #endregion

        #region string转int?
        /// <summary>
        /// string转int?
        /// </summary>
        public static int? ConvertToNullableInt32(string value)
        {
            int? result = null;

            if (!string.IsNullOrWhiteSpace(value))
            {
                int d;
                if (int.TryParse(value, out d))
                {
                    result = d;
                }
            }

            return result;
        }
        #endregion

        #region decimal?转decimal
        /// <summary>
        /// decimal?转decimal
        /// </summary>
        public static decimal ConvertNullableToDecimal(decimal? value)
        {
            if (value != null) return value.Value;
            return 0;
        }
        #endregion

        #region double?转double
        /// <summary>
        /// double?转double
        /// </summary>
        public static double ConvertNullableToDouble(double? value)
        {
            if (value != null) return value.Value;
            return 0;
        }
        #endregion

        #region long?转long
        /// <summary>
        /// long?转long
        /// </summary>
        public static long ConvertNullableToInt64(long? value)
        {
            if (value != null) return value.Value;
            return 0;
        }
        #endregion

        #region int?转int
        /// <summary>
        /// int?转int
        /// </summary>
        public static int ConvertNullableToInt32(int? value)
        {
            if (value != null) return value.Value;
            return 0;
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC.Controls.Helpers
{
    public static partial class Extension
    {
        #region 数值转换
        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>System.Int32.</returns>
        public static int ToInt(this object data)
        {
            if (data == null)
                return 0;
            if (data is bool)
            {
                return (bool)data ? 1 : 0;
            }
            int result;
            var success = int.TryParse(data.ToString(), out result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data, 0));
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion

        /// <summary>
        /// 转换为双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>System.Double.</returns>
        public static double ToDouble(this object data)
        {
            if (data == null)
                return 0;
            double result;
            return double.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 转换为双精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        /// <returns>System.Double.</returns>
        public static double ToDouble(this object data, int digits)
        {
            return Math.Round(ToDouble(data), digits, System.MidpointRounding.AwayFromZero);
        }


        #region 日期转换
        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>DateTime.</returns>
        public static DateTime ToDate(this object data)
        {
            try
            {
                if (data == null)
                    return DateTime.MinValue;
                if (System.Text.RegularExpressions.Regex.IsMatch(data.ToString(), @"^\d{8}$"))
                {
                    string strValue = data.ToString();
                    return new DateTime(strValue.Substring(0, 4).ToInt(), strValue.Substring(4, 2).ToInt(), strValue.Substring(6, 2).ToInt());
                }
                DateTime result;
                return DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        #endregion

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>System.String.</returns>
        public static string ToString(this object data)
        {
            return data == null ? string.Empty : data.ToString();
        }
    }
}

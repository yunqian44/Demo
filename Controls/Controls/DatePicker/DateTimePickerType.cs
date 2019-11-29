using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC.Controls.Controls.DatePicker
{
    public enum DateTimePickerType
    {
        /// <summary>
        /// 日期时间
        /// </summary>
        [Description("日期时间")]
        DateTime = 1,

        /// <summary>
        /// 日期
        /// </summary>
        [Description("日期")]
        Date = 2,

        /// <summary>
        /// 时间
        /// </summary>
        [Description("时间")]
        Time = 3
    }
}

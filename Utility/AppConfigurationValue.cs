using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    internal static class AppConfigurationValue
    {
        /// <summary>
        /// 登录多久未操作提示登录过期
        /// </summary>
        public static int OverTimeSpanMinute
        {
            get
            {
                int minute = 60;
                var OverTimeSpanHour = ConfigurationManager.AppSettings["OverTimeSpanMinute"];
                 int.TryParse(OverTimeSpanHour, out minute);
                return minute;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Common
{
    public class TimeHelper
    {

        //获取指定日期当周的周一日期和周日日期
        public List<DateTime> getThisWeekSE(DateTime dt) {
            List<DateTime> ld = new List<DateTime>();
            int dayofweek = (int)dt.DayOfWeek == 0 ? 7 : (int)dt.DayOfWeek;
            DateTime dt1 = dt.AddDays(-dayofweek+1);
            DateTime dt2 = dt.AddDays(7 - dayofweek);
            ld.Add(dt1);
            ld.Add(dt2);
            return ld;
        }
    }
}

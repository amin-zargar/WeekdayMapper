using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekDayMapper.Domain.Enums
{
    public enum Weekday
    {
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    // Numbers assigned to verify the returning JSON
    public enum ShortWeekday
    {
        None = 0,
        Sat = 11, 
        Sun = 22, 
        Mon = 33, 
        Tue = 44, 
        Wed = 55, 
        Thu = 66, 
        Fri = 77
    }
}

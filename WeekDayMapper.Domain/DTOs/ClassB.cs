using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekDayMapper.Domain.Enums;

namespace WeekDayMapper.Domain.DTOs
{
    public class ClassB
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string WeekdayName { get; set; }
        public Weekday Weekday { get; set; }
        public ShortWeekday Shortweekday { get; set; }
    }
}

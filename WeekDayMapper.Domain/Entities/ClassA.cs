using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekDayMapper.Domain.Enums;
using WeekDayMapper.Domain.Shared;

namespace WeekDayMapper.Domain.Entities
{
    public class ClassA
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public Weekday Weekday { get; set; }
    }
}

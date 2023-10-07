using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using WeekDayMapper.Domain.DTOs;
using WeekDayMapper.Domain.Entities;
using WeekDayMapper.Domain.Enums;

namespace WeekDayMapper.Application.Mappings
{
    public class ClassAProfile : Profile
    {
        public ClassAProfile()
        {
            CreateMap<ClassA, ClassB>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FName} {src.LName}"))
                .ForMember(dest => dest.WeekdayName,
                    opt => opt.MapFrom(src => src.Weekday.ToString()))
                .AfterMap((src, dest) =>
                {
                    dest.Shortweekday = src.Weekday switch
                    {
                        Weekday.Saturday => ShortWeekday.Sat,
                        Weekday.Sunday => ShortWeekday.Sun,
                        Weekday.Monday => ShortWeekday.Mon,
                        Weekday.Tuesday => ShortWeekday.Tue,
                        Weekday.Wednesday => ShortWeekday.Wed,
                        Weekday.Thursday => ShortWeekday.Thu,
                        Weekday.Friday => ShortWeekday.Fri,
                        _ => ShortWeekday.None
                    };
                });
            CreateMap<ClassC, ClassA>();
        }
    }
}

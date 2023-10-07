using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Domain.Entities;

namespace WeekDayMapper.Application.UseCases.Classes
{
    public class CreateClassACommand : IRequest<ClassA>
    {
        public ClassA ClassA { get; set; }
    }
}

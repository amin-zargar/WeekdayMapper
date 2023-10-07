using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Domain.Entities;

namespace WeekDayMapper.Application.Queries
{
    public class GetMemberByEmailQuery : IRequest<Member>
    {

    }
}

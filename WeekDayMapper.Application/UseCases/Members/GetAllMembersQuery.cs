using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Domain.Entities;

namespace WeekDayMapper.Application.UseCases.Members
{
    public class GetAllMembersQuery : IRequest<List<Member>>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Application.UseCases.Members.Authentication;
using WeekDayMapper.Domain.Shared;

namespace WeekDayMapper.Application.UseCases.Members
{
    public class LoginCommand : IRequest<bool>
    {
        public TokenGenerationRequest TokenGenerationRequest { get; set; }
    }
}

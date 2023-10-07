using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekDayMapper.Application.UseCases.Members.Authentication;
using WeekDayMapper.Domain.Entities;

namespace WeekDayMapper.Application.Interfaces
{
    public interface IJwtProvider
    {
        string Generate(TokenGenerationRequest request);
    }
}

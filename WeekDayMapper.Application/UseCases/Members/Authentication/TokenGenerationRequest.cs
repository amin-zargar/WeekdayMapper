using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekDayMapper.Application.UseCases.Members.Authentication
{
    public record TokenGenerationRequest(string Email, CustomClaim[] CustomClaims);
}

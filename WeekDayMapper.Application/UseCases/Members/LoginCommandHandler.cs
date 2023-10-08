using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Domain;
using WeekDayMapper.Application.UseCases.Classes;
using WeekDayMapper.Application.Repositories;
using WeekDayMapper.Application.UseCases.Members;
using WeekDayMapper.Application.UseCases.Members.Authentication;
using WeekDayMapper.Domain.Entities;
using WeekDayMapper.Domain.Shared;

namespace WeekDayMapper.Application.UseCases.Members
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
    {
        private readonly IMemberRepository _memberRepository;

        public LoginCommandHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Member? member = await _memberRepository.GetByEmailAsync(request.TokenGenerationRequest.Email);
            return member is not null;
        }

        
    }
}

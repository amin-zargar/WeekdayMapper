using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Domain;
using WeekDayMapper.Application.UseCases.Classes;
using WeekDayMapper.Application.Interfaces;
using WeekDayMapper.Application.Repositories;
using WeekDayMapper.Application.UseCases.Members;
using WeekDayMapper.Domain.Entities;
using WeekDayMapper.Domain.Shared;

namespace WeekDayMapper.Application.UseCases.Members
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IMemberRepository memberRepository, IJwtProvider jwtProvider)
        {
            _memberRepository = memberRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Member? member = await _memberRepository.GetByEmailAsync(request.TokenGenerationRequest.Email);

            if (member is null)
                return string.Empty;

            // Generate JWT
            string token = _jwtProvider.Generate(request.TokenGenerationRequest);

            // Return JWT
            return token;
        }
    }
}

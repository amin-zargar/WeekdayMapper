using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Domain.Entities;
using WeekDayMapper.Application.Repositories;

namespace WeekDayMapper.Application.UseCases.Members
{
    public class GetAllMembersQueryHndler : IRequestHandler<GetAllMembersQuery, List<Member>>
    {
        private readonly IMemberRepository _memberRepository;

        public GetAllMembersQueryHndler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<List<Member>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var results = await _memberRepository.GetAll();
            return results;
        }
    }
}

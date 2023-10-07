using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Execution;
using WeekDayMapper.Application.Repositories;
using Member = WeekDayMapper.Domain.Entities.Member;

namespace WeekDayMapper.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private static List<Member> _listMember = new List<Member>()
        {
            new Member() { Name  = "Amin", Email = "amin.zargar@gmail.com" },
            new Member() { Name = "Afshin", Email = "afshin.zavvar@gmail.com"}
        };

        public Task<List<Member>> GetAll()
        {
            return Task.FromResult(_listMember);
        }

        public async Task<Member?> GetByEmailAsync(string email)
        {
            var member = _listMember.FirstOrDefault(x => x.Email.ToLower().Equals(email.ToLower()));
            if (member is not null)
            {
                return await Task.FromResult(member);
            }

            return null;
        }
    }
}

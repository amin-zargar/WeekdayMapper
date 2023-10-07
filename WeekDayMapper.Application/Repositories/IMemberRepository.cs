using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member = WeekDayMapper.Domain.Entities.Member;

namespace WeekDayMapper.Application.Repositories
{
    public interface IMemberRepository
    {
        Task<Member?> GetByEmailAsync(string email);
        Task<List<Member>> GetAll();
    }
}

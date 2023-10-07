using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekDayMapper.Domain.DTOs;
using WeekDayMapper.Domain.Entities;

namespace WeekDayMapper.Application.Repositories
{
    public interface IClassARepository
    {
        Task<List<ClassA>> GetAll();
        Task<ClassA> Create(ClassA classA);
        Task<ClassA?> Update(ClassA classA);
        Task<bool> Delete(Guid id);
    }
}

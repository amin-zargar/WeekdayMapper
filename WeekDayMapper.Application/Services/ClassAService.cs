using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeekDayMapper.Application.Interfaces;
using WeekDayMapper.Application.Repositories;
using WeekDayMapper.Domain.Entities;

namespace WeekDayMapper.Application.Services
{
    public class ClassAService : IClassAService
    {
        private readonly IClassARepository _classARepository;

        public ClassAService(IClassARepository classARepository)
        {
            _classARepository = classARepository;
        }

        public async Task<List<ClassA>> GetClassAListAsync()
        {
            var result = await _classARepository.GetAll();
            return result;
        }

        public async Task<ClassA> CreateClassAAsync(ClassA classA)
        {
            var result = await _classARepository.Create(classA);
            return classA;
        }

        public async Task<ClassA?> UpdateClassAAsync(ClassA classA)
        {
            var result = await _classARepository.Update(classA);
            return result;
        }
    }
}

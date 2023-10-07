using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WeekDayMapper.Application.Repositories;
using WeekDayMapper.Domain.Entities;
using WeekDayMapper.Domain.Enums;

namespace WeekDayMapper.Infrastructure.Repositories
{
    public class ClassARepository : IClassARepository
    {
        private static List<ClassA> _listClassA = new List<ClassA>()
        {
            new ClassA() { Id = Guid.NewGuid(), FName = "Amin", LName = "Zargar", Weekday = Weekday.Saturday },
            new ClassA() { Id = Guid.NewGuid(), FName = "Afshin", LName = "Zavvar", Weekday = Weekday.Sunday }
        };

        public async Task<List<ClassA>> GetAll()
        {
            return await Task.FromResult(_listClassA);
        }

        public async Task<ClassA> Create(ClassA classA)
        {
            classA.Id = Guid.NewGuid();
            _listClassA.Add(classA);
            return await Task.FromResult(classA);
        }

        public async Task<ClassA?> Update(ClassA classA)
        {
            var item = _listClassA.FirstOrDefault(x => x.Id == classA.Id);
            if (item != null)
            {
                item.FName = classA.FName;
                item.LName = classA.LName;
                item.Weekday = classA.Weekday;
            }
            return await Task.FromResult(item);
        }

        public async Task<bool> Delete(Guid id)
        {
            var item = _listClassA.FirstOrDefault(x => x.Id == id);
            
            if (item is null)
            {
                return false;
            }

            _listClassA.Remove(item);
            return true;
        }
    }
}

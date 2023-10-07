using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Application.Queries;
using WeekDayMapper.Application.Repositories;
using WeekDayMapper.Domain.Entities;

namespace WeekDayMapper.Application.UseCases.Classes
{
    public class GetAllClassAQueryHandler : IRequestHandler<GetAllClassAQuery, List<ClassA>>
    {
        private readonly IClassARepository _classARepository;

        public GetAllClassAQueryHandler(IClassARepository classARepository)
        {
            _classARepository = classARepository;
        }

        public async Task<List<ClassA>> Handle(GetAllClassAQuery request, CancellationToken cancellationToken)
        {
            var results = await _classARepository.GetAll();
            return results;
        }
    }
}

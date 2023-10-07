using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Application.UseCases.Classes;
using WeekDayMapper.Application.Repositories;
using WeekDayMapper.Domain.Entities;

namespace WeekDayMapper.Application.UseCases.Classes
{
    public class UpdateClassACommandHandler : IRequestHandler<UpdateClassACommand, ClassA>
    {
        private readonly IClassARepository _classARepository;

        public UpdateClassACommandHandler(IClassARepository classARepository)
        {
            _classARepository = classARepository;
        }

        public async Task<ClassA?> Handle(UpdateClassACommand request, CancellationToken cancellationToken)
        {
            var result = await _classARepository.Update(request.ClassA);
            return result;
        }
    }
}

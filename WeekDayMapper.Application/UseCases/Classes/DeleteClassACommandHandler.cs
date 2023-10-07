using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeekDayMapper.Application.Repositories;

namespace WeekDayMapper.Application.UseCases.Classes
{
    public class DeleteClassACommandHandler : IRequestHandler<DeleteClassACommand, bool>
    {
        private readonly IClassARepository _classARepository;

        public DeleteClassACommandHandler(IClassARepository classARepository)
        {
            _classARepository = classARepository;
        }

        public async Task<bool> Handle(DeleteClassACommand request, CancellationToken cancellationToken)
        {
            var result = await _classARepository.Delete(request.Id);
            return result;
        }
    }
}

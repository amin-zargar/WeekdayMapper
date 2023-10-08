using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeekDayMapper.Application.UseCases.Classes;
using WeekDayMapper.Application.Queries;
using WeekDayMapper.Domain.DTOs;
using WeekDayMapper.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using WeekDayMapper.Infrastructure.Authentication.Identity;

namespace WeekDayMapper.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeekdaysController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WeekdaysController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var results = await _mediator.Send(new GetAllClassAQuery());
            List<ClassB> listClassB = _mapper.Map<List<ClassB>>(results);
            return Ok(listClassB);
        }

        [Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateClassA([FromBody] ClassC classC)
        {
            ClassA classA = _mapper.Map<ClassA>(classC);
            var command = new CreateClassACommand() { ClassA = classA };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateClassA([FromBody] ClassA classA)
        {
            var result = await _mediator.Send(new UpdateClassACommand() { ClassA = classA });
            return result is not null ? Ok(result) : NotFound();
        }

        [Authorize( Policy = IdentityData.AdminUserPolicyName)]
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteClassA(Guid id)
        {
            var isDeleted = await _mediator.Send(new DeleteClassACommand() { Id = id });
            return isDeleted ? Ok() : NotFound();
        }
    }
}

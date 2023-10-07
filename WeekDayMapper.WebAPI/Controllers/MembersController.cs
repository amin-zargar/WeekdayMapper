using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeekDayMapper.Application.UseCases.Members;
using WeekDayMapper.Application.UseCases.Members.Authentication;

namespace WeekDayMapper.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginMember([FromBody] TokenGenerationRequest request)
        {
            var loginCommand = new LoginCommand() { TokenGenerationRequest = request };
            var tokenResult = await _mediator.Send(loginCommand);

            if (!string.IsNullOrEmpty(tokenResult))  
                return Ok(tokenResult);

            return BadRequest("Invalid credentials");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            var results = await _mediator.Send(new GetAllMembersQuery());
            return Ok(results);
        }
    }
}

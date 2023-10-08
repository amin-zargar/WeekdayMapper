using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WeekDayMapper.Application.UseCases.Members;
using WeekDayMapper.Application.UseCases.Members.Authentication;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WeekDayMapper.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private const string TokenSecret = "freediveintothecode";
        private static readonly TimeSpan TokenLifeTime = TimeSpan.FromHours(1);

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("token")]
        public async Task<IActionResult> LoginMember([FromBody] TokenGenerationRequest request)
        {
            var member = _mediator.Send(new LoginCommand() { TokenGenerationRequest = request });
            if (member is null) return NotFound("Member not found");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, request.Email),
                new(JwtRegisteredClaimNames.Email, request.Email)
            };

            foreach (var ClaimPair in request.CustomClaims)
            {
                var jsonElement = JsonSerializer.SerializeToElement(ClaimPair.Value);
                var valueType = jsonElement.ValueKind switch
                {
                    JsonValueKind.True => ClaimValueTypes.Boolean,
                    JsonValueKind.False => ClaimValueTypes.Boolean,
                    JsonValueKind.Number => ClaimValueTypes.Double,
                    _ => ClaimValueTypes.String
                };
                var claim = new Claim(ClaimPair.Key, ClaimPair.Value.ToString()!, valueType);
                claims.Add(claim);
            }

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "Amin",
                Audience = "Afshin",
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var jwt = tokenHandler.WriteToken(token);

            return Ok(jwt);
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

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using W_02.Core.DTOs;
using W_02.Core.Services;

namespace W_02.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IPersonService _service;
        private readonly IMapper _mapper;
        public AuthenticationController(IConfiguration config, IPersonService service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] PersonLoginDto personDto)
        {
            var user = await Authenticate(personDto);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("Username or password is wrong");
        }
        private string Generate(PersonWithDepartmentAndRoleDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Role,user.DepartmantName),
                new Claim(ClaimTypes.Role,user.RoleName)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<PersonWithDepartmentAndRoleDto> Authenticate(PersonLoginDto userDto)
        {
            var hashedPassword = HashManager.GetPasswordHash(userDto.Password, _config["Hash:Key"]);
            var currentUser = _service.Where(x => x.UserName == userDto.UserName && x.Password == hashedPassword).SingleOrDefault();
            if (currentUser != null)
            {
                var currentUserDto =await  _service.GetPersonWithDepartmentAndRole(currentUser.Id);
                return currentUserDto;
            }
            return null;
        }
        private PersonWithDepartmentAndRoleDto GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new PersonWithDepartmentAndRoleDto
                {
                    UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                };
            }
            return null;
        }
    }
}

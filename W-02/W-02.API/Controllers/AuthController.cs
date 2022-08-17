using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using W_02.Core.DTOs;
using W_02.Core.Models;
using W_02.Core.Services;

namespace W_02.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IService<Department> _departmentService;
        private readonly IService<Role> _roleService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthController(IPersonService service, IMapper mapper, IService<Department> departmentService, IService<Role> roleService, IConfiguration config)
        {
            _personService = service;
            _mapper = mapper;
            _departmentService = departmentService;
            _roleService = roleService;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] PersonLoginDto personDto)
        {
            var user = await Authenticate(personDto);
            if (user != null)
            {
                var token = Generate(user);
                var refreshToken = GenerateRefreshToken();
                var person = await _personService.Where(x => x.UserName == personDto.UserName).AsNoTracking().FirstOrDefaultAsync();
                await UpdateRefreshTokenDb(person, refreshToken);
                return Ok(new Token { JwtToken = token, RefreshToken = refreshToken });
            }
            return NotFound("Username or password is wrong");
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken(Token token)
        {
            var person = await _personService.Where(x => x.RefreshToken == token.RefreshToken).AsNoTracking().FirstOrDefaultAsync();
            if (person == null) return NotFound("Token not found");
            if (person.TokenExpireDate < DateTime.UtcNow) return BadRequest("Token expired");

            var username = GetJwtTokenUsername(token.JwtToken);
            if (person.UserName != username) return BadRequest("Jwt Token is invalid");
            var currentUserDto = await _personService.GetPersonWithDepartmentAndRole(person.Id);
            var jtwToken = Generate(currentUserDto);
            var newRefreshToken = GenerateRefreshToken();
            await UpdateRefreshTokenDb(person, newRefreshToken);
            return Ok(new Token { JwtToken = jtwToken, RefreshToken = newRefreshToken });

        }
        #region private Authorize functions
        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                    ValidateLifetime = false
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    return null;
                return principal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private string Generate(PersonWithDepartmentAndRoleDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Role,user.DepartmentName),
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
            var currentUser = _personService.Where(x => x.UserName == userDto.UserName && x.Password == hashedPassword).AsNoTracking().SingleOrDefault();
            if (currentUser != null)
            {
                var currentUserDto = await _personService.GetPersonWithDepartmentAndRole(currentUser.Id);
                return currentUserDto;
            }
            return null;
        }
        private string GetJwtTokenUsername(string token)
        {
            var principal = GetPrincipalFromExpiredToken(token);
            if (principal == null) return null;

            var identity = principal.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            }
            return null;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private async Task UpdateRefreshTokenDb(Person person, string token)
        {
            person.RefreshToken = token;
            person.TokenExpireDate = DateTime.UtcNow.AddDays(14);
            await _personService.UpdateAsync(person);
        }
        #endregion
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using MovieDB.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MovieDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IService<Role> _roleService;

        public AuthController(IMapper mapper, IUserService service, IConfiguration config, IService<Role> roleService)
        {
            _mapper = mapper;
            _service = service;
            _config = config;
            _roleService = roleService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UserLoginDto userDto)
        {
            var user = await Authenticate(userDto);
            if (user != null)
            {
                var token =await  Generate(user);
                var refreshToken = GenerateRefreshToken();
                var person = await _service.Where(x => x.Username == userDto.Username).AsNoTracking().FirstOrDefaultAsync();
                await UpdateRefreshTokenDb(person, refreshToken);
                return Ok(new Token { JwtToken = token, RefreshToken = refreshToken });
            }
            return NotFound("Username or password is wrong");
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(UserAddDto userAddDto)
        {
            var nameControl = await _service.Where(x => x.Username == userAddDto.Username).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null) return Conflict("This username already exist");

            var emailControl = await _service.Where(x => x.Email == userAddDto.Email).AsNoTracking().FirstOrDefaultAsync();
            if (emailControl != null) return Conflict("This email already exist");

            userAddDto.Password = HashManager.GetPasswordHash(userAddDto.Password, _config["Hash:Key"]);
            var mapped = _mapper.Map<User>(userAddDto);
            mapped.RoleId = 2;
            await _service.AddAsync(mapped);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken(Token token)
        {
            var person = await _service.Where(x => x.RefreshToken == token.RefreshToken).AsNoTracking().FirstOrDefaultAsync();
            if (person == null) return NotFound("Token not found");
            if (person.TokenEndDate < DateTime.UtcNow) return BadRequest("Token expired");

            var username = GetJwtTokenUsername(token.JwtToken);
            if (person.Username != username) return BadRequest("Jwt Token is invalid");
            var jtwToken =await Generate(person);
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
        private async Task<string> Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRole=await _roleService.GetByIdAsync(user.RoleId);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,userRole.Name)       
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<User> Authenticate(UserLoginDto userDto)
        {
            var hashedPassword = HashManager.GetPasswordHash(userDto.Password, _config["Hash:Key"]);
            var currentUser = _service.Where(x => x.Username == userDto.Username && x.Password == hashedPassword).AsNoTracking().SingleOrDefault();
            return currentUser;
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
        private async Task UpdateRefreshTokenDb(User user, string token)
        {
            user.RefreshToken = token;
            user.TokenEndDate = DateTime.UtcNow.AddDays(14);
            await _service.UpdateAsync(user);
        }
        #endregion
    }
}


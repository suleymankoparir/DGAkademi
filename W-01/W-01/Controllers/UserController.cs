using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using W_01.Core.DTOs;
using W_01.Core.Models;
using W_01.Core.Services;

namespace W_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IService<User> _service;
        private readonly IMapper _mapper;

        public UserController(IConfiguration config, IService<User> service, IMapper mapper)
        {
            _config = config;
            _service = service;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            var user = Authenticate(userDto);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(UserDto userDto)
        {
            userDto.Password=GetPasswordHash(userDto.Password);
            var user=_service.Where(x=>x.UserName==userDto.UserName).SingleOrDefault();
            if (user != null)
                return Conflict("This username is already exist");
            user=_mapper.Map<User>(userDto);
            await _service.AddAsync(user);
            return Ok("Sign up is successful, for accessing to system please login");
        }
        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserDto userDto)
        {
            var hashedPassword =GetPasswordHash(userDto.Password);
            var currentUser = _service.Where(x => x.UserName == userDto.UserName && x.Password == hashedPassword).SingleOrDefault();
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new User
                {
                    UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                };
            }
            return null;
        } 
        private String GetPasswordHash(String text)
        {
            string key = _config["Hash:Key"];
            ASCIIEncoding encoding = new ASCIIEncoding();

            Byte[] textBytes = encoding.GetBytes(text);
            Byte[] keyBytes = encoding.GetBytes(key);

            Byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}

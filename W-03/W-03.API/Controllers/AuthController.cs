using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System;
using W_03.Core.Entities;
using W_03.Core.Services;
using W_03.Core.Views;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using W_03.Core.DTOs;

namespace W_03.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IService<User> _service;
        private readonly IService<UserInformation> _serviceInformation;
        private readonly IService<UserPermission> _servicePermission;
        private readonly IService<PreRegistration> _servicePreRegistration;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthController(IService<User> service, IMapper mapper, IConfiguration config, IService<UserInformation> serviceInformation, IService<UserPermission> servicePermission, IService<PreRegistration> servicePreRegistration, IMailService mailService)
        {
            _service = service;
            _mapper = mapper;
            _config = config;
            _serviceInformation = serviceInformation;
            _servicePermission = servicePermission;
            _servicePreRegistration = servicePreRegistration;
            _mailService = mailService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(UserLoginView user)
        {
            var auth=await Authenticate(user);
            if (auth!=null)
            {
                var token = Generate(user);
                var data = new JwtUserListView();
                data.JwtToken = token;
                var users = await _service.Where(x => x.DeletedAt == DateTime.MinValue).AsNoTracking().ToListAsync();
                data.Users = _mapper.Map<List<UserDto>>(users);
                return Ok(data);
            }
            return NotFound("Username or password is wrong");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Registration(PreRegisteredUserRegistrationView view)
        {
            var pre = await _servicePreRegistration.Where(x => x.Hash == view.Hash && x.DeletedAt == DateTime.MinValue).FirstOrDefaultAsync();
            if (pre == null) return NotFound("PreRegistration not found");

            if (pre.EndDate < DateTime.UtcNow)
            {
                pre.DeletedAt = DateTime.UtcNow;
                await _servicePreRegistration.UpdateAsync(pre); 
                return BadRequest("Hash time ended");
            }
                

            var permissionControl = await _servicePermission.Where(x => x.Id == view.UserPermissionId && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (permissionControl == null) return NotFound("Permission not found");

            view.Password = HashManager.GetPasswordHash(view.Password, _config["Hash:Key"]);
            var mapped = _mapper.Map<User>(view);
            mapped.CreatedAt= DateTime.UtcNow;
            mapped.Email = pre.Email;
            var user = await _service.AddAsync(mapped);

            var mappedInfo = _mapper.Map<UserInformation>(view);
            mappedInfo.UserId = user.Id;
            mappedInfo.CreatedAt = DateTime.UtcNow;

            await _serviceInformation.AddAsync(mappedInfo);

            pre.DeletedAt=DateTime.UtcNow;
            await _servicePreRegistration.UpdateAsync(pre);
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> PreRegistration(PreRegistrationView view)
        {
            var emailControl = await _service.Where(x => x.Email == view.Email && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (emailControl != null) return Conflict("Email exist");

            var emailControl2 = await _servicePreRegistration.Where(x => x.Email == view.Email && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (emailControl2 != null) return Conflict("Email exist");

            var mapped= _mapper.Map<PreRegistration>(view);
            mapped.CreatedAt=DateTime.UtcNow;
            mapped.EndDate = DateTime.UtcNow.AddDays(7);
            mapped.Hash = GenerateHash();
            

            MailRequest mailRequest = new MailRequest();
            mailRequest.Subject = "W03 PreRegistration Hash";
            mailRequest.Body = mapped.Hash;
            mailRequest.ToEmail = mapped.Email;

            await _servicePreRegistration.AddAsync(mapped);
            await _mailService.SendEmailAsync(mailRequest);

            return Ok();
        }
        #region private Authorize functions
        private string Generate(UserLoginView user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<UserLoginView> Authenticate(UserLoginView user)
        {
            var hashedPassword = HashManager.GetPasswordHash(user.Password, _config["Hash:Key"]);
            var currentUser = _service.Where(x => x.Email == user.Email && x.Password == hashedPassword && x.DeletedAt == DateTime.MinValue).AsNoTracking().SingleOrDefault();
            if (currentUser != null)
            {
                return user;
            }
            return null;
        }
        private string GenerateHash()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        #endregion
    }
}

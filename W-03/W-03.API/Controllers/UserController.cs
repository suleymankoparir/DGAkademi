using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using W_03.Core.Entities;
using W_03.Core.Services;
using W_03.Core.Views;

namespace W_03.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _service;
        private readonly IService<UserInformation> _serviceInformation;
        private readonly IService<UserPermission> _servicePermission;
        private readonly IService<Sale> _serviceSale;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(IService<User> service, IService<UserInformation> serviceInformation, IService<UserPermission> servicePermission, IMapper mapper, IConfiguration config, IService<Sale> serviceSale)
        {
            _service = service;
            _serviceInformation = serviceInformation;
            _servicePermission = servicePermission;
            _mapper = mapper;
            _config = config;
            _serviceSale = serviceSale;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var currentId = GetCurrentUserId();
            if (currentId == null) return BadRequest("Error in auth");
            if (currentId != id) return BadRequest("Forbidden access, user can only operate with her own id");
            var user = await _service.Where(x => x.Id == currentId && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (user == null) return NotFound("User not found");


            var userInfo=await _serviceInformation.Where(x => x.UserId == user.Id && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            var userPermission = await _servicePermission.Where(x => x.Id == user.UserPermissionId && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            var sales=await _serviceSale.Where(x=>x.UserId==id && x.DeletedAt == DateTime.MinValue).AsNoTracking().ToListAsync();
            var mapped = _mapper.Map<UserInfoView>(userInfo);
            mapped.Email = user.Email;
            mapped.Sales = _mapper.Map<List<SaleView>>(sales);
            mapped.UserPermissionId = userPermission.Id;
            mapped.PermissionName=userPermission.Name;

            return Ok(mapped);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UserInformationUpdateView view)
        {
            var currentId = GetCurrentUserId();
            if (currentId == null) return BadRequest("Error in auth");
            if (currentId != id) return BadRequest("Forbidden access, user can only operate with her own id");
            var user = await _service.Where(x => x.Id == currentId && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (user == null) return NotFound("User not found");

            var userInformation = await _serviceInformation.Where(x => x.UserId == user.Id && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            var mapped = _mapper.Map<UserInformation>(view);
            mapped.Id = userInformation.Id;
            mapped.UserId = userInformation.UserId;
            mapped.CreatedAt = userInformation.CreatedAt;
            mapped.UpdatedAt = DateTime.UtcNow;
            await _serviceInformation.UpdateAsync(mapped);
            return Ok();
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var currentId = GetCurrentUserId();
            if (currentId == null) return BadRequest("Error in auth");
            if (currentId != id) return BadRequest("Forbidden access, user can only operate with her own id");
            var user = await _service.Where(x => x.Id == currentId && x.DeletedAt == DateTime.MinValue).AsNoTracking().FirstOrDefaultAsync();
            if (user == null) return NotFound("User not found");

            var userInformation = await _serviceInformation.Where(x => x.UserId == currentId).FirstOrDefaultAsync();


            user.DeletedAt = DateTime.UtcNow;
            userInformation.DeletedAt = DateTime.UtcNow;

            await _service.UpdateAsync(user);
            await _serviceInformation.UpdateAsync(userInformation);


            return Ok();
        }
        private int? GetCurrentUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                string? idStr = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.SerialNumber)?.Value;
                if (idStr == null) return null;
                return Convert.ToInt32(idStr);
            }
            return null;
        }
    }
}

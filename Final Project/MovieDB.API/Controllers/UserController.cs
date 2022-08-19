using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using MovieDB.Core.Services;

namespace MovieDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(IUserService service, IMapper mapper, IConfiguration config)
        {
            _service = service;
            _mapper = mapper;
            _config = config;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll().ToListAsync();
            var mapped=_mapper.Map<List<UserGetDto>>(data);
            return Ok(mapped);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nameControl = await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl == null) return NotFound("User not found");
            var mapped =_mapper.Map<UserGetDto>(nameControl);
            return Ok(mapped);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllData()
        {
            var data = await _service.getAllData();
            return Ok(data);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetDataById(int id)
        {
            var nameControl = await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl == null) return NotFound("User not found");
            var data = await _service.GetAllWithDataById(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var nameControl = await _service.Where(x => x.Username == userAddDto.Username).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null) return Conflict("This username already exist");

            var emailControl = await _service.Where(x => x.Email == userAddDto.Email).AsNoTracking().FirstOrDefaultAsync();
            if (emailControl != null) return Conflict("This email already exist");

            userAddDto.Password = HashManager.GetPasswordHash(userAddDto.Password, _config["Hash:Key"]);
            var mapped = _mapper.Map<User>(userAddDto);
            await _service.AddAsync(mapped);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound("User not found");

            await _service.RemoveAsync(data);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var dataControl = await _service.Where(x=>x.Id==userUpdateDto.Id).AsNoTracking().FirstOrDefaultAsync();
            if (dataControl == null) return NotFound("User not found");

            var nameControl = await _service.Where(x => x.Id != userUpdateDto.Id && x.Username == userUpdateDto.Username).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null) return Conflict("Username already exist for different id");

            var emailControl = await _service.Where(x => x.Id != userUpdateDto.Id && x.Email == userUpdateDto.Email).AsNoTracking().FirstOrDefaultAsync();
            if (emailControl != null) return Conflict("Email already exist for different id");

            userUpdateDto.Password = HashManager.GetPasswordHash(userUpdateDto.Password, _config["Hash:Key"]);
            var mapped=_mapper.Map<User>(userUpdateDto);
            await _service.UpdateAsync(mapped);
            return Ok();
        }
    }
}

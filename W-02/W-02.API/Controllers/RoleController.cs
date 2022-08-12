using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using W_02.Core.DTOs;
using W_02.Core.Models;
using W_02.Core.Services;

namespace W_02.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class RoleController : ControllerBase
    {
        private readonly IService<Role> _service;
        private readonly IMapper _mapper;
        private readonly IService<Person> _personService;
        public RoleController(IService<Role> service, IMapper mapper, IService<Person> personService)
        {
            _service = service;
            _mapper = mapper;
            _personService = personService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _service.GetAll().ToListAsync();
            var rolesDto=_mapper.Map<List<RoleDto>>(roles);
            return Ok(rolesDto);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _service.GetByIdAsync(id);
            if (role == null)
                return NotFound();
            var roleDto = _mapper.Map<RoleDto>(role);
            return Ok(roleDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(RoleAddDto data)
        {
            var nameControl = await _service.Where(x => x.Name == data.Name).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null)
                return Conflict("Role name already exist");
            var role = _mapper.Map<Role>(data);
            await _service.AddAsync(role);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(RoleUpdateDto data)
        {
            var idControl = await _service.Where(x => x.Id == data.Id).AsNoTracking().FirstOrDefaultAsync();
            if (idControl == null)
                return NotFound();
            var nameControl = await _service.Where(x => x.Id != data.Id && x.Name == data.Name).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null)
                return Conflict("Role name already exist");
            var mapped = _mapper.Map<Role>(data);
            await _service.UpdateAsync(mapped);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync() == null)
                return NotFound();
            var foreignControl = await _personService.Where(x => x.RoleId == id).AsNoTracking().FirstOrDefaultAsync();
            if (foreignControl != null)
                return Conflict("There is data associated with this id");
            var role = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(role);
            return Ok();
        }
    }
}

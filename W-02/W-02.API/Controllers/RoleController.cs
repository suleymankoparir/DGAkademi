using AutoMapper;
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
    public class RoleController : ControllerBase
    {
        private readonly IService<Role> _service;
        private readonly IMapper _mapper;
        public RoleController(IService<Role> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _service.GetAll().ToListAsync();
            var rolesDto=_mapper.Map<List<RoleDto>>(roles);
            return Ok(rolesDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _service.GetByIdAsync(id);
            if (role == null)
                return NotFound();
            var roleDto = _mapper.Map<RoleDto>(role);
            return Ok(roleDto);
        }
    }
}

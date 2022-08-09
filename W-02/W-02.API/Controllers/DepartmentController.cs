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
    public class DepartmentController : ControllerBase
    {
        private readonly IService<Department> _service;
        private readonly IMapper _mapper;

        public DepartmentController(IService<Department> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _service.GetAll().ToListAsync(); ;
            var departmentsDto=_mapper.Map<List<DepartmentDto>>(departments);
            return Ok(departmentsDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _service.GetByIdAsync(id);
            if(department == null)
                return NotFound();
            var roleDto = _mapper.Map<DepartmentDto>(department);
            return Ok(roleDto);
        }
    }
}

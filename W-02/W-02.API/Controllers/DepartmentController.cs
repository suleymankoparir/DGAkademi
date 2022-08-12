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
    public class DepartmentController : ControllerBase
    {
        private readonly IService<Department> _service;
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;

        public DepartmentController(IService<Department> service, IMapper mapper, IService<Person> personService)
        {
            _service = service;
            _mapper = mapper;
            _personService = personService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _service.GetAll().ToListAsync(); ;
            var departmentsDto=_mapper.Map<List<DepartmentDto>>(departments);
            return Ok(departmentsDto);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _service.GetByIdAsync(id);
            if(department == null)
                return NotFound();
            var roleDto = _mapper.Map<DepartmentDto>(department);
            return Ok(roleDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentAddDto data)
        {
            var nameControl=await _service.Where(x=>x.Name==data.Name).AsNoTracking().FirstOrDefaultAsync();
            if(nameControl != null)
                return Conflict("Department name already exist");
            var department=_mapper.Map<Department>(data);
            await _service.AddAsync(department);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(DepartmentUpdateDto data)
        {
            var idControl= await _service.Where(x=>x.Id==data.Id).AsNoTracking().FirstOrDefaultAsync();
            if (idControl == null)
                return NotFound();
            var nameControl = await _service.Where(x => x.Id!=data.Id&&x.Name == data.Name).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null)
                return Conflict("Department name already exist");
            var mapped = _mapper.Map<Department>(data);
            await _service.UpdateAsync(mapped);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _service.Where(x=>x.Id==id).AsNoTracking().FirstOrDefaultAsync()==null)
                return NotFound();
            var foreignControl = await _personService.Where(x => x.DepartmentId == id).AsNoTracking().FirstOrDefaultAsync();
            if (foreignControl!=null)
                return Conflict("There is data associated with this id");
            var department=await _service.GetByIdAsync(id);
            await _service.RemoveAsync(department);
            return Ok();
        }
    }
}

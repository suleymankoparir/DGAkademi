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
    [Authorize(Roles = "Manager,Human Resources")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IService<Department> _departmentService;
        private readonly IService<Role> _roleService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public PersonController(IPersonService service, IMapper mapper, IService<Department> departmentService, IService<Role> roleService, IConfiguration config)
        {
            _personService = service;
            _mapper = mapper;
            _departmentService = departmentService;
            _roleService = roleService;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(PersonSignUpDto personSignUpDto)
        {
            var usernameControl = await _personService.Where(x => x.UserName == personSignUpDto.UserName).FirstOrDefaultAsync();
            if (usernameControl != null)
                ModelState.AddModelError("Username", "Username already registered");
            var role = await _roleService.GetByIdAsync(personSignUpDto.RoleId);
            var department = await _roleService.GetByIdAsync(personSignUpDto.DepartmentId);
            if (role == null)
                ModelState.AddModelError("Role", "Role Id not found");
            if (department == null)
                ModelState.AddModelError("Department", "Department Id not found");
            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
            var person = _mapper.Map<Person>(personSignUpDto);
            person.Password = HashManager.GetPasswordHash(personSignUpDto.Password, _config["Hash:Key"]);
            await _personService.AddAsync(person);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var peopleDto = await _personService.GetPeopleWithDepartmentAndRole();
            return Ok(peopleDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var personDto = await _personService.GetPersonWithDepartmentAndRole(id);
            if (personDto == null)
                return NotFound();
            return Ok(personDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
                return NotFound();
            await _personService.RemoveAsync(person);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(PersonUpdateDto personUpdateDto)
        {
            var person = await _personService.GetByIdAsync(personUpdateDto.Id);
            if (person == null)
                return NotFound();
            if (personUpdateDto.UserName != null)
                if (await _personService.Where(x => x.Id != personUpdateDto.Id && x.UserName == personUpdateDto.UserName).FirstOrDefaultAsync() != null)
                    ModelState.AddModelError("username", "Username already exist for different id");
                else
                    person.UserName = personUpdateDto.UserName;
            if(personUpdateDto.FullName!=null)
                person.FullName = personUpdateDto.FullName;
            if (personUpdateDto.RoleId != null)
                if(await _roleService.GetByIdAsync((int)personUpdateDto.RoleId) == null)
                    ModelState.AddModelError("RoleId", "RoleId does not exist");
                else
                    person.RoleId = (int)personUpdateDto.RoleId;
            if (personUpdateDto.DepartmentId != null)
                if(await _departmentService.GetByIdAsync((int)personUpdateDto.DepartmentId) == null)
                    ModelState.AddModelError("DepartmentId", "DepartmentId does not exist");
                else
                    person.DepartmentId = (int)personUpdateDto.DepartmentId;
            if(personUpdateDto.Password != null)
                person.Password= HashManager.GetPasswordHash(personUpdateDto.Password, _config["Hash:Key"]);
            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
            await _personService.UpdateAsync(person);
            return Ok();
        }
        
    }
}

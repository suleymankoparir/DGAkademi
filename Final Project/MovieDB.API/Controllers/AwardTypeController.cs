using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class AwardTypeController : ControllerBase
    {
        private readonly IAwardTypeService _service;
        private readonly IMapper _mapper;

        public AwardTypeController(IAwardTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll().ToListAsync();
            var mapped = _mapper.Map<List<AwardTypeGetDto>>(data);
            return Ok(mapped);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var idControl = await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (idControl == null) return NotFound("AwardType not found");
            var mapped = _mapper.Map<AwardTypeGetDto>(idControl);
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
            if (nameControl == null) return NotFound("AwardType not found");
            var data = await _service.GetAllWithDataById(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(NameDto nameDto)
        {
            var nameControl = await _service.Where(x => x.Name == nameDto.Name).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null) return Conflict("This Award Type already exist");
            await _service.AddAsync(new AwardType { Name = nameDto.Name });
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound("Award Type not found");

            await _service.RemoveAsync(data);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateNameDto updateNameDto)
        {
            var dataControl = await _service.GetByIdAsync(updateNameDto.Id);
            if (dataControl == null) return NotFound("Award Type not found");

            var nameControl = await _service.Where(x => x.Id != updateNameDto.Id && x.Name == updateNameDto.Name).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null) return Conflict("Name already exist for different id");

            dataControl.Name = updateNameDto.Name;
            await _service.UpdateAsync(dataControl);
            return Ok();
        }
    }
}

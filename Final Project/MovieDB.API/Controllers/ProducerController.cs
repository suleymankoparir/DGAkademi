using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using MovieDB.Core.Services;

namespace MovieDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _service;
        private readonly IMapper _mapper;

        public ProducerController(IProducerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll().ToListAsync();
            var mapped = _mapper.Map<List<ProducerGetDto>>(data);
            return Ok(mapped);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var idControl = await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (idControl == null) return NotFound("Producer not found");
            var mapped = _mapper.Map<ProducerGetDto>(idControl);
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
            if (nameControl == null) return NotFound("Producer not found");
            var data = await _service.GetAllWithDataById(id);
            return Ok(data);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(NameDto nameDto)
        {
            var nameControl = await _service.Where(x => x.Name == nameDto.Name).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null) return Conflict("This producer already exist");
            await _service.AddAsync(new Producer { Name = nameDto.Name });
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound("Producer not found");

            await _service.RemoveAsync(data);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateNameDto updateNameDto)
        {
            var dataControl = await _service.GetByIdAsync(updateNameDto.Id);
            if (dataControl == null) return NotFound("Producer not found");

            var nameControl = await _service.Where(x => x.Id != updateNameDto.Id && x.Name == updateNameDto.Name).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null) return Conflict("Name already exist for different id");

            dataControl.Name = updateNameDto.Name;
            await _service.UpdateAsync(dataControl);
            return Ok();
        }
    }
}

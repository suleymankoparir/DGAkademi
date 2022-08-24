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
    public class PerformerController : ControllerBase
    {
        private readonly IPerformerService _service;
        private readonly IMapper _mapper;

        public PerformerController(IPerformerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll().ToListAsync();
            var mapped = _mapper.Map<List<PerformerGetDto>>(data);
            return Ok(mapped);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var idControl = await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (idControl == null) return NotFound("Performer not found");
            var mapped = _mapper.Map<PerformerGetDto>(idControl);
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
            if (nameControl == null) return NotFound("Performer not found");
            var data = await _service.GetAllWithDataById(id);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(PerformerAddDto data)
        {
            var mapped = _mapper.Map<Performer>(data);
            await _service.AddAsync(mapped);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound("Performer not found");

            await _service.RemoveAsync(data);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(PerformerUpdateDto performerUpdateDto)
        {
            var dataControl = await _service.Where(x=>x.Id==performerUpdateDto.Id).AsNoTracking().FirstOrDefaultAsync();
            if (dataControl == null) return NotFound("Performer not found");

            var mapped =_mapper.Map<Performer>(performerUpdateDto);
            await _service.UpdateAsync(mapped);
            return Ok();
        }
    }
}

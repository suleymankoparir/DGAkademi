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
    public class AwardController : ControllerBase
    {
        private readonly IAwardService _service;
        private readonly IService<AwardType> _awardTypeService;
        private readonly IMapper _mapper;

        public AwardController(IAwardService service, IService<AwardType> awardTypeService, IMapper mapper)
        {
            _service = service;
            _awardTypeService = awardTypeService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.getAllData();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nameControl = await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl == null) return NotFound("Award not found");
            var data = await _service.GetAllWithDataById(id);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound("Award not found");

            await _service.RemoveAsync(data);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AwardAddDto data)
        {
            var nameControl=await _service.Where(x=>x.Name==data.Name).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null) return Conflict("Award name already exist");

            var typeControl=await _awardTypeService.Where(x=>x.Id==data.AwardTypeId).AsNoTracking().FirstOrDefaultAsync();
            if (typeControl == null) return NotFound("AwardType not found");

            var mapped = _mapper.Map<Award>(data);
            await _service.AddAsync(mapped);
            return Ok();

        }
        [HttpPut]
        public async Task<IActionResult> Update(AwardUpdateDto awardUpdateDto)
        {
            var dataControl = await _service.Where(x=>x.Id==awardUpdateDto.Id).AsNoTracking().FirstOrDefaultAsync();
            if (dataControl == null) return NotFound("Award not found");

            var nameControl = await _service.Where(x => x.Id != awardUpdateDto.Id && x.Name == awardUpdateDto.Name).AsNoTracking().FirstOrDefaultAsync();
            if (nameControl != null) return Conflict("Name already exist for different id");

            var typeControl = await _awardTypeService.Where(x => x.Id == awardUpdateDto.AwardTypeId).AsNoTracking().FirstOrDefaultAsync();
            if (typeControl == null) return NotFound("AwardType not found");

            var mapped=_mapper.Map<Award>(awardUpdateDto);
            await _service.UpdateAsync(mapped);
            return Ok();
        }
    }
}

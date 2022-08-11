using AutoMapper;
using ClassStudent.Data;
using ClassStudent.Data.DTOs;
using ClassStudent.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ClassController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _dataContext.Classes.AsNoTracking().ToList();
            var dataDto = _mapper.Map<List<ClassDto>>(data);
            return Ok(dataDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var data= (from x in _dataContext.Classes where x.Id == id select x).FirstOrDefault();
            var data = _dataContext.Classes.Where(x=>x.Id==id).AsNoTracking().FirstOrDefault();
            if (data == null)
                return NotFound();
            var dataDto = _mapper.Map<ClassDto>(data);
            return Ok(dataDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ClassAddDto dataDto)
        {
            //var name= (from x in _dataContext.Classes where x.Name == dataDto.Name select x).FirstOrDefault();
            var name = await _dataContext.Classes.Where(x => x.Name == dataDto.Name).AsNoTracking().FirstOrDefaultAsync();
            if (name != null)
                return Conflict("Name already exist");
            var data = _mapper.Map<Class>(dataDto);
            await _dataContext.Classes.AddAsync(data);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = _dataContext.Classes.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            if (data == null)
                return NotFound();
            _dataContext.Classes.Remove(data);
            _dataContext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(ClassUpdateDto classUpdateDto)
        {
            var data = await _dataContext.Classes.Where(x => x.Id == classUpdateDto.Id).AsNoTracking().FirstOrDefaultAsync();
            var dataName= await _dataContext.Classes.Where(x => x.Name == classUpdateDto.Name&&x.Id!=classUpdateDto.Id).AsNoTracking().FirstOrDefaultAsync();
            if (data == null)
                return NotFound();
            if (dataName != null)
                return Conflict("Name already exist");
            var mapped = _mapper.Map<Class>(classUpdateDto);
            _dataContext.Classes.Update(mapped);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}

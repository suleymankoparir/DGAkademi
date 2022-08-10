﻿using AutoMapper;
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
        public async Task<IActionResult> GetAll()
        {
            var data = await _dataContext.Classes.ToListAsync();
            var dataDto = _mapper.Map<List<ClassDto>>(data);
            return Ok(dataDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data=await _dataContext.Classes.Where(x=>x.Id == id).FirstOrDefaultAsync();
            if(data==null)
                return NotFound();
            var dataDto = _mapper.Map<ClassDto>(data);
            return Ok(dataDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ClassAddDto dataDto)
        {
            var name=await _dataContext.Classes.Where(x=>x.Name==dataDto.Name).FirstOrDefaultAsync();
            if (name != null)
                return Conflict("Name already exist");
            var data = _mapper.Map<Class>(dataDto);
            await _dataContext.Classes.AddAsync(data);
            await _dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}

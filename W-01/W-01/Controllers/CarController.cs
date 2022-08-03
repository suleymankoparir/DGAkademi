using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W_01.Core.DTOs;
using W_01.Core.Models;
using W_01.Core.Services;

namespace W_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IService<BaseCar> _service;
        private readonly IMapper _mapper;

        public CarController(IService<BaseCar> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetInfo()
        {
            var value = _service.GetAllAsync().ToList();
            var valueDto = _mapper.Map<List<BaseCarDto>>(value);
            for (int i = 0; i < valueDto.Count; i++)
            {
                valueDto[i].Brand = value[i].GetType().Name;
            }
            return new ObjectResult(valueDto)
            {
                StatusCode = 200
            };
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetBmw()
        {

            var value = _service.Where(x => x is Bmw).ToList();
            return new ObjectResult(value)
            {
                StatusCode = 200
            };
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetAudi()
        {

            var value = _service.Where(x => x is Audi).ToList();
            return new ObjectResult(value)
            {
                StatusCode = 200
            };
        }
        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetMercedes()
        {

            var value = _service.Where(x => x is Mercedes).ToList();
            return new ObjectResult(value)
            {
                StatusCode = 200
            };
        }

    }
}

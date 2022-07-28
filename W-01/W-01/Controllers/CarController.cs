using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W_01.Core.Models;
using W_01.Core.Services;

namespace W_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IService<BaseCar> _service;

        public CarController(IService<BaseCar> service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetInfo()
        {
            
            var value = _service.GetAllAsync().ToList();          
            return new ObjectResult(value)
            {
                StatusCode = 200
            };
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult GetBmw()
        {

            var value = _service.Where(x=>x is Bmw).ToList();
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

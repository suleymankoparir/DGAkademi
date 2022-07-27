using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using W_01.Context;

namespace W_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetInfo()
        {
            var value = CarContext.Cars;
            return new ObjectResult(value)
            {
                StatusCode = 200
            };
        }
    }
}

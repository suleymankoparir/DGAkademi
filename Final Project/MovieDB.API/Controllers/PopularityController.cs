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
    [Authorize]
    public class PopularityController : ControllerBase
    {
        private readonly IService<Movie> _movieService;
        private readonly IService<Popularity> _popularityService;
        private readonly IMapper _mapper;

        public PopularityController(IService<Movie> movieService, IService<Popularity> popularityService, IMapper mapper)
        {
            _movieService = movieService;
            _popularityService = popularityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _popularityService.GetAll().ToListAsync();
            var mapped = _mapper.Map<List<PopularityGetDto>>(data);
            for (int i = 0; i < mapped.Count; i++)
            {
                var movie = await _movieService.GetByIdAsync(data[i].MovieId);
                mapped[i].Name = movie.Name;
            }

            return Ok(mapped);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _popularityService.GetByIdAsync(id);
            if (data == null) return NotFound("Popularity not found");

            var mapped = _mapper.Map<PopularityGetDto>(data);

            var movie = await _movieService.GetByIdAsync(data.MovieId);
            mapped.Name = movie.Name;

            return Ok(mapped);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Add(PopularityAddDto popularityAddDto)
        {
            var control=await _popularityService.Where(x=>x.MovieId==popularityAddDto.MovieId).FirstOrDefaultAsync();
            if (control != null) return Conflict("This movie already popular");

            var movie=await _movieService.GetByIdAsync(popularityAddDto.MovieId);
            if (movie == null) return NotFound("Movie not found");

            await _popularityService.AddAsync(new Popularity { MovieId = popularityAddDto.MovieId, Since = DateTime.UtcNow });
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var control = await _popularityService.Where(x => x.Id==id).FirstOrDefaultAsync();
            if (control == null) return NotFound("Popularity not found");

            await _popularityService.RemoveAsync(control);
            return Ok();
        }
    }
}

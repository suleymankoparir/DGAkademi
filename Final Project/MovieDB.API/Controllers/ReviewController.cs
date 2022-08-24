using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using MovieDB.Core.Services;
using System.Security.Claims;

namespace MovieDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly IService<Review> _service;
        private readonly IService<User> _serviceUser;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public ReviewController(IService<Review> service, IMapper mapper, IMovieService movieService, IService<User> serviceUser)
        {
            _service = service;
            _mapper = mapper;
            _movieService = movieService;
            _serviceUser = serviceUser;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reviews = await _service.GetAll().ToListAsync();
            var mapped = _mapper.Map<List<ReviewDto>>(reviews);
            return Ok(mapped);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var review=await _service.GetByIdAsync(id);
            if (review == null) return NotFound("Review not found");

            var mapped = _mapper.Map<ReviewDto>(review);
            return Ok(mapped);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ReviewAddDto reviewAddDto)
        {
            var user = await GetCurrentUser();
            if (user == null) return NotFound("User not found");

            var movie=await _movieService.GetByIdAsync(reviewAddDto.MovieId);
            if (movie == null) return NotFound("Movie not found");

            var review=await _service.Where(x=>x.UserId == user.Id&&x.MovieId==movie.Id).FirstOrDefaultAsync();
            if (review != null) return Conflict("Review already exist");

            var mapped=_mapper.Map<Review>(reviewAddDto);
            mapped.UserId=user.Id;
            mapped.Date = DateTime.UtcNow;
            await _service.AddAsync(mapped);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(ReviewUpdateDto reviewDto)
        {
            var user = await GetCurrentUser();
            if (user == null) return NotFound("User not found");

            var movie = await _movieService.GetByIdAsync(reviewDto.MovieId);
            if (movie == null) return NotFound("Movie not found");

            var conf=await _service.Where(x=>x.UserId==user.Id&&x.MovieId==movie.Id&&x.Id!=reviewDto.Id).FirstOrDefaultAsync();
            if (conf != null) return Conflict("For this movie review already exist");

            var rev=await _service.Where(x=>x.Id==reviewDto.Id).AsNoTracking().FirstOrDefaultAsync();
            if (rev == null) return NotFound("Review not found");

            var mapped = _mapper.Map<Review>(reviewDto);
            mapped.Date=DateTime.UtcNow;
            mapped.UserId = user.Id;

            await _service.UpdateAsync(mapped);
            return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await GetCurrentUser();
            if (user == null) return NotFound("User not found");

            var rev = await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (rev == null) return NotFound("Review not found");

            if (rev.UserId != user.Id) return BadRequest("User does not owner of this review");

            await _service.RemoveAsync(rev);
            return Ok();

        }
        private async Task<User> GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                string? username = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                if(username != null)
                    return await _serviceUser.Where(x=>x.Username==username).AsNoTracking().FirstOrDefaultAsync();
            }
            return null;
        }

    }
}

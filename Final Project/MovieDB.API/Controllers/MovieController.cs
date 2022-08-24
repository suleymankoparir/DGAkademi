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
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        private readonly IService<Category> _categoryService;
        private readonly IService<Movie> _movieService;
        private readonly IService<Director> _directorService;
        private readonly IService<Producer> _producerService;
        private readonly IService<Award> _awardService;
        private readonly IService<Performer> _performerService;

        private readonly IService<MovieAward> _movieAwardService;
        private readonly IService<MovieCategory> _movieCategoryService;
        private readonly IService<MovieProducer> _movieProducerService;
        private readonly IService<MovieDirector> _movieDirectorService;
        private readonly IService<MoviePerformer> _moviePerformerService;
        private readonly IService<AwardType> _awardTypeService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService service, IMapper mapper, IService<Category> categoryService, IService<Movie> movieService, IService<Director> directorService, IService<Producer> producerService, IService<Award> awardService, IService<Performer> performerService, IService<MovieAward> movieAwardService, IService<MovieCategory> movieCategoryService, IService<MovieProducer> movieProducerService, IService<MovieDirector> movieDirectorService, IService<MoviePerformer> moviePerformerService, IService<AwardType> awardTypeService)
        {
            _service = service;
            _mapper = mapper;
            _categoryService = categoryService;
            _movieService = movieService;
            _directorService = directorService;
            _producerService = producerService;
            _awardService = awardService;
            _performerService = performerService;
            _movieAwardService = movieAwardService;
            _movieCategoryService = movieCategoryService;
            _movieProducerService = movieProducerService;
            _movieDirectorService = movieDirectorService;
            _moviePerformerService = moviePerformerService;
            _awardTypeService = awardTypeService;
        }
        #region Crud Endpoints
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll().ToListAsync();
            var mapped = _mapper.Map<List<MovieGetDto>>(data);
            return Ok(mapped);
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var idControl = await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (idControl == null) return NotFound("Movie not found");
            var mapped = _mapper.Map<MovieGetDto>(idControl);
            return Ok(mapped);
        }
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> GetAllData()
        {
            var data = await _service.getAllData();
            return Ok(data);
        }
        [HttpGet("[action]/{id}")]
        [Authorize]
        public async Task<IActionResult> GetDataById(int id)
        {
            var data = await _service.GetAllWithDataById(id);
            if (data == null)
                return NotFound("Movie not found");
            return Ok(data);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Add(MovieAddDto movieAddDto)
        {
            var movie = _mapper.Map<Movie>(movieAddDto);
            await _service.AddAsync(movie);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(MovieUpdateDto movieUpdateDto)
        {
            var data = await _service.Where(x => x.Id == movieUpdateDto.Id).AsNoTracking().FirstOrDefaultAsync();
            if (data == null) return NotFound("Movie not found");

            var mapped = _mapper.Map<Movie>(movieUpdateDto);
            await _service.UpdateAsync(mapped);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            if (data == null) return NotFound("Movie not found");

            await _service.RemoveAsync(data);
            return Ok();
        }
        #endregion
        #region Category
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(MovieCategoryDto movieCategoryDto)
        {
            var movie = await _service.Where(x => x.Id == movieCategoryDto.MovieId).AsNoTracking().FirstOrDefaultAsync();
            var category = await _categoryService.Where(x => x.Id == movieCategoryDto.CategoryId).AsNoTracking().FirstOrDefaultAsync();
            var movieCategory = await _movieCategoryService.Where(x => x.MovieId == movieCategoryDto.MovieId && x.CategoryId == movieCategoryDto.CategoryId).AsNoTracking().FirstOrDefaultAsync();
            if (movie == null) ModelState.AddModelError("Movie", "Movie not found");
            if (category == null) ModelState.AddModelError("Category", "Category not found");
            if (movieCategory != null) return Conflict("Already exist");

            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());

            var mapped = _mapper.Map<MovieCategory>(movieCategoryDto);
            await _movieCategoryService.AddAsync(mapped);
            return Ok();


        }
        [HttpDelete("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(MovieCategoryDto movieCategoryDto)
        {
            var movieCategory = await _movieCategoryService.Where(x => x.MovieId == movieCategoryDto.MovieId && x.CategoryId == movieCategoryDto.CategoryId).AsNoTracking().FirstOrDefaultAsync();
            if (movieCategory == null) return NotFound();

            await _movieCategoryService.RemoveAsync(movieCategory);
            return Ok();
        }
        #endregion
        #region Performer
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPerformer(MoviePerformerDto moviePerformerDto)
        {
            var movie = await _service.Where(x => x.Id == moviePerformerDto.MovieId).AsNoTracking().FirstOrDefaultAsync();
            var performer = await _performerService.Where(x => x.Id == moviePerformerDto.PerformerId).AsNoTracking().FirstOrDefaultAsync();
            var moviePerformer = await _moviePerformerService.Where(x => x.MovieId == moviePerformerDto.MovieId && x.PerformerId == moviePerformerDto.PerformerId).AsNoTracking().FirstOrDefaultAsync();
            if (movie == null) ModelState.AddModelError("Movie", "Movie not found");
            if (performer == null) ModelState.AddModelError("Performer", "Performer not found");
            if (moviePerformer != null) return Conflict("Already exist");

            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());

            var mapped = _mapper.Map<MoviePerformer>(moviePerformerDto);
            await _moviePerformerService.AddAsync(mapped);
            return Ok();


        }
        [HttpDelete("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePerformer(MoviePerformerDto moviePerformerDto)
        {
            var moviePerformer = await _moviePerformerService.Where(x => x.MovieId == moviePerformerDto.MovieId && x.PerformerId == moviePerformerDto.PerformerId).AsNoTracking().FirstOrDefaultAsync();
            if (moviePerformer == null) return NotFound();

            await _moviePerformerService.RemoveAsync(moviePerformer);
            return Ok();
        }
        #endregion
        #region Director
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDirector(MovieDirectorDto movieDirectorDto)
        {
            var movie = await _service.Where(x => x.Id == movieDirectorDto.MovieId).AsNoTracking().FirstOrDefaultAsync();
            var director = await _directorService.Where(x => x.Id == movieDirectorDto.DirectorId).AsNoTracking().FirstOrDefaultAsync();
            var movieDirector = await _movieDirectorService.Where(x => x.MovieId == movieDirectorDto.MovieId && x.DirectorId == movieDirectorDto.DirectorId).AsNoTracking().FirstOrDefaultAsync();
            if (movie == null) ModelState.AddModelError("Movie", "Movie not found");
            if (director == null) ModelState.AddModelError("Director", "Director not found");
            if (movieDirector != null) return Conflict("Already exist");

            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());

            var mapped = _mapper.Map<MovieDirector>(movieDirectorDto);
            await _movieDirectorService.AddAsync(mapped);
            return Ok();


        }
        [HttpDelete("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDirector(MovieDirectorDto movieDirectorDto)
        {
            var movieDirector = await _movieDirectorService.Where(x => x.MovieId == movieDirectorDto.MovieId && x.DirectorId == movieDirectorDto.DirectorId).AsNoTracking().FirstOrDefaultAsync();
            if (movieDirector == null) return NotFound();

            await _movieDirectorService.RemoveAsync(movieDirector);
            return Ok();
        }
        #endregion
        #region Producer
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProducer(MovieProducerDto movieProducerDto)
        {
            var movie = await _service.Where(x => x.Id == movieProducerDto.MovieId).AsNoTracking().FirstOrDefaultAsync();
            var producer = await _producerService.Where(x => x.Id == movieProducerDto.ProducerId).AsNoTracking().FirstOrDefaultAsync();
            var movieProducer = await _movieProducerService.Where(x => x.MovieId == movieProducerDto.MovieId && x.ProducerId == movieProducerDto.ProducerId).AsNoTracking().FirstOrDefaultAsync();
            if (movie == null) ModelState.AddModelError("Movie", "Movie not found");
            if (producer == null) ModelState.AddModelError("Producer", "Producer not found");
            if (movieProducer != null) return Conflict("Already exist");

            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());

            var mapped = _mapper.Map<MovieProducer>(movieProducerDto);
            await _movieProducerService.AddAsync(mapped);
            return Ok();


        }
        [HttpDelete("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProducer(MovieProducerDto movieProducerDto)
        {
            var movieProducer = await _movieProducerService.Where(x => x.MovieId == movieProducerDto.MovieId && x.ProducerId == movieProducerDto.ProducerId).AsNoTracking().FirstOrDefaultAsync();
            if (movieProducer == null) return NotFound();

            await _movieProducerService.RemoveAsync(movieProducer);
            return Ok();
        }
        #endregion
        [HttpPost("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAward(MovieAwardDto movieAwardDto)
        {
            var movie = await _service.Where(x => x.Id == movieAwardDto.MovieId).AsNoTracking().FirstOrDefaultAsync();
            var award = await _awardService.Where(x => x.Id == movieAwardDto.AwardId).AsNoTracking().FirstOrDefaultAsync();
            var movieAward = await _movieAwardService.Where(x => x.MovieId == movieAwardDto.MovieId && x.AwardId == movieAwardDto.AwardId).AsNoTracking().FirstOrDefaultAsync();
            if (movie == null) ModelState.AddModelError("Movie", "Movie not found");
            if (award == null) ModelState.AddModelError("Award", "Award not found");
            if (movieAward != null) return Conflict("Already exist");
            var awardType=_awardTypeService.Where(x=>x.Id==award.AwardTypeId).AsNoTracking().FirstOrDefault();
            if (movieAwardDto.PerformerId != null)
            {
                var performer = await _performerService.Where(x => x.Id == movieAwardDto.PerformerId).AsNoTracking().FirstOrDefaultAsync();
                if (performer == null)
                {
                    ModelState.AddModelError("Performer", "Performer not found");
                }
                else
                {
                    if (awardType.Name != performer.Gender) ModelState.AddModelError("Award Gender", "Performer is not suitable for this award");
                    var moviePerformer = await _moviePerformerService.Where(x => x.MovieId == movieAwardDto.MovieId && x.PerformerId == movieAwardDto.PerformerId).AsNoTracking().FirstOrDefaultAsync();
                    if (moviePerformer == null) ModelState.AddModelError("Performer Movie", "The performer does not act in this movie");
                }
            }
            if (movieAwardDto.DirectorId != null)
            {
                var director = await _directorService.Where(x => x.Id == movieAwardDto.DirectorId).AsNoTracking().FirstOrDefaultAsync();
                if (director == null)
                {
                    ModelState.AddModelError("Director", "Director not found");
                }
                else
                {
                    if (awardType.Name != "Director") ModelState.AddModelError("Award Director", "Director is not suitable for this award");
                    var movieDirector = await _movieDirectorService.Where(x => x.MovieId == movieAwardDto.MovieId && x.DirectorId == movieAwardDto.DirectorId).AsNoTracking().FirstOrDefaultAsync();
                    if (movieDirector == null) ModelState.AddModelError("Director Movie", "The director does not direct this movie");
                }
            }
            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
            var mapped = _mapper.Map<MovieAward>(movieAwardDto);
            await _movieAwardService.AddAsync(mapped);
            return Ok();
        }
        [HttpDelete("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAward(MovieAwardDeleteDto movieAwardDeleteDto)
        {
            var movieAward = await _movieAwardService.Where(x => x.MovieId == movieAwardDeleteDto.MovieId && x.AwardId == movieAwardDeleteDto.AwardId).AsNoTracking().FirstOrDefaultAsync();
            if (movieAward == null) return NotFound();
            await _movieAwardService.RemoveAsync(movieAward);
            return Ok();
        }
    }

}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using MovieDB.Core.Repositories;
using MovieDB.Core.Services;
using MovieDB.Core.UnitOfWorks;

namespace MovieDB.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IService<Movie> _movieService;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper, IService<Movie> movieService) : base(repository, unitOfWork)
        {
            _repository = categoryRepository;
            _mapper = mapper;
            _movieService = movieService;
        }
        
        public async Task<List<CategoryGetAllDto>> getAllData()
        {
            var categories = await _repository.GetAllWithData();
            var mapped = _mapper.Map<List<CategoryGetAllDto>>(categories);
            for (int i = 0; i < categories.Count; i++)
            {
                mapped[i].Movies = new List<MovieGetDto>();
                foreach (MovieCategory item in categories[i].MovieCategory)
                {
                    var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                    mapped[i].Movies.Add(_mapper.Map<MovieGetDto>(movie));
                }
            }
            return mapped;
        }

        public async Task<CategoryGetAllDto> GetAllWithDataById(int id)
        {
            var category = await _repository.GetAllWithDataById(id);

            var mapped = _mapper.Map<CategoryGetAllDto>(category);

            mapped.Movies = new List<MovieGetDto>();
            foreach (MovieCategory item in category.MovieCategory)
            {
                var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                mapped.Movies.Add(_mapper.Map<MovieGetDto>(movie));
            }
            return mapped;

        }
    }
}

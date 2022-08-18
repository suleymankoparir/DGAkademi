using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using MovieDB.Core.Repositories;
using MovieDB.Core.Services;
using MovieDB.Core.UnitOfWorks;

namespace MovieDB.Service.Services
{
    public class ProducerService : Service<Producer>, IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        private readonly IService<Movie> _movieService;
        private readonly IMapper _mapper;
        public ProducerService(IGenericRepository<Producer> repository, IUnitOfWork unitOfWork, IProducerRepository producerRepository, IService<Movie> movieService, IMapper mapper) : base(repository, unitOfWork)
        {
            _producerRepository = producerRepository;
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<List<ProducerGetAllDto>> getAllData()
        {
            var producers = await _producerRepository.GetAllWithData();
            var mapped = _mapper.Map<List<ProducerGetAllDto>>(producers);
            for (int i = 0; i < producers.Count; i++)
            {
                mapped[i].Movies = new List<MovieGetDto>();
                foreach (MovieProducer item in producers[i].MovieProducer)
                {
                    var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                    mapped[i].Movies.Add(_mapper.Map<MovieGetDto>(movie));
                }
            }
            return mapped;
        }

        public async Task<ProducerGetAllDto> GetAllWithDataById(int id)
        {
            var producer = await _producerRepository.GetAllWithDataById(id);
            var mapped = _mapper.Map<ProducerGetAllDto>(producer);
            mapped.Movies = new List<MovieGetDto>();
            foreach (MovieProducer item in producer.MovieProducer)
            {
                var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                mapped.Movies.Add(_mapper.Map<MovieGetDto>(movie));
            }
            return mapped;
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;
using MovieDB.Core.Repositories;
using MovieDB.Core.Services;
using MovieDB.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.Service.Services
{
    public class PerformerService : Service<Performer>, IPerformerService
    {
        private readonly IPerformerRepository _repository;
        private readonly IService<Movie> _movieService;
        private readonly IMapper _mapper;
        public PerformerService(IGenericRepository<Performer> repository, IUnitOfWork unitOfWork, IPerformerRepository performerRepository, IService<Movie> movieService, IMapper mapper) : base(repository, unitOfWork)
        {
            _repository = performerRepository;
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<List<PerformerGetAllDto>> getAllData()
        {
            var performers = await _repository.GetAllWithData();
            var mapped = _mapper.Map<List<PerformerGetAllDto>>(performers);
            for (int i = 0; i < performers.Count; i++)
            {
                mapped[i].Movies = new List<MovieGetDto>();
                foreach (MoviePerformer item in performers[i].MoviePerformer)
                {
                    var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                    mapped[i].Movies.Add(_mapper.Map<MovieGetDto>(movie));
                }
            }
            return mapped;
        }

        public async Task<PerformerGetAllDto> GetAllWithDataById(int id)
        {
            var performer = await _repository.GetAllWithDataById(id);

            var mapped = _mapper.Map<PerformerGetAllDto>(performer);

            mapped.Movies = new List<MovieGetDto>();
            foreach (MoviePerformer item in performer.MoviePerformer)
            {
                var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                mapped.Movies.Add(_mapper.Map<MovieGetDto>(movie));
            }
            return mapped;
        }
    }
}

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
    public class AwardService : Service<Award>, IAwardService
    {
        private readonly IAwardRepository _awardRepository;
        private readonly IService<Movie> _movieService;
        private readonly IMapper _mapper;
        public AwardService(IGenericRepository<Award> repository, IUnitOfWork unitOfWork, IAwardRepository awardRepository, IService<Movie> movieService, IMapper mapper) : base(repository, unitOfWork)
        {
            _awardRepository = awardRepository;
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<List<AwardGetAllDto>> getAllData()
        {
            var awards = await _awardRepository.GetAllWithData();
            var mapped = _mapper.Map<List<AwardGetAllDto>>(awards);
            for (int i = 0; i < awards.Count; i++)
            {
                mapped[i].Movies = new List<MovieGetDto>();
                foreach (MovieAward item in awards[i].MovieAward)
                {
                    var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                    mapped[i].Movies.Add(_mapper.Map<MovieGetDto>(movie));
                }
            }
            return mapped;
        }

        public async Task<AwardGetAllDto> GetAllWithDataById(int id)
        {
            var award = await _awardRepository.GetAllWithDataById(id);
            var mapped = _mapper.Map<AwardGetAllDto>(award);
            mapped.Movies = new List<MovieGetDto>();
            foreach (MovieAward item in award.MovieAward)
            {
                var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                mapped.Movies.Add(_mapper.Map<MovieGetDto>(movie));
            }
            return mapped;
        }
    }
}

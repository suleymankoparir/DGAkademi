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
    public class DirectorService : Service<Director>, IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IService<Movie> _movieService;
        private readonly IMapper _mapper;
        public DirectorService(IGenericRepository<Director> repository, IUnitOfWork unitOfWork, IDirectorRepository directorRepository, IService<Movie> movieService, IMapper mapper) : base(repository, unitOfWork)
        {
            _directorRepository = directorRepository;
            _movieService = movieService;
            _mapper = mapper;
        }

        public async Task<List<DirectorGetAllDto>> getAllData()
        {
            var directors = await _directorRepository.GetAllWithData();
            var mapped = _mapper.Map<List<DirectorGetAllDto>>(directors);
            for (int i = 0; i < directors.Count; i++)
            {
                mapped[i].Movies = new List<MovieGetDto>();
                foreach (MovieDirector item in directors[i].MovieDirector)
                {
                    var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                    mapped[i].Movies.Add(_mapper.Map<MovieGetDto>(movie));
                }
            }
            return mapped;
        }

        public async Task<DirectorGetAllDto> GetAllWithDataById(int id)
        {
            var director = await _directorRepository.GetAllWithDataById(id);
            var mapped = _mapper.Map<DirectorGetAllDto>(director);
            mapped.Movies = new List<MovieGetDto>();
            foreach (MovieDirector item in director.MovieDirector)
            {
                var movie = await _movieService.Where(x => x.Id == item.MovieId).FirstOrDefaultAsync();
                mapped.Movies.Add(_mapper.Map<MovieGetDto>(movie));
            }
            return mapped;
        }
    }
}

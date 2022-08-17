﻿using AutoMapper;
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
    public class MovieService : Service<Movie>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IService<Category> _categoryService;
        private readonly IService<Movie> _movieService;
        private readonly IService<Director> _directorService;
        private readonly IService<Producer> _producerService;
        private readonly IService<Award> _awardService;
        private readonly IService<Performer> _performerService;
        private readonly IService<Review> _reviewService;
        private readonly IMapper _mapper;
        public MovieService(IGenericRepository<Movie> repository, IUnitOfWork unitOfWork, IService<Movie> movieService, IMapper mapper, IService<Director> directorService, IService<Producer> producerService, IService<Award> awardService, IService<Performer> performerService, IService<Review> reviewService, IMovieRepository movieRepository, IService<Category> categoryService) : base(repository, unitOfWork)
        {
            _movieService = movieService;
            _mapper = mapper;
            _directorService = directorService;
            _producerService = producerService;
            _awardService = awardService;
            _performerService = performerService;
            _reviewService = reviewService;
            _movieRepository = movieRepository;
            _categoryService = categoryService;
        }

        public async Task<List<MovieGetDto>> getAllData()
        {
            var data = await _movieRepository.GetAllWithData();
            var dataDto=_mapper.Map<List<MovieGetDto>>(data);
            int count = 0;
            foreach(Movie movie in data)
            {
                dataDto[count].Categories= new List<CategoryGetDto>();
                dataDto[count].Producers = new List<ProducerGetDto>();
                dataDto[count].Awards = new List<AwardGetDto>();
                dataDto[count].Performsers = new List<PerformerGetDto>();
                dataDto[count].Directors = new List<DirectorGetDto>();
                foreach (MovieCategory category in movie.MovieCategory)
                {
                    int categoryId = category.CategoryId;
                    var categoryMapped=_mapper.Map<CategoryGetDto>(await _categoryService.Where(x => x.Id == categoryId).AsNoTracking().FirstOrDefaultAsync());
                    dataDto[count].Categories.Add(categoryMapped);
                }
                foreach (MovieDirector director in movie.MovieDirector)
                {
                    int directorId = director.DirectorId;
                    var directorMapped = _mapper.Map<DirectorGetDto>(await _directorService.Where(x => x.Id == directorId).AsNoTracking().FirstOrDefaultAsync());
                    dataDto[count].Directors.Add(directorMapped);
                }
                foreach (MovieAward award in movie.MovieAward)
                {
                    int awardId = award.AwardId;
                    var awardMapped = _mapper.Map<AwardGetDto>(await _awardService.Where(x => x.Id == awardId).AsNoTracking().FirstOrDefaultAsync());
                    dataDto[count].Awards.Add(awardMapped);
                }
                foreach (MovieProducer producer in movie.MovieProducer)
                {
                    int producerId = producer.ProducerId;
                    var producerMapped = _mapper.Map<ProducerGetDto>(await _producerService.Where(x => x.Id == producerId).AsNoTracking().FirstOrDefaultAsync());
                    dataDto[count].Producers.Add(producerMapped);
                }
                foreach (MoviePerformer performer in movie.MoviePerformer)
                {
                    int performerId = performer.PerformerId;
                    var performerMapped = _mapper.Map<PerformerGetDto>(await _performerService.Where(x => x.Id == performerId).AsNoTracking().FirstOrDefaultAsync());
                    dataDto[count].Performsers.Add(performerMapped);
                }
                foreach (Review review in movie.Reviews)
                {
                    int reviewId = review.Id;
                    var reviewVar = await _reviewService.Where(x => x.Id == reviewId).AsNoTracking().FirstOrDefaultAsync();
                    dataDto[count].Score += reviewVar.Score;
                }
                if (movie.Reviews != null&&movie.Reviews.Count!=0)
                    dataDto[count].Score /= data[count].Reviews.Count();
                count++;
            }
            return dataDto;
        }

        public async Task<MovieGetDto> GetAllWithDataById(int id)
        {
            var data = await _movieRepository.GetAllWithDataById(id);
            if(data == null)
                return null;
            var dataDto = _mapper.Map<MovieGetDto>(data);
            dataDto.Score = 0;
            dataDto.Categories = new List<CategoryGetDto>();
            dataDto.Producers = new List<ProducerGetDto>();
            dataDto.Awards = new List<AwardGetDto>();
            dataDto.Performsers = new List<PerformerGetDto>();
            dataDto.Directors = new List<DirectorGetDto>();
            foreach (MovieCategory category in data.MovieCategory)
            {
                int categoryId = category.CategoryId;
                var categoryMapped = _mapper.Map<CategoryGetDto>(await _categoryService.Where(x => x.Id == categoryId).AsNoTracking().FirstOrDefaultAsync());
                dataDto.Categories.Add(categoryMapped);
            }
            foreach (MovieDirector director in data.MovieDirector)
            {
                int directorId = director.DirectorId;
                var directorMapped = _mapper.Map<DirectorGetDto>(await _directorService.Where(x => x.Id == directorId).AsNoTracking().FirstOrDefaultAsync());
                dataDto.Directors.Add(directorMapped);
            }
            foreach (MovieAward award in data.MovieAward)
            {
                int awardId = award.AwardId;
                var awardMapped = _mapper.Map<AwardGetDto>(await _awardService.Where(x => x.Id == awardId).AsNoTracking().FirstOrDefaultAsync());
                dataDto.Awards.Add(awardMapped);
            }
            foreach (MovieProducer producer in data.MovieProducer)
            {
                int producerId = producer.ProducerId;
                var producerMapped = _mapper.Map<ProducerGetDto>(await _producerService.Where(x => x.Id == producerId).AsNoTracking().FirstOrDefaultAsync());
                dataDto.Producers.Add(producerMapped);
            }
            foreach (MoviePerformer performer in data.MoviePerformer)
            {
                int performerId = performer.PerformerId;
                var performerMapped = _mapper.Map<PerformerGetDto>(await _performerService.Where(x => x.Id == performerId).AsNoTracking().FirstOrDefaultAsync());
                dataDto.Performsers.Add(performerMapped);
            }
            foreach(Review review in data.Reviews)
            {
                int reviewId = review.Id;
                var reviewVar = await _reviewService.Where(x => x.Id == reviewId).AsNoTracking().FirstOrDefaultAsync();
                dataDto.Score += reviewVar.Score;
            }
            if(data.Reviews != null && data.Reviews.Count != 0)
                dataDto.Score/=data.Reviews.Count();
            return dataDto;
        }
    }
}

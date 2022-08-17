using AutoMapper;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;

namespace MovieDB.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Movie, MovieGetDto>();
            CreateMap<Category, CategoryGetDto>();
            CreateMap<Performer, PerformerGetDto>();
            CreateMap<Director, DirectorGetDto>();
            CreateMap<Award, AwardGetDto>();
            CreateMap<Producer, ProducerGetDto>();
            CreateMap<MovieAddDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<MovieCategoryDto, MovieCategory>();
            CreateMap<MoviePerformerDto, MoviePerformer>();
            CreateMap<MovieProducerDto, MovieProducer>();
            CreateMap<MovieDirectorDto, MovieDirector>();
            CreateMap<MovieAwardDto, MovieAward>();
        }
    }
}

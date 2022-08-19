using AutoMapper;
using MovieDB.Core.DTOs;
using MovieDB.Core.Models;

namespace MovieDB.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Movie, MovieGetAllDto>();
            CreateMap<Category, CategoryGetDto>().ReverseMap();
            CreateMap<Performer, PerformerGetDto>().ReverseMap();
            CreateMap<Director, DirectorGetDto>().ReverseMap();
            CreateMap<Award, AwardGetDto>().ReverseMap();
            CreateMap<Producer, ProducerGetDto>().ReverseMap();
            CreateMap<MovieAddDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<MovieCategoryDto, MovieCategory>();
            CreateMap<MoviePerformerDto, MoviePerformer>();
            CreateMap<MovieProducerDto, MovieProducer>();
            CreateMap<MovieDirectorDto, MovieDirector>();
            CreateMap<MovieAwardDto, MovieAward>();
            CreateMap<Category, CategoryGetAllDto>();
            CreateMap<Movie, MovieGetDto>().ReverseMap();
            CreateMap<Producer, ProducerGetAllDto>();
            CreateMap<Award, AwardGetAllDto>();
            CreateMap<AwardAddDto, Award>();
            CreateMap<AwardUpdateDto, Award>();
            CreateMap<Performer,PerformerGetAllDto>();
            CreateMap<PerformerAddDto,Performer>();
            CreateMap<PerformerUpdateDto, Performer>();
            CreateMap<Director,DirectorGetAllDto>();
            CreateMap<DirectorAddDto, Director>();
            CreateMap<DirectorUpdateDto,Director>();
            CreateMap<AwardType, AwardTypeGetAllDto>();
            CreateMap<Review,ReviewGetDto>().ReverseMap();
            CreateMap<User, UserGetAllDto>();
            CreateMap<UserAddDto,User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User,UserGetDto>();
            CreateMap<AwardType,AwardTypeGetDto>();
        }
    }
}

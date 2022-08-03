using AutoMapper;
using W_01.Core.DTOs;
using W_01.Core.Models;

namespace W_01.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BaseCar, BaseCarDto>();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using ClassStudent.Data.DTOs;
using ClassStudent.Data.Entities;

namespace ClassStudent.Data.Mapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Class, ClassDto>();
            CreateMap<ClassAddDto, Class>();
        }
    }
}

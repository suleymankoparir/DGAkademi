using AutoMapper;
using W_02.Core.DTOs;
using W_02.Core.Models;

namespace W_02.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Person,PersonWithDepartmentAndRoleDto>();
            CreateMap<Person, PersonLoginDto>();
            CreateMap<ProductAddDto, Product>();
            CreateMap<PersonSignUpDto, Person>();
            CreateMap<Role,RoleDto>();
        }
    }
}

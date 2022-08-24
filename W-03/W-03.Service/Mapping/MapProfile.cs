using AutoMapper;
using W_03.Core.DTOs;
using W_03.Core.Entities;
using W_03.Core.Views;

namespace W_03.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<PreRegistrationView, PreRegistration>();
            CreateMap<User, UserDto>();

            CreateMap<PreRegisteredUserRegistrationView, User>();
            CreateMap<PreRegisteredUserRegistrationView, UserInformation>();
            CreateMap<UserInformation, UserInfoView>();

            CreateMap<Sale, SaleView>();
            CreateMap<UserInformationUpdateView, UserInformation>();
            CreateMap<User,JwtUserInfoView>();

            CreateMap<ProductAddView, Product>();
            CreateMap<ProductAddView, ProductDetail>();
        }
    }
}

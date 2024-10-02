using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Account.Request;
using URF_Cinema.Application.DataTransferObjects.Account;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<UserEntity, ViewLoginInput>()
                .ForMember(des => des.Code, opt => opt.MapFrom(src => src.Role.Code));
            ;
            CreateMap<LoginInputRequest, UserEntity>();
            CreateMap<CustomerEntity, ViewLoginInput>();
            CreateMap<LoginInputRequest, CustomerEntity>();
        }
    }
}

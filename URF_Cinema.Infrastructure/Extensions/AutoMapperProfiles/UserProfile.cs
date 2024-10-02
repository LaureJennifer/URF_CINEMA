using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.User;
using URF_Cinema.Application.DataTransferObjects.User.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserCreateRequest, UserEntity>();
            CreateMap<UserUpdateRequest, UserEntity>();
            CreateMap<UserDeleteRequest, UserEntity>();
        }
    }
}

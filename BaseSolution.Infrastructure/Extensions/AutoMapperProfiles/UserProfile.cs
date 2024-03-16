using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.DataTransferObjects.User.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserCreateRequest, UserEntity>();
            CreateMap<UserUpdateRequest, UserEntity>();
        }
    }
}

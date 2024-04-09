using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Account.Request;
using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<UserEntity, ViewLoginInput>()
                .ForMember(des => des.Code, opt => opt.MapFrom(src => src.RoleEntity.Code));
            ;
            CreateMap<LoginInputRequest, UserEntity>();
        }
    }
}

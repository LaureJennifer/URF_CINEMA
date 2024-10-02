using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.Role;
using URF_Cinema.Application.DataTransferObjects.Role.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleEntity, RoleDto>();
            CreateMap<RoleCreateRequest, RoleEntity>();
            CreateMap<RoleUpdateRequest, RoleEntity>();
            CreateMap<RoleDeleteRequest, RoleEntity>();
        }
    }
}

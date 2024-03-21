using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Role;
using BaseSolution.Application.DataTransferObjects.Role.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
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

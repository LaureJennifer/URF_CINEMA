using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.Department;
using URF_Cinema.Application.DataTransferObjects.Department.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentEntity, DepartmentDto>();
            CreateMap<DepartmentCreateRequest, DepartmentEntity>();
            CreateMap<DepartmentUpdateRequest, DepartmentEntity>();
        }
    }
}

using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.DataTransferObjects.Department.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
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

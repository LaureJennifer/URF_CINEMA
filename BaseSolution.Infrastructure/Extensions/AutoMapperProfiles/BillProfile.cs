using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<BillEntity, BillDto>();
            CreateMap<BillCreateRequest, BillEntity>();
            CreateMap<BillUpdateRequest, BillEntity>();
        }
    }
}

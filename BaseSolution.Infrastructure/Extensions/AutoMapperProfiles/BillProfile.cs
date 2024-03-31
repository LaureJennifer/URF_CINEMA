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
            CreateMap<BillEntity, BillDto>()
               .ForMember(des => des.CustomerName, opt => opt.MapFrom(x => x.CustomerEntity.Name))
               .ForMember(des => des.TotalPrice, opt => opt.MapFrom(src => src.Tickets.Select(x=>x.BookingEntity).Sum(x=>x.SeatEntity.Price)))
               .ForMember(des => des.TicketQuantity, opt => opt.MapFrom(src => src.Tickets.Select(x => x.BookingEntity).Count()));
            CreateMap<BillCreateRequest, BillEntity>();
            CreateMap<BillUpdateRequest, BillEntity>();

        }
    }
}

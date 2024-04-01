using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Ticket;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<BillEntity, BillDto>()
               .ForMember(des => des.CustomerName, opt => opt.MapFrom(x => x.CustomerEntity.Name))
               .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.DepartmentEntity.Name))
               .ForMember(des => des.TotalPrice1, opt => opt.MapFrom(src => src.Tickets.Select(x=>x.BookingEntity).Sum(x=>x.SeatEntity.Price)))
               .ForMember(des => des.TicketQuantity1, opt => opt.MapFrom(src => src.Tickets.Select(x => x.BookingEntity).Count()));

            CreateMap<BillEntity, BillStatisticForMonthDto>()
                .ForMember(des => des.Month, opt => opt.MapFrom(x => x.CreatedTime.Month))
                .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
                .ForMember(des => des.Revenue, opt => opt.MapFrom(x => x.TotalPrice))
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.DepartmentEntity.Name));


            CreateMap<BillEntity, BillStatisticForQuarterDto>()
                .ForMember(des => des.Quarter, opt => opt.MapFrom(x => (x.CreatedTime.Month - 1) / 3 + 1))
                .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
                .ForMember(des => des.Revenue, opt => opt.MapFrom(x => x.TotalPrice));

            CreateMap<BillEntity, BillStatisticForYearDto>()
               .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
               .ForMember(des => des.Revenue, opt => opt.MapFrom(x => x.TotalPrice));

            CreateMap<BillEntity, TicketStatisticForMonthDto>()
               .ForMember(des => des.Month, opt => opt.MapFrom(x => x.CreatedTime.Month))
               .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
               .ForMember(des => des.Quantity, opt => opt.MapFrom(x => x.TicketQuantity));

            CreateMap<BillEntity, TicketStatisticForQuarterDto>()
                .ForMember(des => des.Quarter, opt => opt.MapFrom(x => (x.CreatedTime.Month - 1) / 3 + 1))
                .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
                .ForMember(des => des.Quantity, opt => opt.MapFrom(x => x.TicketQuantity));

            CreateMap<BillCreateRequest, BillEntity>();
            CreateMap<BillUpdateRequest, BillEntity>();

        }
    }
}

using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.DataTransferObjects.Ticket;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<BillEntity, BillDto>()
               .ForMember(des => des.CustomerName, opt => opt.MapFrom(x => x.Customer.Name))
               .ForMember(des => des.CustomerEmail, opt => opt.MapFrom(x => x.Customer.Email))
               .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.Department.Name))
               /*.ForMember(des => des.TicketQuantity, opt => opt.MapFrom(x => x.Tickets.Count()))*/;

            CreateMap<BillEntity, BillStatisticForMonthDto>()
                .ForMember(des => des.Month, opt => opt.MapFrom(x => x.CreatedTime.Month))
                .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
                .ForMember(des => des.Revenue, opt => opt.MapFrom(x => x.TotalPrice))
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.Department.Name));


            CreateMap<BillEntity, BillStatisticForQuarterDto>()
                .ForMember(des => des.Quarter, opt => opt.MapFrom(x => (x.CreatedTime.Month - 1) / 3 + 1))
                .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
                .ForMember(des => des.Revenue, opt => opt.MapFrom(x => x.TotalPrice))
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.Department.Name));

            CreateMap<BillEntity, BillStatisticForYearDto>()
               .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
               .ForMember(des => des.Revenue, opt => opt.MapFrom(x => x.TotalPrice))
               .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.Department.Name));

            CreateMap<BillEntity, TicketStatisticForMonthDto>()
               .ForMember(des => des.Month, opt => opt.MapFrom(x => x.CreatedTime.Month))
               .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
               //.ForMember(des => des.Quantity, opt => opt.MapFrom(src => src.Tickets.Select(x => x.BookingEntity).Count()))
               .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.Department.Name));

            CreateMap<BillEntity, TicketStatisticForQuarterDto>()
                .ForMember(des => des.Quarter, opt => opt.MapFrom(x => (x.CreatedTime.Month - 1) / 3 + 1))
                .ForMember(des => des.Year, opt => opt.MapFrom(x => x.CreatedTime.Year))
                //.ForMember(des => des.Quantity, opt => opt.MapFrom(src => src.Tickets.Select(x => x.BookingEntity).Count()))
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.Department.Name));

            CreateMap<BillCreateRequest, BillEntity>();
            CreateMap<BillUpdateRequest, BillEntity>();

        }
    }
}

using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;
using BaseSolution.Application.DataTransferObjects.Film;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TicketEntity, TicketDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.BillEntity.DepartmentEntity.Name))
                ////.ForMember(des => des.CreatedTime, opt => opt.MapFrom(src => src.BillEntity.CreatedTime))
                //.ForMember(des => des.FilmName, opt => opt.MapFrom(src => src.Film.Title))
                .ForMember(des => des.SeatCode, opt => opt.MapFrom(src => src.Booking.Seat.Code))
                .ForMember(des => des.RoomCode, opt => opt.MapFrom(src => src.Booking.Seat.Code));
                //.ForMember(des => des.ShowDate, opt => opt.MapFrom(src => src.Film.FilmDetails.Select(x => x.FilmSchedule.ShowDate).FirstOrDefault()))
                //.ForMember(des => des.ShowTime, opt => opt.MapFrom(src => src.Film.FilmDetails.Select(x => x.FilmSchedule.ShowTime).FirstOrDefault()));
                
            CreateMap<TicketEntity, FilmStatisticForMonthDto>()
                //.ForMember(des => des.Month, opt => opt.MapFrom(x => x.BillEntity.CreatedTime.Month))
                //.ForMember(des => des.Year, opt => opt.MapFrom(x => x.BillEntity.CreatedTime.Year))
                //.ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.BillEntity.DepartmentEntity.Name))
             /*   .ForMember(des => des.FilmName, opt => opt.MapFrom(src => src.Film.Title))*/;
                


            //CreateMap<TicketEntity, FilmStatisticForQuarterDto>()
            //    .ForMember(des => des.Quarter, opt => opt.MapFrom(x => (x.BillEntity.CreatedTime.Month - 1) / 3 + 1))
            //    .ForMember(des => des.Year, opt => opt.MapFrom(x => x.BillEntity.CreatedTime.Year))
            //    .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.BillEntity.DepartmentEntity.Name))
            //    .ForMember(des => des.FilmName, opt => opt.MapFrom(x => x.FilmEntity.Title));

            //CreateMap<TicketEntity, FilmStatisticForYearDto>()
            //   .ForMember(des => des.Year, opt => opt.MapFrom(x => x.BillEntity.CreatedTime.Year))
            //    .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.BillEntity.DepartmentEntity.Name))
            //    .ForMember(des => des.FilmName, opt => opt.MapFrom(x => x.FilmEntity.Title));

            CreateMap<TicketCreateRequest, TicketEntity>();
            CreateMap<TicketUpdateRequest, TicketEntity>();
        }
    }
}

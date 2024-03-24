using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Ticket;
using BaseSolution.Application.DataTransferObjects.Ticket.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<TicketEntity, TicketDto>()
                .ForMember(des => des.FilmName, opt => opt.MapFrom(src => src.FilmEntity.Title))
                .ForMember(des => des.SeatCode, opt => opt.MapFrom(src => src.BookingEntity.SeatEntity.Code))
                .ForMember(des => des.RoomCode, opt => opt.MapFrom(src => src.BookingEntity.RoomEntity.Code))
                .ForMember(des => des.ShowDate, opt => opt.MapFrom(src => src.FilmEntity.FilmDetails.Select(x=>x.FilmScheduleEntity.ShowDate).FirstOrDefault()))
                .ForMember(des => des.ShowTime, opt => opt.MapFrom(src => src.FilmEntity.FilmDetails.Select(x => x.FilmScheduleEntity.ShowTime).FirstOrDefault())); 
            CreateMap<TicketCreateRequest, TicketEntity>();
            CreateMap<TicketUpdateRequest, TicketEntity>();
        }
    }
}

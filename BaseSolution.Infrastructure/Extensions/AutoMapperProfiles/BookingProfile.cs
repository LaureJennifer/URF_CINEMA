using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.DataTransferObjects.Booking.Request;


namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingEntity, BookingDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.SeatCode, opt => opt.MapFrom(src => src.SeatEntity.Code))
                .ForMember(des => des.RoomCode, opt => opt.MapFrom(src => src.RoomEntity.Code));
            CreateMap<BookingCreateRequest, BookingEntity>();
            CreateMap<BookingUpdateRequest, BookingEntity>();
        }
    }
}

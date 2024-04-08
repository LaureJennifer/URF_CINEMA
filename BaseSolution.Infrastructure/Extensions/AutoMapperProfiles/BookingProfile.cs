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
                .ForMember(des => des.SeatId, opt => opt.MapFrom(src => src.SeatId))
                .ForMember(des => des.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(des => des.SeatCode, opt => opt.MapFrom(src => src.SeatEntity.Code))
                .ForMember(des => des.RoomCode, opt => opt.MapFrom(src => src.RoomEntity.Code))
                .ForMember(des => des.ExpiredTime, opt => opt.MapFrom(src => src.ExpiredTime));

            CreateMap<BookingCreateRequest, BookingEntity>();
            CreateMap<BookingUpdateRequest, BookingEntity>();
        }
    }
}

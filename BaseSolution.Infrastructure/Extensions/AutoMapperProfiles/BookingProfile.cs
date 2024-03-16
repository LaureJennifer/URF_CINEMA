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
            CreateMap<BookingEntity, BookingDto>();
            CreateMap<BookingCreateRequest, BookingEntity>();
            CreateMap<BookingUpdateRequest, BookingEntity>();
        }
    }
}

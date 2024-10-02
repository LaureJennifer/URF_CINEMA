using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.Seat;
using URF_Cinema.Application.DataTransferObjects.Seat.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            CreateMap<SeatEntity, SeatDto>()
                .ForMember(des => des.RoomLayoutName, opt => opt.MapFrom(src => src.RoomLayout.Name));
            CreateMap<SeatCreateRangeRequest, SeatEntity>();
            CreateMap<SeatCreateRequest, SeatEntity>();
            CreateMap<SeatUpdateRequest, SeatEntity>();
        }
    }
}

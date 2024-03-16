using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Application.DataTransferObjects.Room.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomEntity, RoomDto>();
            CreateMap<RoomCreateRequest, RoomEntity>();
            CreateMap<RoomUpdateRequest, RoomEntity>();
        }
    }
}

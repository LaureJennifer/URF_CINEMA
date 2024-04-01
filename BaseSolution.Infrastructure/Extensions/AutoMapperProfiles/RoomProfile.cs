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
            CreateMap<RoomEntity, RoomDto>()
                .ForMember(des => des.RoomLayoutName, opt => opt.MapFrom(src => src.RoomLayoutEntity.Name))
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.DepartmentEntity.Name))
                .ForMember(des => des.DepartmentAddress, opt => opt.MapFrom(src => src.DepartmentEntity.Address))
                .ForMember(des => des.FilmSchedules, opt => opt.MapFrom(src => src.FilmScheduleRooms.Select(x=>x.FilmScheduleEntity))); 
            CreateMap<RoomCreateRequest, RoomEntity>();
            CreateMap<RoomUpdateRequest, RoomEntity>();
        }
    }
}

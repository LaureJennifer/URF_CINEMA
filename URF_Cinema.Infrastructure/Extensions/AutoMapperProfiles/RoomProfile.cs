using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.Room;
using URF_Cinema.Application.DataTransferObjects.Room.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomEntity, RoomDto>()
                .ForMember(des => des.RoomLayoutName, opt => opt.MapFrom(src => src.RoomLayout.Name))
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(des => des.DepartmentAddress, opt => opt.MapFrom(src => src.Department.Address));
                
            CreateMap<RoomCreateRequest, RoomEntity>();
            CreateMap<RoomUpdateRequest, RoomEntity>();
        }
    }
}

using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.RoomLayout;
using URF_Cinema.Application.DataTransferObjects.RoomLayout.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class RoomLayoutProfile : Profile
    {
        public RoomLayoutProfile()
        {
            CreateMap<RoomLayoutEntity, RoomLayoutDto>();
            CreateMap<RoomLayoutCreateRequest, RoomLayoutEntity>();
            CreateMap<RoomLayoutUpdateRequest, RoomLayoutEntity>();
            CreateMap<RoomLayoutDeleteRequest, RoomLayoutEntity>();
        }
    }
}

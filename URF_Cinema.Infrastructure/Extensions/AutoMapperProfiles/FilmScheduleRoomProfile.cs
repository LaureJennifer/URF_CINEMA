using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom;
using URF_Cinema.Application.DataTransferObjects.FilmScheduleRoom.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class FilmScheduleRoomProfile :Profile
    {
        public FilmScheduleRoomProfile()
        {
            CreateMap<FilmScheduleRoomEntity, FilmScheduleRoomDto>()
                                .ForMember(des => des.Id, opt => opt.MapFrom(x =>x.Id))
                .ForMember(des => des.ShowDate, opt => opt.MapFrom(x => x.FilmSchedule.ShowDate))
                .ForMember(des => des.ShowTime, opt => opt.MapFrom(x => x.FilmSchedule.ShowTime))
                .ForMember(des => des.RoomCode, opt => opt.MapFrom(x => x.Room.Code));
            CreateMap<FilmScheduleRoomCreateRangeRequest, FilmScheduleRoomEntity>();
            CreateMap<FilmScheduleRoomCreateRequest, FilmScheduleRoomEntity>();
            CreateMap<FilmScheduleRoomUpdateRequest, FilmScheduleRoomEntity>();
        }
    }
}

using AutoMapper;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
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

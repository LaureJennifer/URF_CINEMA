using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.FilmSchedule;
using BaseSolution.Application.DataTransferObjects.FilmSchedule.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class FilmScheduleProfile : Profile
    {
        public FilmScheduleProfile()
        {
            CreateMap<FilmScheduleEntity, FilmScheduleDto>()
            .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.FilmScheduleRooms.Where(x => x.Status != Domain.Enums.EntityStatus.Deleted).Select(x => x.RoomEntity)));
            CreateMap<FilmScheduleCreateRequest, FilmScheduleEntity>();
            CreateMap<FilmScheduleUpdateRequest, FilmScheduleEntity>();
        }
    }
}

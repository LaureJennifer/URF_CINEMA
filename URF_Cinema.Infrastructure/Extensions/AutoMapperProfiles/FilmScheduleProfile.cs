using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule;
using URF_Cinema.Application.DataTransferObjects.FilmSchedule.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class FilmScheduleProfile : Profile
    {
        public FilmScheduleProfile()
        {
            CreateMap<FilmScheduleEntity, FilmScheduleDto>()
            .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.FilmScheduleRooms.Where(x => x.Status != Domain.Enums.EntityStatus.Deleted).Select(x => x.Room)));
            CreateMap<FilmScheduleCreateRequest, FilmScheduleEntity>();
            CreateMap<FilmScheduleUpdateRequest, FilmScheduleEntity>();
        }
    }
}

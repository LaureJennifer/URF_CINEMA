using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.FilmDetail;
using URF_Cinema.Application.DataTransferObjects.FilmDetail.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class FilmDetailProfile :Profile
    {
        public FilmDetailProfile() 
        {
            CreateMap<FilmDetailEntity, FilmDetailDto>()
                .ForMember(des => des.FilmScheduleId, opt => opt.MapFrom(x => x.FilmScheduleId))
                .ForMember(des => des.Title, opt => opt.MapFrom(x => x.Film.Title))
                .ForMember(des => des.ShowDate, opt => opt.MapFrom(src => src.FilmSchedule.ShowDate))
                .ForMember(des => des.ShowTime, opt => opt.MapFrom(src => src.FilmSchedule.ShowTime));
            CreateMap<FilmDetailCreateRequest, FilmDetailEntity>();
            CreateMap<FilmDetailUpdateRequest, FilmDetailEntity>();
        }
    }
}

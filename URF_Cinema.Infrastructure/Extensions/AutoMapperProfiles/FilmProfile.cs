using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Film;
using URF_Cinema.Application.DataTransferObjects.Film.Request;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<FilmEntity, FilmDto>()
                .ForMember(dest => dest.FilmSchedules, opt => opt.MapFrom(src => src.FilmDetails.Select(fs => fs.FilmSchedule)));

            CreateMap<FilmCreateRequest, FilmEntity>();
            CreateMap<FilmUpdateRequest, FilmEntity>();
            CreateMap<FilmDeleteRequest, FilmEntity>();

        }
    }
}

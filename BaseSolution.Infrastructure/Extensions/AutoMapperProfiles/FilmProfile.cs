using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Film.Request;
using BaseSolution.Application.DataTransferObjects.FilmScheduleRoom;
using BaseSolution.Application.DataTransferObjects.Room;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<FilmEntity, FilmDto>()
                .ForMember(dest => dest.FilmSchedules, opt => opt.MapFrom(src => src.FilmDetails.Select(fs => fs.FilmScheduleEntity)));

            CreateMap<FilmCreateRequest, FilmEntity>();
            CreateMap<FilmUpdateRequest, FilmEntity>();
            CreateMap<FilmDeleteRequest, FilmEntity>();

        }
    }
}

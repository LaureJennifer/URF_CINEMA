using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Film;
using BaseSolution.Application.DataTransferObjects.Film.Request;
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
                .ForMember(des => des.ShowDates, opt => opt.MapFrom(src => src.FilmDetails.Select(x=>x.FilmScheduleEntity.ShowDate)))
                .ForMember(des => des.ShowTimes, opt => opt.MapFrom(src => src.FilmDetails.Select(x => x.FilmScheduleEntity.ShowTime)));
            CreateMap<FilmCreateRequest, FilmEntity>();
            CreateMap<FilmUpdateRequest, FilmEntity>();
            CreateMap<FilmDeleteRequest, FilmEntity>();

        }
    }
}

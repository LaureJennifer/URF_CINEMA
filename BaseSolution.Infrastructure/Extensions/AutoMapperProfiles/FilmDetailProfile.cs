using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.FilmDetail;
using BaseSolution.Application.DataTransferObjects.FilmDetail.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
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

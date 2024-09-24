using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm;
using BaseSolution.Application.DataTransferObjects.DepartmentFilm.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class DepartmentFilmProfile :Profile
    {
        public DepartmentFilmProfile()
        {
            CreateMap<DepartmentFilmEntity, DepartmentFilmDto>()
                .ForMember(des => des.DepartmentName, opt => opt.MapFrom(x => x.Department.Name))
                .ForMember(des => des.FilmTitle, opt => opt.MapFrom(x => x.Film.Title));

            CreateMap<DepartmentFilmCreateRequest, DepartmentFilmEntity>();
            CreateMap<DepartmentFilmUpdateRequest, DepartmentFilmEntity>();
        }
    }
}

using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm;
using URF_Cinema.Application.DataTransferObjects.DepartmentFilm.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
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

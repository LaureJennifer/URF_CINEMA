using AutoMapper;
using URF_Cinema.Application.DataTransferObjects.Example;
using URF_Cinema.Application.DataTransferObjects.Example.Request;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<ExampleEntity, ExampleDto>();
            CreateMap<ExampleCreateRequest, ExampleDto>();
        }
    }
}

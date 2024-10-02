using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.Customer;
using URF_Cinema.Application.DataTransferObjects.Customer.Request;
using URF_Cinema.Application.DataTransferObjects.Account;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>();
            CreateMap<CustomerCreateRequest, CustomerEntity>();
            CreateMap<CustomerUpdateRequest, CustomerEntity>();
            CreateMap<CustomerDeleteRequest, CustomerEntity>();
            CreateMap<RegisterRequest,CustomerEntity>().ReverseMap();
            CreateMap<ResetPassword, CustomerEntity>();
        }
    }
}

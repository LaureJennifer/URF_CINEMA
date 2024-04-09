using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Account;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>();
            CreateMap<CustomerCreateRequest, CustomerEntity>();
            CreateMap<CustomerUpdateRequest, CustomerEntity>();
            CreateMap<CustomerDeleteRequest, CustomerEntity>();
            CreateMap<RegisterRequest,CustomerEntity>();
        }
    }
}

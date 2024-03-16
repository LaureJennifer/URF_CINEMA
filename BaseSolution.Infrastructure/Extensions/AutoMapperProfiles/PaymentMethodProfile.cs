using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.PaymentMethod;
using BaseSolution.Application.DataTransferObjects.PaymentMethod.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class PaymentMethodProfile : Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<PaymentMethodEntity, PaymentMethodDto>();
            CreateMap<PaymentMethodCreateRequest, PaymentMethodEntity>();
            CreateMap<PaymentMethodUpdateRequest, PaymentMethodEntity>();
        }
    }
}

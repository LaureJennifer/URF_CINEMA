using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class PaymentMethodProfile : Profile
    {
        public PaymentMethodProfile()
        {
            CreateMap<PaymentMethodEntity, PaymentMethodDto>();
            CreateMap<PaymentMethodCreateRequest, PaymentMethodEntity>();
            CreateMap<PaymentMethodUpdateRequest, PaymentMethodEntity>();
            CreateMap<PaymentMethodDeleteRequest, PaymentMethodEntity>();
        }
    }
}

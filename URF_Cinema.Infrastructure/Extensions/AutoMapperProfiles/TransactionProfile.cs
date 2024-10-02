using AutoMapper;
using URF_Cinema.Domain.Entities;
using URF_Cinema.Application.DataTransferObjects.Transaction;
using URF_Cinema.Application.DataTransferObjects.Transaction.Request;

namespace URF_Cinema.Infrastructure.Extensions.AutoMapperProfiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionEntity, TransactionDto>()
                .ForMember(des => des.PaymentMethodName, opt => opt.MapFrom(x => x.PaymentMethod.Name));
            CreateMap<TransactionCreateRequest, TransactionEntity>();
            CreateMap<TransactionUpdateRequest, TransactionEntity>();
        }
    }
}

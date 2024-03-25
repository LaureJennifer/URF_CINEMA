using AutoMapper;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Domain.Entities;
using BaseSolution.Application.DataTransferObjects.Transaction;
using BaseSolution.Application.DataTransferObjects.Transaction.Request;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionEntity, TransactionDto>()
                .ForMember(des => des.PaymentMethodName, opt => opt.MapFrom(x => x.PaymentMethodEntity.Name));
            CreateMap<TransactionCreateRequest, TransactionEntity>();
            CreateMap<TransactionUpdateRequest, TransactionEntity>();
        }
    }
}

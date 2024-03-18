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
            CreateMap<TransactionEntity, TransactionDto>();
            CreateMap<TransactionCreateRequest, TransactionEntity>();
            CreateMap<TransactionUpdateRequest, TransactionEntity>();
        }
    }
}

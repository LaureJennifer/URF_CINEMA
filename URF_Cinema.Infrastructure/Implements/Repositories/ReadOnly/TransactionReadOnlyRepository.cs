using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Transaction;
using URF_Cinema.Application.DataTransferObjects.Transaction.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Enums;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class TransactionReadOnlyRepository : ITransactionReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public TransactionReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<TransactionDto?>> GetTransactionByIdAsync(Guid idTransaction, CancellationToken cancellationToken)
        {
            try
            {
                var transaction = await _appReadOnlyDbContext.TransactionEntities.AsNoTracking().Where(c => c.Id == idTransaction && !c.Deleted).ProjectTo<TransactionDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<TransactionDto?>.Succeed(transaction);
            }
            catch (Exception e)
            {
                return RequestResult<TransactionDto?>.Fail(_localizationService["Transaction is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Transaction"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<TransactionDto>>> GetTransactionWithPaginationByAdminAsync(ViewTransactionWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var transactions = _appReadOnlyDbContext.TransactionEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<TransactionDto>(_mapper.ConfigurationProvider);
                if (request.BillId!=null)
                {
                    transactions = transactions.Where(x => x.BillId==request.BillId);
                }
                if (request.TransactionDate != null)
                {
                    transactions = transactions.Where(x => x.TransactionDate == request.TransactionDate);
                }
                if (request.Status != null)
                {
                    transactions = transactions.Where(x => x.Status == request.Status);
                }
                var result = await transactions.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<TransactionDto>>.Succeed(new PaginationResponse<TransactionDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<TransactionDto>>.Fail(_localizationService["List of transaction are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of transaction"
                    }
                });
            }
        }
    }
}


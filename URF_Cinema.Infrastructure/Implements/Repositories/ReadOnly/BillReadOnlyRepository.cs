using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.Interfaces.Repositories.ReadOnly;
using URF_Cinema.Application.Interfaces.Services;
using URF_Cinema.Application.ValueObjects.Common;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Infrastructure.Database.AppDbContext;
using URF_Cinema.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace URF_Cinema.Infrastructure.Implements.Repositories.ReadOnly
{
    public class BillReadOnlyRepository : IBillReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly AppReadWriteDbContext _appReadWriteDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public BillReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, AppReadWriteDbContext appReadWriteDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _appReadWriteDbContext = appReadWriteDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<BillDto?>> GetBillByIdAsync(Guid idBill, CancellationToken cancellationToken)
        {
            try
            {
                var bill_ = await _appReadOnlyDbContext.BillEntities.AsNoTracking().Where(c => c.Id == idBill && !c.Deleted).ProjectTo<BillDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);   


                return RequestResult<BillDto?>.Succeed(bill_);
            }
            catch (Exception e)
            {
                return RequestResult<BillDto?>.Fail(_localizationService["Bill is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "bill"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<BillDto>>> GetBillWithPaginationByAdminAsync(ViewBillWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var bills = _appReadOnlyDbContext.BillEntities.AsNoTracking().ProjectTo<BillDto>(_mapper.ConfigurationProvider);
                if (request.CustomerId!=null)
                {
                    bills = bills.Where(x => x.CustomerId == request.CustomerId);
                }
                if (request.DepartmentId != null)
                {
                    bills = bills.Where(x => x.DepartmentId == request.DepartmentId);
                }
                if (!string.IsNullOrWhiteSpace(request.Code))
                {
                    bills = bills.Where(x => x.Code == request.Code);
                }
                if (!string.IsNullOrWhiteSpace(request.CustomerName))
                {
                    bills = bills.Where(x => x.CustomerName == request.CustomerName);
                }
                if (!string.IsNullOrWhiteSpace(request.DepartmentName))
                {
                    bills = bills.Where(x => x.CustomerName == request.CustomerName);
                }
                var result = await bills.PaginateAsync(request, cancellationToken);

                return RequestResult<PaginationResponse<BillDto>>.Succeed(new PaginationResponse<BillDto>()
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {
                return RequestResult<PaginationResponse<BillDto>>.Fail(_localizationService["List of bill are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of bill"
                    }
                });
            }
        }
    }
}

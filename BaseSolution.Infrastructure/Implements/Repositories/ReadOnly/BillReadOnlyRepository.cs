using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Example;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Extensions;
using BaseSolution.Infrastructure.Implements.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class BillReadOnlyRepository : IBillReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public BillReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
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
                var query = _appReadOnlyDbContext.BillEntities.AsNoTracking().ProjectTo<BillDto>(_mapper.ConfigurationProvider);

                if (!string.IsNullOrWhiteSpace(request.SearchString))
                {
                    query = query.Where(x => x.Code == request.SearchString);
                }
                var result = await query.PaginateAsync(request, cancellationToken);

                foreach (var item in result.Data!)
                {
                    var userCreated = await _appReadOnlyDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item.CreatedBy, cancellationToken) == null ? "N/A" : _appReadOnlyDbContext.Users.AsNoTracking().First(x => x.Id == item.CreatedBy)!.Name;
                    item.CreatedUserName = userCreated;

                    item.ServiceAmount = (float)(item.TotalService * item.ServicePrice);

                    // tính  tổng tiền 
                    item.TotalAmount = item.ServiceAmount + (float)item.RoomPrice;
                }
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
                return RequestResult<PaginationResponse<BillDto>>.Fail(_localizationService["List of Bill are not found"], new[]
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

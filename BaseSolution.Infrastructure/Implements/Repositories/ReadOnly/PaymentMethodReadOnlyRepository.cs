using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.PaymentMethod;
using BaseSolution.Application.DataTransferObjects.PaymentMethod.Request;
using BaseSolution.Application.DataTransferObjects.RoomLayout;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Enums;
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
    public class PaymentMethodReadOnlyRepository : IPaymentMethodReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public PaymentMethodReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<PaymentMethodDto?>> GetPaymentMethodByIdAsync(Guid idPaymentMethod, CancellationToken cancellationToken)
        {
            try
            {
                var roomLayout = await _appReadOnlyDbContext.PaymentMethodEntities.AsNoTracking().Where(c => c.Id == idPaymentMethod && !c.Deleted).ProjectTo<PaymentMethodDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<PaymentMethodDto?>.Succeed(roomLayout);
            }
            catch (Exception e)
            {
                return RequestResult<PaymentMethodDto?>.Fail(_localizationService["Payment method is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Payment method"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<PaymentMethodDto>>> GetPaymentMethodWithPaginationByAdminAsync(ViewPaymentMethodWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var paymentMethod = _appReadOnlyDbContext.PaymentMethodEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<PaymentMethodDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    paymentMethod = paymentMethod.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
                }
                
                var result = await paymentMethod.PaginateAsync(request, cancellationToken);
                return RequestResult<PaginationResponse<PaymentMethodDto>>.Succeed(new PaginationResponse<PaymentMethodDto>
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {

                return RequestResult<PaginationResponse<PaymentMethodDto>>.Fail(_localizationService["List of payment method are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error= e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of payment method"
                    }
                });
            }
        }
    }
}

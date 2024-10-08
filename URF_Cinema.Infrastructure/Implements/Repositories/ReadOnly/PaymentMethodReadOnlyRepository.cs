﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;
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
                var paymentMethods = _appReadOnlyDbContext.PaymentMethodEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<PaymentMethodDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    paymentMethods = paymentMethods.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
                }
                
                var result = await paymentMethods.PaginateAsync(request, cancellationToken);
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

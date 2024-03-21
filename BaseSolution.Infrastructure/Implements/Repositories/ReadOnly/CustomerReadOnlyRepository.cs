using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Domain.Enums;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Extensions;
using BaseSolution.Infrastructure.Implements.Services;
using BaseSolution.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        private readonly AppReadOnlyDbContext _appReadOnlyDbContext;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;
        public CustomerReadOnlyRepository(AppReadOnlyDbContext appReadOnlyDbContext, IMapper mapper, ILocalizationService localizationService)
        {
            _appReadOnlyDbContext = appReadOnlyDbContext;
            _mapper = mapper;
            _localizationService = localizationService;
        }
        public async Task<RequestResult<CustomerDto?>> GetCustomerByEmailAsync(string Email, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _appReadOnlyDbContext.CustomerEntities.AsNoTracking().Where(c => c.Email == Email && !c.Deleted).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<CustomerDto?>.Succeed(customer);
            }
            catch (Exception e)
            {
                return RequestResult<CustomerDto?>.Fail(_localizationService["Customer is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Customer"
                    }
                });
            }
        }

        public async Task<RequestResult<CustomerDto?>> GetCustomerByIdAsync(Guid idCustomer, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _appReadOnlyDbContext.CustomerEntities.AsNoTracking().Where(c => c.Id == idCustomer && !c.Deleted).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<CustomerDto?>.Succeed(customer);
            }
            catch (Exception e)
            {
                return RequestResult<CustomerDto?>.Fail(_localizationService["Customer is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Customer"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<CustomerDto>>> GetCustomerWithPaginationByAdminAsync(ViewCustomerWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _appReadOnlyDbContext.CustomerEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    customer = customer.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
                }
               
                var result = await customer.PaginateAsync(request, cancellationToken);

                return RequestResult<PaginationResponse<CustomerDto>>.Succeed(new PaginationResponse<CustomerDto>()
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = result.HasNext,
                    Data = result.Data
                });
            }
            catch (Exception e)
            {
                return RequestResult<PaginationResponse<CustomerDto>>.Fail(_localizationService["List of customer are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of customer"
                    }
                });
            }
        }
    }
}

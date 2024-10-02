using AutoMapper;
using AutoMapper.QueryableExtensions;
using URF_Cinema.Application.DataTransferObjects.Customer;
using URF_Cinema.Application.DataTransferObjects.Customer.Request;
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

        public async Task<RequestResult<CustomerDto?>> GetCustomerByIdentificationAsync(string identification, CancellationToken cancellationToken)
        {
            try
            {
                var Customer = await _appReadOnlyDbContext.CustomerEntities.AsNoTracking().Where(c => c.IdentificationNumber == identification && !c.Deleted).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<CustomerDto>.Succeed(Customer);
            }
            catch (Exception e)
            {
                return RequestResult<CustomerDto>.Fail(_localizationService["Customer is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "Customer"
                    }
                });
            }
        }

        public async Task<RequestResult<CustomerDto?>> GetCustomerByNameAsync(string name, CancellationToken cancellationToken)
        {
            try
            {
                var customer_ =  await _appReadOnlyDbContext.CustomerEntities.AsNoTracking().Where(x=>x.Email == name && !x.Deleted).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
                return RequestResult<CustomerDto?>.Succeed(customer_);
            }
            catch(Exception e)
            {
                return RequestResult<CustomerDto>.Fail(_localizationService["Customer is not found"], new[]
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
                var customers = _appReadOnlyDbContext.CustomerEntities.AsNoTracking().Where(x => x.Status != EntityStatus.Deleted).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider);
                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    customers = customers.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
                }
               
                var result = await customers.PaginateAsync(request, cancellationToken);

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

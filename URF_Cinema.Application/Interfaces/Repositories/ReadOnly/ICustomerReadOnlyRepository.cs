using URF_Cinema.Application.DataTransferObjects.Customer;
using URF_Cinema.Application.DataTransferObjects.Customer.Request;
using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface ICustomerReadOnlyRepository
    {
        Task<RequestResult<CustomerDto?>> GetCustomerByIdAsync(Guid idCustomer, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<CustomerDto>>> GetCustomerWithPaginationByAdminAsync(
            ViewCustomerWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<CustomerDto?>> GetCustomerByEmailAsync(string Email, CancellationToken cancellationToken);
        Task<RequestResult<CustomerDto?>> GetCustomerByNameAsync(string name, CancellationToken cancellationToken);
        Task<RequestResult<CustomerDto?>> GetCustomerByIdentificationAsync(string identification, CancellationToken cancellationToken);

    }
}

using URF_Cinema.Application.DataTransferObjects.Customer.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface ICustomerReadWriteRepository
    {
        Task<RequestResult<Guid>> AddCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteCustomerAsync(CustomerDeleteRequest request, CancellationToken cancellationToken);
        Task<RequestResult<Guid>> RegisterCustomerAsync(CustomerEntity request, CancellationToken cancellationToken);
        Task<RequestResult<Guid>> ResetPasswordCustomerAsync(CustomerEntity entity, CancellationToken cancellationToken);
    }
}

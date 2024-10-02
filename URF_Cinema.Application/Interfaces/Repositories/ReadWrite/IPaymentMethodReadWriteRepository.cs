using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IPaymentMethodReadWriteRepository
    {
        Task<RequestResult<Guid>> AddPaymentMethodAsync(PaymentMethodEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdatePaymentMethodAsync(PaymentMethodEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeletePaymentMethodAsync(PaymentMethodDeleteRequest request, CancellationToken cancellationToken);
    }
}

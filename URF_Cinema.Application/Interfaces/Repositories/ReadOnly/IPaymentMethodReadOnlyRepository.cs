using URF_Cinema.Application.ValueObjects.Pagination;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
{
    public interface IPaymentMethodReadOnlyRepository
    {
        Task<RequestResult<PaymentMethodDto?>> GetPaymentMethodByIdAsync(Guid idPaymentMethod, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<PaymentMethodDto>>> GetPaymentMethodWithPaginationByAdminAsync(
            ViewPaymentMethodWithPaginationRequest request, CancellationToken cancellationToken);
    }
}

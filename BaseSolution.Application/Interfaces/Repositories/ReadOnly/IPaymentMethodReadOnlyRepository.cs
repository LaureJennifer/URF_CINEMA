using BaseSolution.Application.DataTransferObjects.Booking.Request;
using BaseSolution.Application.DataTransferObjects.Booking;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Application.DataTransferObjects.PaymentMethod;
using BaseSolution.Application.DataTransferObjects.PaymentMethod.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IPaymentMethodReadOnlyRepository
    {
        Task<RequestResult<PaymentMethodDto?>> GetPaymentMethodByIdAsync(Guid idPaymentMethod, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<PaymentMethodDto>>> GetPaymentMethodWithPaginationByAdminAsync(
            ViewPaymentMethodWithPaginationRequest request, CancellationToken cancellationToken);
    }
}

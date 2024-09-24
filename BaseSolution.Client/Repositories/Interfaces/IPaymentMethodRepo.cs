using BaseSolution.Application.DataTransferObjects.PaymentMethod.Request;
using BaseSolution.Application.DataTransferObjects.PaymentMethod;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Client.Data;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IPaymentMethodRepo
    {
        public Task<bool> AddAsync(PaymentMethodCreateRequest request);
        public Task<RequestResult<PaymentMethodDeleteRequest>> RemoveAsync(PaymentMethodDeleteRequest request);
        public Task<bool> UpdateAsync(PaymentMethodUpdateRequest request);
        public Task<RequestResult<PaymentMethodDto>> GetByIdAsync(Guid id);
        public Task<PaymentMethodListWithPaginationViewModel> GetAllActive(ViewPaymentMethodWithPaginationRequest request);
    }
}

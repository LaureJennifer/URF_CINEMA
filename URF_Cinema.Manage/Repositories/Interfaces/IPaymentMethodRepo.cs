using URF_Cinema.Application.DataTransferObjects.PaymentMethod.Request;
using URF_Cinema.Application.DataTransferObjects.PaymentMethod;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Manage.Data;

namespace URF_Cinema.Manage.Repositories.Interfaces
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

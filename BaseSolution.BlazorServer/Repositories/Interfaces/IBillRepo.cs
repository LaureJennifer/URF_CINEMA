using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IBillRepo
    {
        public Task<bool> AddAsync(BillCreateRequest request);
        public Task<RequestResult<BillDeleteRequest>> RemoveAsync(BillDeleteRequest request);
        public Task<bool> UpdateAsync(BillUpdateRequest request);
        public Task<RequestResult<BillDto>> GetByIdAsync(Guid id);
        public Task<BillListWithPaginationViewModel> GetAllActive(ViewBillWithPaginationRequest request);
    }
}

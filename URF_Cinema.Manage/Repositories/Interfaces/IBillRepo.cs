using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Manage.Data;
using URF_Cinema.Infrastructure.ViewModels;

namespace URF_Cinema.Manage.Repositories.Interfaces
{
    public interface IBillRepo
    {
        public Task<bool> AddAsync(BillCreateRequest request);
        public Task<RequestResult<BillDeleteRequest>> RemoveAsync(BillDeleteRequest request);
        public Task<bool> UpdateAsync(BillUpdateRequest request);
        public Task<RequestResult<BillDto>> GetByIdAsync(Guid id);
        public Task<BillListWithPaginationViewModel> GetAllActive(ViewBillWithPaginationRequest request);
        //Task<bool> CreateNewBill(BillCreateRequest request);

        Task<bool> CreateNewPayment(CheckoutVM request);
    }
}

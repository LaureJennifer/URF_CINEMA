using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.BlazorServer.Data;
using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Application.DataTransferObjects.Bill;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface ICustomerRepo
    {
        //public Task<bool> AddAsync(CustomerCreateRequest request);
        public Task<bool> RegisterAsync(RegisterRequest request);
        public Task<RequestResult<CustomerDeleteRequest>> RemoveAsync(CustomerDeleteRequest request);
        public Task<bool> UpdateAsync(CustomerUpdateRequest request);
        public Task<RequestResult<CustomerDto>> GetByIdAsync(Guid id);
        public Task<CustomerListWithPaginationViewModel> GetAllActive(ViewCustomerWithPaginationRequest request);
        public Task<RequestResult<CustomerDto>> GetByNameAsync(string roomLayoutName);
        public Task<RequestResult<BillDto>> SendEmailAsync(string email, BillDto _bill);
    }
}

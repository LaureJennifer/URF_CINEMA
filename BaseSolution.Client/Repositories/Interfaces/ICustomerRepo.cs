using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Application.DataTransferObjects.Account;
using BaseSolution.Client.Data;

namespace BaseSolution.Client.Repositories.Interfaces
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
        
    }
}

using URF_Cinema.Application.DataTransferObjects.Customer.Request;
using URF_Cinema.Application.DataTransferObjects.Customer;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Application.DataTransferObjects.Account;
using URF_Cinema.Manage.Data;

namespace URF_Cinema.Manage.Repositories.Interfaces
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

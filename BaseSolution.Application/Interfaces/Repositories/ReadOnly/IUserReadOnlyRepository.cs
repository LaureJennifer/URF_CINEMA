using BaseSolution.Application.DataTransferObjects.Customer.Request;
using BaseSolution.Application.DataTransferObjects.Customer;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.DataTransferObjects.User.Request;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IUserReadOnlyRepository
    {
        Task<RequestResult<UserDto?>> GetUserByIdAsync(Guid idUser, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<UserDto>>> GetUserWithPaginationByAdminAsync(
            ViewUserWithPaginationRequest request, CancellationToken cancellationToken);
        Task<RequestResult<UserDto>> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken);
    }
}

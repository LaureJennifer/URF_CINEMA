using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.User.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface IUserReadWriteRepository
    {
        Task<RequestResult<Guid>> AddUserAsync(UserEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateUserAsync(UserEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteUserAsync(UserDeleteRequest request, CancellationToken cancellationToken);
    }
}

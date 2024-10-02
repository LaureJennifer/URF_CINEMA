using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.ValueObjects.Response;
using URF_Cinema.Domain.Entities;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadWrite
{
    public interface IBillReadWriteRepository
    {
        Task<RequestResult<Guid>> AddBillAsync(BillEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> UpdateBillAsync(BillEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<int>> DeleteBillAsync(BillDeleteRequest request, CancellationToken cancellationToken);
    }
}

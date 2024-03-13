using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Example.Request;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
    public interface IBillReadWriteRepository
    {
        Task<RequestResult<Guid>> AddBillAsync(BillEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<bool>> UpdateBillAsync(BillEntity entity, CancellationToken cancellationToken);
        Task<RequestResult<bool>> DeleteBillAsync(BillDeleteRequest request, CancellationToken cancellationToken);
    }
}

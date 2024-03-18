using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.DataTransferObjects.Department;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IBillReadOnlyRepository
    {
        Task<RequestResult<BillDto?>> GetBillByIdAsync(Guid idBill, CancellationToken cancellationToken);
        Task<RequestResult<PaginationResponse<BillDto>>> GetBillWithPaginationByAdminAsync(
            ViewBillWithPaginationRequest request, CancellationToken cancellationToken);
    }
}

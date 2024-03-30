using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
    public interface IBillStatisticReadOnlyRespository
    {
        Task<RequestResult<List<BillStatisticForMonthDto>>> GetBillStasticForMonthAsync(
        BillStatisticRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<BillStatisticForQuarterDto>>> GetBillStasticForQuarterAsync(
        BillStatisticRequest request, CancellationToken cancellationToken);
        Task<RequestResult<List<BillStatisticForYearDto>>> GetBillStasticForYearAsync(
        BillStatisticRequest request, CancellationToken cancellationToken);
    }
}

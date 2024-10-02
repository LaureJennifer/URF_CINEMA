using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Application.ValueObjects.Response;

namespace URF_Cinema.Application.Interfaces.Repositories.ReadOnly
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

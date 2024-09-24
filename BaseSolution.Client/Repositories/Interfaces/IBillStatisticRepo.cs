using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface IBillStatisticRepo
    {
        Task<List<BillStatisticForQuarterDto>> GetBillStatisticsForQuarterAsync(BillStatisticRequest request);
        Task<List<BillStatisticForMonthDto>> GetBillStatisticsForMonthAsync(BillStatisticRequest request);
        Task<List<BillStatisticForYearDto>> GetBillStatisticsForYearAsync(BillStatisticRequest request);

    }
}

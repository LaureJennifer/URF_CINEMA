using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.BlazorServer.ValueObjects.Response;
using BaseSolution.Infrastructure.ViewModels.Statistic.Bill;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface IBillStatisticRepo
    {
        Task<List<BillStatisticForQuarterDto>> GetBillStatisticsForQuarterAsync(BillStatisticRequest request);
        Task<List<BillStatisticForMonthDto>> GetBillStatisticsForMonthAsync(BillStatisticRequest request);
        Task<List<BillStatisticForYearDto>> GetBillStatisticsForYearAsync(BillStatisticRequest request);

    }
}

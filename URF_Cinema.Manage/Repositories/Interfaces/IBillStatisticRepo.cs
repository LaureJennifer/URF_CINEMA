using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;

namespace URF_Cinema.Manage.Repositories.Interfaces
{
    public interface IBillStatisticRepo
    {
        Task<List<BillStatisticForQuarterDto>> GetBillStatisticsForQuarterAsync(BillStatisticRequest request);
        Task<List<BillStatisticForMonthDto>> GetBillStatisticsForMonthAsync(BillStatisticRequest request);
        Task<List<BillStatisticForYearDto>> GetBillStatisticsForYearAsync(BillStatisticRequest request);

    }
}

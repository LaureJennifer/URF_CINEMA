using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Application.DataTransferObjects.Bill.Request;
using URF_Cinema.Manage.Repositories.Interfaces;

namespace URF_Cinema.Manage.Repositories.Implements
{
    public class BillStatisticRepo : IBillStatisticRepo
    {
        public async Task<List<BillStatisticForQuarterDto>> GetBillStatisticsForQuarterAsync(BillStatisticRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            try
            {
                string url = $"api/BillStatistics/BillStatisticForQuarter?PageNumber={request.PageNumber}&PageSize={request.PageSize}";

                var result = await client.GetFromJsonAsync<List<BillStatisticForQuarterDto>>(url);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<BillStatisticForMonthDto>> GetBillStatisticsForMonthAsync(BillStatisticRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            try
            {
                string url = $"api/BillStatistics/BillStatisticForMonth?PageNumber={request.PageNumber}&PageSize={request.PageSize}";

                var result = await client.GetFromJsonAsync<List<BillStatisticForMonthDto>>(url);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }        

        public async Task<List<BillStatisticForYearDto>> GetBillStatisticsForYearAsync(BillStatisticRequest request)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            try
            {
                string url = $"api/BillStatistics/BillStatisticForYear?PageNumber={request.PageNumber}&PageSize={request.PageSize}";

                var result = await client.GetFromJsonAsync<List<BillStatisticForYearDto>>(url);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

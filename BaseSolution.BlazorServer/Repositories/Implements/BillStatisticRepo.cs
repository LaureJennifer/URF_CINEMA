using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.Application.DataTransferObjects.Bill.Request;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using BaseSolution.BlazorServer.ValueObjects.Response;
using BaseSolution.Infrastructure.ViewModels.Statistic.Bill;
using System.Net.Http;

namespace BaseSolution.BlazorServer.Repositories.Implements
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
                string url = $"api/BillStatistics/BillStatisticForQuarter";

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
                string url = $"api/BillStatistics/BillStatisticForMonth";

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
                string url = $"api/BillStatistics/BillStatisticForYear";

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

using BaseSolution.Application.DataTransferObjects.Bill;
using BaseSolution.BlazorServer.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Mail;
using System.Text.Json;

namespace BaseSolution.BlazorServer.Repositories.Implements
{
    public class SendMailCustomer : ISendMailCustomer
    {
        
        private readonly ILogger<SendMailCustomer> logger;
        public SendMailCustomer(ILogger<SendMailCustomer> _logger)
        {
            logger = _logger;
            logger.LogInformation("Create SendMailCustomer");
            
        }
        public async Task SendEmailAsync(BillDto _bill)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005")
            };
            _bill.CustomerEmail = JsonSerializer.Serialize(_bill.CustomerEmail);
                     
            var obj = await client.PostAsJsonAsync($"api/Customers/sendGmail", _bill);
            logger.LogInformation("send mail to " + _bill.CustomerEmail);
        }
    }
}

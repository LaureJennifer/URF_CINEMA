using URF_Cinema.Application.DataTransferObjects.Bill;
using URF_Cinema.Manage.Repositories.Interfaces;
using System.Text.Json;

namespace URF_Cinema.Manage.Repositories.Implements
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

using BaseSolution.Application.DataTransferObjects.Bill;

namespace BaseSolution.BlazorServer.Repositories.Interfaces
{
    public interface ISendMailCustomer
    {
        public Task SendEmailAsync(BillDto _bill);
    }
}

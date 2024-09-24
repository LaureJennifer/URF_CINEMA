using BaseSolution.Application.DataTransferObjects.Bill;

namespace BaseSolution.Client.Repositories.Interfaces
{
    public interface ISendMailCustomer
    {
        public Task SendEmailAsync(BillDto _bill);
    }
}

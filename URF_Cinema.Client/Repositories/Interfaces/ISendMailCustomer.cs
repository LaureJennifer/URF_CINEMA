using URF_Cinema.Application.DataTransferObjects.Bill;

namespace URF_Cinema.Client.Repositories.Interfaces
{
    public interface ISendMailCustomer
    {
        public Task SendEmailAsync(BillDto _bill);
    }
}

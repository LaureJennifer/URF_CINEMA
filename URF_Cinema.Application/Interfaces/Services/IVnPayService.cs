using URF_Cinema.Application.DataTransferObjects.VnPayment;
using Microsoft.AspNetCore.Http;

namespace URF_Cinema.Application.Interfaces.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(HttpContext context, VnPayRequest request);
        VnPaymentDto PaymentExecute(IQueryCollection collections);
    }
}

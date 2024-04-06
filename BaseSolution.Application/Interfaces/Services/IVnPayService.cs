using BaseSolution.Application.DataTransferObjects.VnPayment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(HttpContext context, VnPayRequest request);
        VnPaymentDto PaymentExecute(IQueryCollection collections);
    }
}

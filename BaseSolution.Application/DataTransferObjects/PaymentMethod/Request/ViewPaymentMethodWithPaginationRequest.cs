using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.PaymentMethod.Request
{
    public class ViewPaymentMethodWithPaginationRequest : PaginationRequest
    {
        public string? Name { get; set; }
    }
}

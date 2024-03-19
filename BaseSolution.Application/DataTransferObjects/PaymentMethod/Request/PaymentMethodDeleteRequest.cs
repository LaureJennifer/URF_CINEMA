using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.PaymentMethod.Request
{
    public class PaymentMethodDeleteRequest
    {
        public Guid Id { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}

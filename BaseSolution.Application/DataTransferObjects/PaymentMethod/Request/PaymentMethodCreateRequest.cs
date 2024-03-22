using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.PaymentMethod.Request
{
    public class PaymentMethodCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
    }
}
